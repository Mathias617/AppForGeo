﻿using System;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
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

namespace GeoTemaApp
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Window
    {
        public dashboard()
        {
            InitializeComponent();
        }

        /* Her har jeg en button der skal vise data fra en tabel inde i selve appen, og i min form har jeg selvfølgelig tilføjet et datagrid hvor at data kan blive vist, også en knap for at få det hele frem i datagriddet.
         * Og det har jeg så gjort for de forskellige buttons. Alle buttons har vær deres database de kigger i, og man kan så vælge at få vist information fra den ene tabel eller den anden. 
         * Der er også en back button som går tilbage til MainWindow.  
        */
        private void Show_data_table_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {

                conn.Open();
                String query = "select * from Users";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable("Users");
                dataAdp.Fill(dataTable);
                Table_data.ItemsSource = dataTable.DefaultView;
                dataAdp.Update(dataTable);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Data_table_superusers_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=superUsers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                conn.Open();
                String query = "select * from Superusers";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable("superUsers");
                dataAdp.Fill(dataTable);
                Table_data.ItemsSource = dataTable.DefaultView;
                dataAdp.Update(dataTable);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Data_table_Admin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=adminUsers;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                conn.Open();
                String query = "select * from Admins";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable("adminUsers");
                dataAdp.Fill(dataTable);
                Table_data.ItemsSource = dataTable.DefaultView;
                dataAdp.Update(dataTable);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackButt_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}




 
