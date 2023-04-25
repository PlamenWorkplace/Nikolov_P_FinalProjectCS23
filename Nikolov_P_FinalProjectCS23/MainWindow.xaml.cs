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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Nikolov_P_FinalProjectCS23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void LogIn(object sender, RoutedEventArgs e)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon.ConnectionString = "server=localhost;uid=root;pwd=1234;database=chess_records";

            try
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM players WHERE Username=@Username AND Password=@Password";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Username", username.Text);
                cmd.Parameters.AddWithValue("@Password", password.Password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    Home home = new Home();
                    home.Username = username.Text;
                    home.welcome.Text = $"Welcome, {username.Text}!";
                    home.Show();
                    this.Close();
                    MessageBox.Show($"Welcome, {username.Text} ");
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SignUp(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }
    }
}
