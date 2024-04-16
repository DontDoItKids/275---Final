﻿using _275___Final.Models;
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
    public partial class AddTransacationControl : UserControl
    {
        AppDBContext _context = new AppDBContext();
        User theUser;
        MainControl mc;

        public AddTransacationControl(User user, MainControl mc)
        {
            InitializeComponent();
            theUser = user;
            this.mc = mc;

            cmbAddress.ItemsSource = _context.CryptoAddresses.Where(ca => ca.UserID == theUser.ID).ToList();

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
