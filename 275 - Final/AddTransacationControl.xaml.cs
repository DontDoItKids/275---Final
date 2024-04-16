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
    /// Interaction logic for AddTransacationControl.xaml
    /// </summary>
    public partial class AddTransacationControl : UserControl //I can't spell
    {
        AppDBContext _context = new AppDBContext();
        User theUser;
        MainControl mc;

        public AddTransacationControl(User user, MainControl mc)
        {
            InitializeComponent();
            theUser = user;
            this.mc = mc;

            cmbAddress.ItemsSource = _context.CryptoAddresses.Where(ca => ca.UserID == theUser.ID).Select(ca => ca.Address).ToList();

            cmbType.Items.Add("Buy");
            cmbType.Items.Add("Sell");
            cmbType.Items.Add("Gift");

            cmbCurrency.Items.Add("CAD");
            cmbCurrency.Items.Add("USD");

            cmbAddress.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            cmbCurrency.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            double amount;
            double value;
            double gainLoss;

            if (txtAmount.Text == "" || txtOtherAddress.Text == "" || txtValue.Text == "")
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }
            else if (cmbAddress.SelectedValue == null)
            {
                MessageBox.Show("You have to create an address first");
                return;
            }
            else if (!double.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Amount must be a number.");
                return;
            }
            else if(amount <= 0)
            {
                MessageBox.Show("Amount must be greater than 0.");
                return;
            }
            else if (!double.TryParse(txtValue.Text, out value))
            {
                MessageBox.Show("Value must be a number.");
                return;
            }
            else if (value <= 0)
            {
                MessageBox.Show("Value must be greater than 0.");
                return;
            }
            else if(DateTime.Now < dpDate.SelectedDate.Value)
            {
                MessageBox.Show("Date cannot be in the future.");
                return;
            }

            //Forces a default value, because its doesnt know that its default index is 0 instead of null
            //So it will always have a value
            Transaction.TransactionType tType = Transaction.TransactionType.Buy; 

            if (cmbType.SelectedValue == "Buy")
            {
                tType = Transaction.TransactionType.Buy;
            }
            else if (cmbType.SelectedValue == "Sell")
            {
                tType = Transaction.TransactionType.Sell;
            }
            else if (cmbType.SelectedValue == "Gift")
            {
                tType = Transaction.TransactionType.Gift;
            }

            CryptoAddress leAddress = _context.CryptoAddresses.Where(ca => ca.Address == cmbAddress.SelectedValue.ToString()).FirstOrDefault();
            if (tType == Transaction.TransactionType.Buy)
            {
                leAddress.NumberOfTokens += amount;
                gainLoss = amount * value;
            }
            else
            {
                leAddress.NumberOfTokens -= amount;
                gainLoss = (amount * value) * -1;
            }

            _context.Transactions.Add(new Transaction
            {
                UserID = theUser.ID,
                UsersAddress = cmbAddress.SelectedValue.ToString(),
                TargetAddress = txtOtherAddress.Text,
                Type = tType,
                Date = dpDate.SelectedDate.Value,
                AmountOfTokens = amount,
                Currency = cmbCurrency.SelectedValue.ToString(),
                Value = value,
                GainLoss = gainLoss
            });
            

            _context.SaveChanges();
            mc.dtgAddress.ItemsSource = _context.CryptoAddresses.Where(u => u.UserID == theUser.ID).ToList();
            mc.dtgTransaction.ItemsSource = _context.Transactions.Where(u => u.UserID == theUser.ID).ToList();
            mc.gridTheStuff.Children.Remove(this);
        }
    }
}
