using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;

namespace WPF_ZooManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = 
                ConfigurationManager.ConnectionStrings["WPF_ZooManager.Properties.Settings.PanjuTutotialsDbConnectionString"]
                .ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            ShowZoos();
            ShowAnimals();
        }
        private void ShowZoos()
        {
            try
            {
                string query = "select * from Zoo";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();

                    sqlDataAdapter.Fill(zooTable);

                    // Which Information of the table in datatable should be shown in our listbox?
                    listZoos.DisplayMemberPath = "Location";
                    // Which value should be delivered, when an item from our listbox is selected?
                    listZoos.SelectedValuePath = "Id";
                    // The reference to the data the lisbox should populate
                    listZoos.ItemsSource = zooTable.DefaultView;
                }
            
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void ShowAnimals()
        {
            try
            {
                string query = "select * from Animal";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using(sqlDataAdapter)
                {
                    DataTable animalTable = new DataTable();

                    sqlDataAdapter.Fill(animalTable);

                    listAnimals.DisplayMemberPath = "Name";
                    listAnimals.SelectedValuePath= "Id";
                    listAnimals.ItemsSource = animalTable.DefaultView;
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
