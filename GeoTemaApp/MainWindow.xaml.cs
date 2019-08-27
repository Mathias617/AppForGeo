using GeoTemaApp.Properties;
using System;
using System.Data.SqlClient;
using System.Data.Sql;
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

namespace GeoTemaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void RegisterButton(object sender, RoutedEventArgs e)
        {
            Registration registrationObj = new Registration();
            registrationObj.Show();
            this.Close();

        }

        void Clear()
        {
            usernameBox.Text = passwordBox.Text = "";
        }


        private void LoginButt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                con.Open();
                String query = "Select count(1) from Users WHERE Username=@Username And Passw = @Passw";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", con);
                sqlCmd.Parameters.AddWithValue("@Passw", con);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if(count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username eller Password er forkert!");
                    Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Du er nu logget ind!");
                Clear();
                dashboard dashObj = new dashboard();
                dashObj.Show();
                this.Close();

            }
            finally
            {
                con.Close();
                Clear();
            }
        }
    }
}
