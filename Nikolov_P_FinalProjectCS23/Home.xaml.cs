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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public string Username;

        public Home()
        {
            InitializeComponent();
        }
        private void Play(object sender, RoutedEventArgs e)
        {
            Play play = new Play();
            play.Username = Username;
            play.Show();
            this.Close();
        }
        private void ChessWorld(object sender, RoutedEventArgs e)
        {
            ChessWorld chessWorld = new ChessWorld();
            chessWorld.Username = Username;
            chessWorld.Show();
            this.Close();
        }
        private void Settings(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.settings = settings;
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon.ConnectionString = "server=localhost;uid=root;pwd=1234;database=chess_records";
            sqlCon.Open();
            string query = "SELECT Email, FirstLastNames, Password FROM players WHERE Username = '" + Username + "'";
            MySqlCommand cmd = new MySqlCommand(query, sqlCon);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@Username", query);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                settings.email.Text = reader["Email"].ToString();
                settings.names.Text = reader["FirstLastNames"].ToString();
                settings.password.Password = reader["Password"].ToString();
                settings.repeatedPassword.Password = reader["Password"].ToString();
            }
            reader.Close();
            settings.username.Text = Username;
            settings.mainUsername.Text = Username;
            settings.Username = Username;
            settings.Show();
            this.Close();
        }
        private void Feedback(object sender, RoutedEventArgs e)
        {
            Feedback feedback = new Feedback();
            feedback.Username = Username;
            feedback.Show();
            this.Close();
        }
    }
}
