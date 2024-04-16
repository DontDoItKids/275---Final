using _275___Final.Models;
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
    /// Interaction logic for RegisterControl.xaml
    /// </summary>
    public partial class RegisterControl : UserControl
    {
        AppDBContext _context = new AppDBContext();
        MainWindow mw;
        public RegisterControl(MainWindow mw)
        {
            InitializeComponent();

            foreach (TextBox tb in gridContent.Children.OfType<TextBox>())
            {
                tb.GotFocus += Tb_GotFocus;
                tb.LostFocus += Tb_LostFocus;
            }

            this.mw = mw;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (dpDOB.SelectedDate.Value == null || cbBusiness.IsChecked.Value == null)
            {
                MessageBox.Show("Please fill out all fields.");
                lblWarning.Visibility = Visibility.Visible;
                lblWarning.Content = "Please fill out all fields.";
                return;
            }
            else if (DateTime.Now.Year - dpDOB.SelectedDate.Value.Year < 18)
            {
                MessageBox.Show("You must be 18 years or older to register.");
                lblWarning.Visibility = Visibility.Visible;
                lblWarning.Content = "You must be 18 years or older to register.";
                return;
            }

            foreach (User u in _context.Users)
            {
                if (u.Username == txtUsername.Text)
                {
                    MessageBox.Show("Username already exists.");
                    lblWarning.Visibility = Visibility.Visible;
                    lblWarning.Content = "Username already exists.";
                    return;
                }
                else if (u.Email == txtEmail.Text)
                {
                    MessageBox.Show("Email is already in use.");
                    lblWarning.Visibility = Visibility.Visible;
                    lblWarning.Content = "Email is already in use.";
                    return;
                }
            }            

            User user = new User()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = dpDOB.SelectedDate.Value,
                IsBusiness = cbBusiness.IsChecked.Value,
                IsAdmin = false
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            mw.gridEverything.Children.Remove(this);
        }

        private void Tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string bad = txt.Name.Split("txt")[1];
            if (txt.Text == bad)
            {
                txt.Text = "";
            }
        }

        private void Tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string bad = txt.Name.Split("txt")[1];
            if (txt.Text == "" || txt.Text == " " || txt.Text is null)
            {
                txt.Text = bad;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            mw.gridEverything.Children.Remove(this);
        }
    }
}
