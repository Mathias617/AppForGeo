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
using System.Windows.Shapes;

namespace GeoTemaApp.Properties
{
    public partial class Registration : Window
    {

        public Registration()
        {
            InitializeComponent();
        }

        //I min reg form har jeg har en knap funktion der gør, at de felter du har udfyldt i formen bliver smidt ind i en database, som så kan bruges til at logge ind på formen med. 
        private void RegisterButt_Click(object sender, RoutedEventArgs e)                
        {
            if (usernameBox.Text == "" || passwordBox.Text == "")
                MessageBox.Show("Udfyld de tomme felter");


            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")) 
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("insert into Users(Username, Passw, firstName, Email) values(@Username, @Passw, @firstName, @Email)", con);              
                sqlCmd.Parameters.AddWithValue("@Username", usernameBox.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Passw", passwordBox.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@firstName", firstName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", eMail.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Registrering Fuldført");
                con.Close();
                Clear();


            }
            
            //Her har min clear som resetter tekstboksene.
            void Clear()
            {
                usernameBox.Text = passwordBox.Text = firstName.Text = eMail.Text = "";
            }

            
            
              

        }
        //Og min back button til at vende tilbage til MainWindow.
        private void BackButt_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
