using _275___Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        AppDBContext _context = new AppDBContext();
        MainWindow mw;
        User theUser;

        public MainControl(string _user, MainWindow mw)
        {
            InitializeComponent();
            theUser = _context.Users.Where(u => u.Username == _user).FirstOrDefault();
            this.mw = mw;
        }

        #region Home Tab

        private void HomeTab_Loaded(object sender, RoutedEventArgs e)
        {
            lblHomeWelcome.Content = "Welcome, " + theUser.Username;
        }

        #endregion

        #region Currencies Tab

        private void CurrenciesTab_Loaded(object sender, RoutedEventArgs e)
        {
            dtgCurrencies.ItemsSource = _context.CryptoCurrencies.ToList();
        }

        private void dtgCurrencies_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(e.PropertyType == typeof(DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "MM/dd/yyyy";
            }
        }

        #endregion

        #region Addresses Tab

        private void AddressesTab_Loaded(object sender, RoutedEventArgs e)
        {
            lblAddressWelcome.Content = theUser.Username + "'s " + "Addresses";
            List<CryptoAddress> addresses = _context.CryptoAddresses.Where(u => u.UserID == theUser.ID).ToList();
            dtgAddress.ItemsSource = addresses;
        }

        private void btnAddAddress_Click(object sender, RoutedEventArgs e)
        {
            gridTheStuff.Children.Add(new CreateAddressControl(theUser, this));
        }

        private void btnAdrSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
        }

        private void dtgAddress_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "UserID")
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Transactions Tab
        private void TransactionTab_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Tax Tab

        private void TaxTab_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Account Tab

        private void AccountTab_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = theUser.Username;
            txtEmail.Text = theUser.Email;
            txtFirstName.Text = theUser.FirstName;
            txtLastName.Text = theUser.LastName;
            dpDOB.SelectedDate = theUser.DateOfBirth;
            chkBusiness.IsChecked = theUser.IsBusiness;
        }

        private void btnAllowChanges_Click(object sender, RoutedEventArgs e)
        {
            txtEmail.Focusable = true;
            txtFirstName.Focusable = true;
            txtLastName.Focusable = true;
            chkBusiness.IsEnabled = true;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "")
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            _context.Users.Where(u => u.ID == theUser.ID).FirstOrDefault().Email = txtEmail.Text;
            _context.Users.Where(u => u.ID == theUser.ID).FirstOrDefault().FirstName = txtFirstName.Text;
            _context.Users.Where(u => u.ID == theUser.ID).FirstOrDefault().LastName = txtLastName.Text;
            _context.Users.Where(u => u.ID == theUser.ID).FirstOrDefault().IsBusiness = chkBusiness.IsChecked.Value;
            _context.SaveChanges();

            txtEmail.Focusable = false;
            txtFirstName.Focusable = false;
            txtLastName.Focusable = false;
            chkBusiness.IsEnabled = false;

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginControl lcc = new LoginControl(mw);
            lcc.SendUsername += mw.del_SendUsername;

            mw.gridEverything.Children.Clear();
            mw.gridEverything.Children.Add(lcc);
        }

        #endregion

    }
}
