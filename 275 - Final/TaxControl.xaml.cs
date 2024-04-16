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
    /// Interaction logic for TaxControl.xaml
    /// </summary>
    public partial class TaxControl : UserControl
    {
        User theUser;
        MainControl mc;
        AppDBContext _context = new AppDBContext();
        bool bus;
        double finalVal = 0;

        public TaxControl(User user, MainControl mc, List<Transaction> trans)
        {
            InitializeComponent();
            theUser = user;
            this.mc = mc;
            bus = theUser.IsBusiness;

            Calculate(trans);

            if (finalVal > 0)
            {
                lblPain.Content = "Report a Gain of: $" + Math.Round(finalVal, 2);
            }
            else
            {
                lblPain.Content = "Report a Loss of: $" + Math.Round(finalVal, 2);
            }
        }

        public void Calculate(List<Transaction> transactions)
        {
            double totalGain = 0;

            foreach (Transaction t in transactions)
            {
                totalGain += t.GainLoss;
            }

            if (bus)
            {
                finalVal = totalGain;
            }
            else
            {
                finalVal = totalGain * 0.5;
            }
            //this feels so wrong
            //setting the value instead of returning it
            //I dont care Im tired of thinking about crypto taxes
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mc.gridTheStuff.Children.Remove(this);
        }
    }
}
