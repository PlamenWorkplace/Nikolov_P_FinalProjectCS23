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
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : Window
    {
        public string Username;

        public Feedback()
        {
            InitializeComponent();
        }
        private void Submit(object sender, RoutedEventArgs e)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon.ConnectionString = "server=localhost;uid=root;pwd=1234;database=chess_records";
            try
            {
                sqlCon.Open();
                string query = "INSERT INTO feedbacks VALUES (@Feedback)";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Feedback", feedback.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thank you for your feedback!");
                sqlCon.Close();
                Home home = new Home();
                home.Username = Username;
                home.welcome.Text = $"Welcome, {Username}!";
                home.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
