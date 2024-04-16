using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _275___Final
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public delegate void SendUName(string Username);
        public event SendUName SendUsername;
        MainWindow mw;

        AppDBContext _context = new AppDBContext();

        public LoginControl(MainWindow mainW)
        {
            InitializeComponent();
            this.mw = mainW;

            foreach (TextBox tb in gridContent.Children.OfType<TextBox>())
            {
                tb.LostFocus += Tb_LostFocus;
            }
        }

        #region Form Control Events
        //This region is kinda unnecessary.

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            mw.gridEverything.Children.Add(new RegisterControl(mw));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password.");
                return;
            }
            else
            {
                foreach (var user in _context.Users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        MessageBox.Show("Login Successful.");
                        SendUsername(username);
                        return;
                    }
                }
                MessageBox.Show("Invalid Login Credentials.");
            }
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
            }
        }

        private void Tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string bad = txt.Name.Split("txt")[1];
            if (txt.Text == "" || txt.Text == " " || txt.Text is null || txt.Text == String.Empty)
            {
                txt.Text = bad;
            }
        }

        #endregion
    }
}
