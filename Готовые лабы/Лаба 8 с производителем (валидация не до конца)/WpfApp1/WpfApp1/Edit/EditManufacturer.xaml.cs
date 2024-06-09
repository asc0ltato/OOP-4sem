using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Edit
{
    /// <summary>
    /// Логика взаимодействия для EditManufacturer.xaml
    /// </summary>
    public partial class EditManufacturer : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;

        public EditManufacturer()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
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

        private bool ValidateID(string id)
        {
            return Regex.IsMatch(id, @"^\d{1,6}$");
        }

        private void ElementToEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string manufacturerId = manufacturerID.Text;

                if (!ValidateID(manufacturerId))
                {
                    MessageBox.Show("ID должен содержать от 1 до 6 цифр.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string parameter = Convert.ToString(manufacturerParameter.Text);
                string newValue = Convert.ToString(manufacturerNewParameter.Text);

                DataGridManufacturer.Items.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "UpdateManufacturer";

                            command.Parameters.AddWithValue("@Id", manufacturerId);
                            command.Parameters.AddWithValue("@Param", parameter);
                            command.Parameters.AddWithValue("@Value", newValue);

                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }

                    using (SqlCommand command = new SqlCommand("SELECT * FROM MANUFACTURER", connection))
                    {
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
                }

                MessageBox.Show("Данные изменены", "Редактирование данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception x)
            {
                MessageBox.Show($"Ошибка: {x.Message}", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
