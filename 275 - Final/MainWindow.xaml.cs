using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginControl lc;
        MainControl mc;        

        public MainWindow()
        {
            InitializeComponent();
            lc = new LoginControl(this);
            lc.SendUsername += del_SendUsername;
        }

        private void gridEverything_Loaded(object sender, RoutedEventArgs e)
        {
            gridEverything.Children.Add(lc);
        }

        private void del_SendUsername(string username)
        {
            mc = new MainControl(username);
            gridEverything.Children.Clear();
            gridEverything.Children.Add(mc);
        }
    }
}