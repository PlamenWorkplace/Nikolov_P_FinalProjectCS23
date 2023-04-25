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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private void Submit(object sender, RoutedEventArgs e)
        {
            if (password.Password != repeatPassword.Password)
            {
                MessageBox.Show("Passwords don't match! Try again");
            }
            else
            {
                MySqlConnection sqlCon = new MySqlConnection();
                sqlCon.ConnectionString = "server=localhost;uid=root;pwd=1234;database=chess_records";
                try
                {
                    sqlCon.Open();
                    string query = "INSERT INTO players VALUES (@Username, @Email, @FirstLastNames, @Password)";
                    MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Username", username.Text);
                    cmd.Parameters.AddWithValue("@Email", email.Text);
                    cmd.Parameters.AddWithValue("@FirstLastNames", names.Text);
                    cmd.Parameters.AddWithValue("@Password", password.Password);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");
                    sqlCon.Close();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
