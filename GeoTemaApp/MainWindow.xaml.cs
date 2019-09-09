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
        //Her bliver MainWindow initialiseret
        public MainWindow()
        {
            InitializeComponent();
        }

        //Her siger jeg at hvis der bliver trykket på knappen Register, åbnes der en ny form hvor det er muligt at registrere sig som bruger.
        public void RegisterButton(object sender, RoutedEventArgs e)
        {
            Registration registrationObj = new Registration();
            registrationObj.Show();
            this.Close();

        }

        //Her har jeg lavet en metode til at reset textboksene. Jeg kan så bruge denne metode hvor jeg vil, som f.eks når man har indtastet forkert Username eller Password så bliver de reset. 
        void Clear()
        {
            usernameBox.Text = passwordBox.Text = "";
        }

        //Her er min login butt Click funktion. 
        private void LoginButt_Click(object sender, RoutedEventArgs e)
        {
            //I første if kigger jeg i min combobox på formen MainWindow efter hvis Regular User er valgt. Hvis Regular user er valgt prøv dette hvis der bliver klikket på login.
            if (RegUser.IsSelected)
            {
                //Det at min try/catch vil gøre er, at selecte det input der er kommet fra tekstboksene og derefter lede efter det i en lokal database. Hvis den kan finde de data der er blevet indtastet, login succesfuldt. Hvis ikke er det forkert Username og Password der er blevet indtastet.
                //Det jeg har gjort her, er at jeg har lavet forskellige connectionstrings til min sql database(r) fordi at der er forskellige typer brugere at kunne logge ind med, og vær type har vær deres database.
                //Så i den første connectionstring peger den på databasen Users, og min String Query udføre så denne query inde i den database!
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
            //Nu er den første if blevet kørt igennem, og det gik helt fint. Men nu har jeg f.eks valgt at logge ind som Admin istedet for. Og her siger den så, at hvis RegUser/Superuser ikke er valgt, men AdminUser is selected. prøv noget. Det er det samme som ovenover, og det er også det samme som nedeunder, det eneste der er forskellen er at de peger på en forskellig database(r)
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
    

 






