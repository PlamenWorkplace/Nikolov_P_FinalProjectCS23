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
using System.Windows.Shapes;

namespace Nikolov_P_FinalProjectCS23
{
    /// <summary>
    /// Interaction logic for Play.xaml
    /// </summary>
    public partial class Play : Window
    {
        public string Username;

        public Play()
        {
            InitializeComponent();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Username = Username;
            home.welcome.Text = $"Welcome, {Username}!";
            home.Show();
            this.Close();
        }
    }
}
