using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp1.Add
{
    /// <summary>
    /// Логика взаимодействия для PlaneElement.xaml
    /// </summary>
    public partial class PlaneElement : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;
        string radioButtonModel;
        bool isSortedAscending = true;

        public PlaneElement()
        {
            InitializeComponent();
            LoadPlanesData();
        }

        private void LoadPlanesData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT PLANE.ID, PLANE.Type, PLANE.Model, PLANE.Capacity, PLANE.Year, PLANE.Load_Capacity, PLANE.Maintenance_Date FROM PLANE";
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
                            Plane plane = new Plane(id, type, model, capacity, year, loadCapacity, maintenance);
                            DataGridPlanes.Items.Add(plane);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddPlaneButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateFields())
            {
                MessageBox.Show("Пожалуйста, заполните все поля правильно.", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = transaction;

                    command.CommandText = "INSERT INTO PLANE (ID, Type, Model, Capacity, Year, Load_Capacity, Maintenance_Date) VALUES (@ID, @Type, @Model, @Capacity, @Year, @LoadCapacity, @MaintenanceDate)";
                    command.Parameters.AddWithValue("@ID", Convert.ToInt32(planeID.Text));
                    command.Parameters.AddWithValue("@Type", Convert.ToString(planeType.Text));
                    command.Parameters.AddWithValue("@Model", radioButtonModel);
                    command.Parameters.AddWithValue("@Capacity", Convert.ToInt32(planeCapacity.Text));
                    command.Parameters.AddWithValue("@Year", Convert.ToInt32(planeYear.Text));
                    command.Parameters.AddWithValue("@LoadCapacity", planeLoadCapacity.Text);
                    command.Parameters.AddWithValue("@MaintenanceDate", Convert.ToDateTime(planeMDate.Text));
                    command.ExecuteNonQuery();
                    transaction.Commit();

                    DataGridPlanes.Items.Clear();
                    LoadPlanesData();

                    MessageBox.Show("Данные добавлены", "Добавление данных", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateFields()
        {
            bool isValid = true;
            int currentYear = DateTime.Now.Year;

            if (!Regex.IsMatch(planeID.Text, @"^\d{1,6}$"))
            {
                planeID.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                planeID.BorderBrush = Brushes.LimeGreen;
            }

            if (!Regex.IsMatch(planeCapacity.Text, @"^\d{1,3}$") || Convert.ToInt32(planeCapacity.Text) > 300)
            {
                planeCapacity.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                planeCapacity.BorderBrush = Brushes.LimeGreen;
            }

            if (!Regex.IsMatch(planeYear.Text, @"^\d{4}$") || Convert.ToInt32(planeYear.Text) < 1900 || Convert.ToInt32(planeYear.Text) > currentYear)
            {
                planeYear.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                planeYear.BorderBrush = Brushes.LimeGreen;
            }

            string input = planeLoadCapacity.Text.Replace(',', '.');

            if (!Regex.IsMatch(input, @"^\d{1,3}(\.\d+)?$"))
            {
                planeLoadCapacity.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                if (Decimal.TryParse(input, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal result))
                {
                    if (result <= 300)
                    {
                        planeLoadCapacity.BorderBrush = Brushes.LimeGreen;
                    }
                    else
                    {
                        planeLoadCapacity.BorderBrush = Brushes.Red;
                        isValid = false;
                    }
                }
                else
                {
                    planeLoadCapacity.BorderBrush = Brushes.Red;
                    isValid = false;
                }
            }

            DateTime maintenanceDate;
            if (!DateTime.TryParse(planeMDate.Text, out maintenanceDate) || maintenanceDate.Year < Convert.ToInt32(planeYear.Text) || maintenanceDate.Year > currentYear)
            {
                planeMDate.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                planeMDate.BorderBrush = Brushes.LimeGreen;
            }

            return isValid;
        }

        private void rbAirbus_Checked(object sender, RoutedEventArgs e) => radioButtonModel = "Airbus";
        private void rbBoeing_Checked(object sender, RoutedEventArgs e) => radioButtonModel = "Boeing";

        private void planeID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(planeID.Text, @"^\d{1,6}$"))
            {
                planeID.BorderBrush = Brushes.Red;
            }
            else
            {
                planeID.BorderBrush = Brushes.LimeGreen;
            }
        }

        private void planeCapacity_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(planeCapacity.Text, @"^\d{1,3}$") || Convert.ToInt32(planeCapacity.Text) > 300)
            {
                planeCapacity.BorderBrush = Brushes.Red;
            }
            else
            {
                planeCapacity.BorderBrush = Brushes.LimeGreen;
            }
        }

        private void planeYear_LostFocus(object sender, RoutedEventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            if (!Regex.IsMatch(planeYear.Text, @"^\d{4}$") || Convert.ToInt32(planeYear.Text) < 1900 || Convert.ToInt32(planeYear.Text) > currentYear)
            {
                planeYear.BorderBrush = Brushes.Red;
            }
            else
            {
                planeYear.BorderBrush = Brushes.LimeGreen;
            }
        }

        private void planeLoadCapacity_LostFocus(object sender, RoutedEventArgs e)
        {
            string input = planeLoadCapacity.Text.Replace(',', '.');

            if (!Regex.IsMatch(input, @"^\d{1,3}(\.\d+)?$"))
            {
                planeLoadCapacity.BorderBrush = Brushes.Red;
            }
            else
            {
                if (Decimal.TryParse(input, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal result))
                {
                    if (result <= 300)
                    {
                        planeLoadCapacity.BorderBrush = Brushes.LimeGreen;
                    }
                    else
                    {
                        planeLoadCapacity.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    planeLoadCapacity.BorderBrush = Brushes.Red;
                }
            }
        }

        private void planeMDate_LostFocus(object sender, RoutedEventArgs e)
        {
            DateTime maintenanceDate;
            int currentYear = DateTime.Now.Year;
            if (!DateTime.TryParse(planeMDate.Text, out maintenanceDate) || maintenanceDate.Year < Convert.ToInt32(planeYear.Text) || maintenanceDate.Year > currentYear)
            {
                planeMDate.BorderBrush = Brushes.Red;
            }
            else
            {
                planeMDate.BorderBrush = Brushes.LimeGreen;
            }
        }

        private void SortPlanesByYearButton_Click(object sender, RoutedEventArgs e)
        {
            if (isSortedAscending)
            {
                var sortedPlanes = DataGridPlanes.Items.Cast<Plane>().OrderBy(p => p.Year).ToList();
                DataGridPlanes.Items.Clear();
                foreach (var plane in sortedPlanes)
                {
                    DataGridPlanes.Items.Add(plane);
                }
            }
            else
            {
                var sortedPlanes = DataGridPlanes.Items.Cast<Plane>().OrderByDescending(p => p.Year).ToList();
                DataGridPlanes.Items.Clear();
                foreach (var plane in sortedPlanes)
                {
                    DataGridPlanes.Items.Add(plane);
                }
            }
            isSortedAscending = !isSortedAscending;
        }
    }
}