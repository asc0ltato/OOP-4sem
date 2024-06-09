using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1.Add
{
    /// <summary>
    /// Логика взаимодействия для ManufacturerElement.xaml
    /// </summary>
    public partial class ManufacturerElement : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;

        public ManufacturerElement()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM MANUFACTURER";
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string country = reader.GetString(2);
                    int year = reader.GetInt32(3);
                    Manufacturer manufacturer = new Manufacturer(id, name, country, year);
                    DataGridManufacturer.Items.Add(manufacturer);
                }
            }
        }

        private void AddManufacturerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!IsValidInput())
                {
                    MessageBox.Show("Пожалуйста, введите корректные данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataGridManufacturer.Items.Clear();
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = transaction;

                    command.CommandText = "INSERT INTO MANUFACTURER (ID, Name, Country, Year) VALUES (@ID, @Name, @Country, @Year)";
                    command.Parameters.AddWithValue("@ID", Convert.ToInt32(manufacturerID.Text));
                    command.Parameters.AddWithValue("@Name", manufacturerName.Text);
                    command.Parameters.AddWithValue("@Country", manufacturerCountry.Text);
                    command.Parameters.AddWithValue("@Year", Convert.ToInt32(manufacturerYear.Text));
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    RefreshDataGrid();

                    MessageBox.Show("Данные добавлены", "Добавление данных", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show($"Ошибка: {x.Message}", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshDataGrid()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM MANUFACTURER";
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string country = reader.GetString(2);
                    int year = reader.GetInt32(3);
                    Manufacturer manufacturer = new Manufacturer(id, name, country, year);
                    DataGridManufacturer.Items.Add(manufacturer);
                }
            }
        }

        private bool IsValidInput()
        {
            int currentYear = DateTime.Now.Year;
            return Regex.IsMatch(manufacturerID.Text, @"^\d{1,6}$")
                && Regex.IsMatch(manufacturerName.Text, @"^[\p{L}\s-]{1,30}$")
                && Regex.IsMatch(manufacturerCountry.Text, @"^[\p{L}-]{1,30}$") 
                && Regex.IsMatch(manufacturerYear.Text, @"^\d{4}$")
                && Convert.ToInt32(manufacturerYear.Text) <= currentYear; 
        }

        private void manufacturerID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(manufacturerID.Text, @"^\d{1,6}$"))
                manufacturerID.BorderBrush = Brushes.Red;
            else
                manufacturerID.BorderBrush = Brushes.LimeGreen;
        }

        private void manufacturerName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(manufacturerName.Text, @"^[\p{L}\s-]{1,30}$"))
                manufacturerName.BorderBrush = Brushes.Red;
            else
                manufacturerName.BorderBrush = Brushes.LimeGreen;
        }

        private void manufacturerCountry_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(manufacturerCountry.Text, @"^[\p{L}-]{1,30}$")) 
                manufacturerCountry.BorderBrush = Brushes.Red;
            else
                manufacturerCountry.BorderBrush = Brushes.LimeGreen;
        }

        private void manufacturerYear_LostFocus(object sender, RoutedEventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            if (!Regex.IsMatch(manufacturerYear.Text, @"^\d{4}$") || Convert.ToInt32(manufacturerYear.Text) > currentYear)
                manufacturerYear.BorderBrush = Brushes.Red;
            else
                manufacturerYear.BorderBrush = Brushes.LimeGreen;
        }
    }
}
