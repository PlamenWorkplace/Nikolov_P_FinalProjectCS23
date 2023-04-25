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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public string Username;
        public Settings settings;
        public Settings()
        {
            InitializeComponent();
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            if (password.Password != repeatedPassword.Password)
            {
                MessageBox.Show("Passwords don't match! Try again");
            }
            else
            {
                Home home = new Home();
                MySqlConnection sqlCon = new MySqlConnection();
                sqlCon.ConnectionString = "server=localhost;uid=root;pwd=1234;database=chess_records";
                try
                {
                    sqlCon.Open();
                    string query = "UPDATE players SET Email = '" + email.Text + "', FirstLastNames = '" + names.Text + "', Password = '" + password.Password + "', Username = '" + username.Text + "' WHERE Username = '" + Username + "'";
                    MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Email", email.Text);
                    cmd.Parameters.AddWithValue("@FirstLastNames", names.Text);
                    cmd.Parameters.AddWithValue("@Password", password.Password);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");
                    sqlCon.Close();
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

        }
        private void Back(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Username = Username;
            home.welcome.Text = $"Welcome, {Username}!";
            home.Show();
            this.Close();
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete();
            delete.settings = settings;
            delete.Username = Username;
            delete.Show();
        }
    }
}
