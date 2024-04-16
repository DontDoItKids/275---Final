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
    /// Interaction logic for CreateAddressControl.xaml
    /// </summary>
    public partial class CreateAddressControl : UserControl
    {
        User _user;
        AppDBContext _context = new AppDBContext();
        MainControl mc;

        public CreateAddressControl(User theUser, MainControl mc)
        {
            InitializeComponent();
            _user = theUser;
            this.mc = mc;
            cmbCurrency.ItemsSource = _context.CryptoCurrencies.Select(c => c.Name).ToList();
            cmbCurrency.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _context.CryptoAddresses.Add(new CryptoAddress
            {
                Address = txtAddress.Text,
                UserID = _user.ID,
                CurrencyID = (int)cmbCurrency.SelectedIndex + 1,
                AddDate = DateTime.Now
            });
            _context.SaveChanges();
            mc.dtgAddress.ItemsSource = _context.CryptoAddresses.Where(u => u.UserID == _user.ID).ToList();
            mc.gridTheStuff.Children.Remove(this);
        }
    }
}
