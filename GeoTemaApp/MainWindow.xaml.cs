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
            {
                if (RegUser.IsSelected)
                {
                    try
                    {
                        con.Open();
                        String Query = "select count(1) from Users WHERE Username= @Username and Passw = @Passw";
                        SqlCommand sqlCommand = new SqlCommand(Query, con);
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@Username", con);
                        sqlCommand.Parameters.AddWithValue("@Passw", con);
                        int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        if (count == 1)
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
                        MessageBox.Show("Du er logget ind!");
                        Clear();
                        dashboard dashObj = new dashboard();
                        dashObj.Show();
                        this.Close();
                    }
                }
                else
                {
                    SqlConnection con2 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=adminUsers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    if (AdminUser.IsSelected)
                    {
                        try
                        {
                            con2.Open();
                            String query = "select count(1) from adminUsers WHERE Username= @Username and Password = @Password";
                            SqlCommand cmd = new SqlCommand(query, con2);
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Parameters.AddWithValue("@Username", con2);
                            cmd.Parameters.AddWithValue("@Password", con2);
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count == 1)
                            {
                                MainWindow admin = new MainWindow();
                                admin.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Log ind mislykkedes! Prøv igen!");
                                Clear();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Du er logget ind!");
                            Clear();
                            DashForAdmin newdash = new DashForAdmin();
                            newdash.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        SqlConnection con3 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Superusers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        if (Superuser.IsSelected)
                        {
                            try
                            {
                                con3.Open();
                                String query = "select count(1) from Superusers WHERE Username= @Username and Password = @Password";
                                SqlCommand cmd = new SqlCommand(query, con3);
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Parameters.AddWithValue("@Username", con3);
                                cmd.Parameters.AddWithValue("@Password", con3);
                                int count = Convert.ToInt32(cmd.ExecuteScalar());
                                if (count == 1)
                                {
                                    MainWindow admin = new MainWindow();
                                    admin.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Log ind mislykkedes! Prøv igen!");
                                    Clear();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Du er logget ind!");
                                Clear();
                                DashboardforSuper newdash2 = new DashboardforSuper();
                                newdash2.Show();
                                this.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
    

 






