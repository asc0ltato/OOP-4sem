using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Edit
{
    /// <summary>
    /// Логика взаимодействия для EditPlane.xaml
    /// </summary>
    public partial class EditPlane : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;

        public EditPlane()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "SELECT PLANE.ID, PLANE.Type, PLANE.Model, PLANE.Capacity, PLANE.Year, PLANE.Load_Capacity, PLANE.Maintenance_Date, MANUFACTURER.Name FROM PLANE INNER JOIN MANUFACTURER ON MANUFACTURER.ID=PLANE.Manufacturer_ID";
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string type = reader.GetString(1);
                    string model = reader.GetString(2);
                    int capacity = reader.GetInt32(3);
                    int year = reader.GetInt32(4);
                    string loadCapacity = reader.GetString(5);
                    DateTime maintenance = reader.GetDateTime(6);
                    string manufacturer = reader.GetString(7);
                    Plane plane = new Plane(id, type, model, capacity, year, loadCapacity, maintenance, manufacturer);
                    DataGridPlanes.Items.Add(plane);
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
                string planeName = planeID.Text;

                if (!ValidateID(planeName))
                {
                    MessageBox.Show("ID должен содержать от 1 до 6 цифр.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string parameter = Convert.ToString(planeParameter.Text);
                string newValue = Convert.ToString(planeNewParameter.Text);

                DataGridPlanes.Items.Clear();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                if (planeParameter.Text == "Type" || planeParameter.Text == "Model" || planeParameter.Text == "Load_Capacity")
                    command.CommandText = "UPDATE PLANE SET PLANE." + parameter + "='" + newValue + "' WHERE PLANE.ID=" + planeName + "";
                else if (planeParameter.Text == "Capacity" || planeParameter.Text == "Year" || planeParameter.Text == "Manufacturer_ID")
                    command.CommandText = "UPDATE PLANE SET PLANE." + parameter + "=" + newValue + " WHERE PLANE.ID=" + planeName + "";
                else
                    MessageBox.Show("Выберите хоть один параметр для изменения");

                command.ExecuteNonQuery();
                transaction.Commit();
                command.CommandText = "SELECT PLANE.ID, PLANE.Type, PLANE.Model, PLANE.Capacity, PLANE.Year, PLANE.Load_Capacity, PLANE.Maintenance_Date, MANUFACTURER.Name FROM PLANE INNER JOIN MANUFACTURER ON MANUFACTURER.ID=PLANE.Manufacturer_ID";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string type = reader.GetString(1);
                        string model = reader.GetString(2);
                        int capacity = reader.GetInt32(3);
                        int year = reader.GetInt32(4);
                        string loadCapacity = reader.GetString(5);
                        DateTime maintenance = reader.GetDateTime(6);
                        string manufacturer = reader.GetString(7);
                        Plane plane = new Plane(id, type, model, capacity, year, loadCapacity, maintenance, manufacturer);
                        DataGridPlanes.Items.Add(plane);
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
