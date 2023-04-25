using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using MySql.Data.MySqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;

namespace Nikolov_P_FinalProjectCS23
{
    /// <summary>
    /// Interaction logic for ChessWorld.xaml
    /// </summary>
    public partial class ChessWorld : Window
    {
        public string Username;

        public ChessWorld()
        {
            InitializeComponent();
        }
        private void cmbx__SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox mybox = new ComboBox();
            mybox.Items.Add("Leaderboard");
            mybox.Items.Add("Tournaments");
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Username = Username;
            home.welcome.Text = $"Welcome, {Username}!";
            home.Show();
            this.Close();
        }
        private void Display(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            dataGrid.Items.Refresh();
            if (cmbx_.SelectedIndex == cmbx_.Items.Count - 2)
            {
                MySqlConnection sqlCon = new MySqlConnection();
                sqlCon.ConnectionString = "server=localhost;uid=root;pwd=1234;database=chess_records";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM leaderboard";
                    MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable("leaderboard");
                    mySqlDataAdapter.Fill(table);
                    dataGrid.ItemsSource = table.DefaultView;
                    sqlCon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MySqlConnection sqlCon = new MySqlConnection();
                sqlCon.ConnectionString = "server=localhost;uid=root;pwd=1234;database=chess_records";
                try
                {
                    sqlCon.Open();
                    string query = "SELECT * FROM tournaments";
                    MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable("tournaments");
                    mySqlDataAdapter.Fill(table);
                    dataGrid.ItemsSource = table.DefaultView;
                    sqlCon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
