using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1.Edit
{
    public partial class EditPlane : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;

        public EditPlane()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

                if (!CheckIfIdExists(int.Parse(planeName)))
                {
                    MessageBox.Show("ID не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string parameter = ((ComboBoxItem)planeParameter.SelectedItem).Content.ToString();
                string newValue = planeNewParameter.Text;

                if (!ValidateInput(parameter, newValue))
                {
                    MessageBox.Show("Некорректное значение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UpdatePlane";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", int.Parse(planeName));
                    command.Parameters.AddWithValue("@Param", parameter);
                    command.Parameters.AddWithValue("@Value", newValue);

                    command.ExecuteNonQuery();
                }

                DataGridPlanes.Items.Clear();
                LoadDataGrid();

                MessageBox.Show("Данные изменены", "Редактирование данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PlaneParameter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (planeNewParameter != null)
            {
                planeNewParameter.Text = string.Empty;
                planeNewParameter.BorderBrush = Brushes.Black; 
            }
        }

        private void PlaneNewParameter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (planeParameter.SelectedItem != null && planeNewParameter != null)
            {
                string parameter = ((ComboBoxItem)planeParameter.SelectedItem).Content.ToString();
                string newValue = planeNewParameter.Text;

                if (!ValidateInputWithoutMessage(parameter, newValue))
                {
                    planeNewParameter.BorderBrush = Brushes.Red;
                }
                else
                {
                    planeNewParameter.BorderBrush = Brushes.LimeGreen;
                }
            }
        }

        private bool ValidateInput(string parameter, string value)
        {
            switch (parameter)
            {
                case "Year":
                    if (int.TryParse(value, out int year) && year >= 1900 && year <= DateTime.Now.Year)
                    {
                        DateTime currentMaintenanceDate = GetCurrentMaintenanceDate(int.Parse(planeID.Text));
                        if (currentMaintenanceDate.Year >= year)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show($"Год создания не может быть больше года последнего ТО ({currentMaintenanceDate.Year}).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    break;
                case "Capacity":
                    if (int.TryParse(value, out int capacity) && capacity >= 1 && capacity <= 300)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное числовое значение для вместимости от 1 до 300.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                case "Type":
                    string[] validTypes = { "Пассажирский", "Военный", "Грузовой" };
                    if (Array.Exists(validTypes, type => type.Equals(value, StringComparison.OrdinalIgnoreCase)) &&
                        Regex.IsMatch(value, @"^[а-яА-Яa-zA-Z]+$"))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное значение для типа (Пассажирский, Военный, Грузовой).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                case "Model":
                    string[] validModels = { "Airbus", "Boeing" };
                    if (Array.Exists(validModels, model => model.Equals(value, StringComparison.OrdinalIgnoreCase)) &&
                        Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное значение для модели (Airbus, Boeing).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                case "Load_Capacity":
                    if (decimal.TryParse(value.Replace('.', ','), out decimal loadCapacity) && loadCapacity >= 0 && loadCapacity <= 300)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Введите корректное числовое значение для грузоподъемности от 0 до 300.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                case "Maintenance_Date":
                    if (DateTime.TryParse(value, out DateTime maintenanceDate))
                    {
                        if (maintenanceDate.Year <= DateTime.Now.Year)
                        {
                            DateTime currentMaintenanceDate = GetCurrentMaintenanceDate(int.Parse(planeID.Text));
                            if (maintenanceDate >= currentMaintenanceDate)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show($"Дата техобслуживания не может быть меньше текущей даты ({currentMaintenanceDate.ToShortDateString()}).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Дата последнего ТО не может быть больше текущего года.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                    break;
                default:
                    return false;
            }
            return false;
        }

        private bool ValidateInputWithoutMessage(string parameter, string value)
        {
            switch (parameter)
            {
                case "Year":
                    return int.TryParse(value, out int year) && year >= 1900 && year <= DateTime.Now.Year;
                case "Capacity":
                    return int.TryParse(value, out int capacity) && capacity >= 1 && capacity <= 300;
                case "Type":
                    string[] validTypes = { "Пассажирский", "Военный", "Грузовой" };
                    return Array.Exists(validTypes, type => type.Equals(value, StringComparison.OrdinalIgnoreCase)) &&
                        Regex.IsMatch(value, @"^[а-яА-Яa-zA-Z]+$");
                case "Model":
                    string[] validModels = { "Airbus", "Boeing" };
                    return Array.Exists(validModels, model => model.Equals(value, StringComparison.OrdinalIgnoreCase)) &&
                        Regex.IsMatch(value, @"^[a-zA-Z]+$");
                case "Load_Capacity":
                    return decimal.TryParse(value.Replace('.', ','), out decimal loadCapacity) && loadCapacity >= 0 && loadCapacity <= 300;
                case "Maintenance_Date":
                    return DateTime.TryParse(value, out DateTime maintenanceDate) && maintenanceDate.Year <= DateTime.Now.Year;
                default:
                    return false;
            }
        }

        private DateTime GetCurrentMaintenanceDate(int planeId)
        {
            DateTime currentMaintenanceDate = DateTime.MinValue;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Maintenance_Date FROM PLANE WHERE ID = @Id";
                    command.Parameters.AddWithValue("@Id", planeId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows && reader.Read())
                    {
                        currentMaintenanceDate = reader.GetDateTime(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении даты последнего ТО: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return currentMaintenanceDate;
        }

        private bool CheckIfIdExists(int planeId)
        {
            bool idExists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT COUNT(*) FROM PLANE WHERE ID = @Id";
                    command.Parameters.AddWithValue("@Id", planeId);
                    idExists = (int)command.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке существования ID: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return idExists;
        }
    }
}