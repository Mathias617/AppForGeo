using GeoTemaApp.Properties;
using System;
using System.Data;
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
            if (RegUser.IsSelected)
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    con.Open();

                    String Query = "select * from Users where Username = @Username and Passw = @Passw;";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@Username", usernameBox.Text);
                    cmd.Parameters.AddWithValue("@Passw", passwordBox.Text);
                    cmd.Connection = con;

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();

                    bool loginSuccesful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                    if (loginSuccesful)
                    {
                        MessageBox.Show("Login Succesful!");
                        this.Hide();
                        dashboard dash = new dashboard();
                        dash.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                        Clear();
                    }

                }
                finally
                {
                    Clear();
                    MessageBox.Show("Try Again!");


                }

            }
            else
            {
                if (AdminUser.IsSelected)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Admins;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        con.Open();

                        String Query = "select * from Admins where Username = @Username and Password = @Password;";
                        SqlCommand cmd = new SqlCommand(Query, con);
                        cmd.Parameters.AddWithValue("@Username", usernameBox.Text);
                        cmd.Parameters.AddWithValue("@Password", passwordBox.Text);
                        cmd.Connection = con;

                        DataSet ds2 = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds2);
                        con.Close();

                        bool loginSuccesful = ((ds2.Tables.Count > 0) && (ds2.Tables[0].Rows.Count > 0));

                        if (loginSuccesful)
                        {
                            MessageBox.Show("Login Succesful!");
                            this.Hide();
                            DashForAdmin dash = new DashForAdmin();
                            dash.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password");
                            Clear();
                        }

                    }
                    finally
                    {
                        Clear();
                        MessageBox.Show("Try Again!");


                    }
                }
                else
                {
                    if (Superuser.IsSelected)
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Superusers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                            con.Open();

                            String Query = "select * from Superusers where Username = @Username and Password = @Password;";
                            SqlCommand cmd = new SqlCommand(Query, con);
                            cmd.Parameters.AddWithValue("@Username", usernameBox.Text);
                            cmd.Parameters.AddWithValue("@Password", passwordBox.Text);
                            cmd.Connection = con;

                            DataSet ds3 = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(ds3);
                            con.Close();

                            bool loginSuccesful = ((ds3.Tables.Count > 0) && (ds3.Tables[0].Rows.Count > 0));

                            if (loginSuccesful)
                            {
                                MessageBox.Show("Login Succesful!");
                                this.Hide();
                                DashboardforSuper dash = new DashboardforSuper(); 
                                dash.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password");
                                Clear();
                            }

                        }
                        finally
                        {
                            Clear();
                            MessageBox.Show("Try Again!");


                        }

                    }
                }
            }
        }
    }
}
    

 






