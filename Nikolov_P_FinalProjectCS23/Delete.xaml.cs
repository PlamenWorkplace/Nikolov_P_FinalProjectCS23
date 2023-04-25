using MySql.Data.MySqlClient;
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
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public Settings settings;
        public string Username;

        public Delete()
        {
            InitializeComponent();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Confirm(object sender, RoutedEventArgs e)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon.ConnectionString = "server=localhost;uid=root;pwd=1234;database=chess_records";
            try
            {
                sqlCon.Open();
                string query = "DELETE FROM players WHERE Username = '" + Username + "'";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully deleted!");
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            settings.Close();
            this.Close();
        }
    }
}
