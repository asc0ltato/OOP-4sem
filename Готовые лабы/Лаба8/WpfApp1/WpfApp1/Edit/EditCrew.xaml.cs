using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace WpfApp1.Edit
{
    public partial class EditCrew : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;
        private CrewMember selectedCrewMember;
        private byte[] selectedImageBytes;

        public EditCrew()
        {
            InitializeComponent();
            LoadCrewMembers();
            crewID.TextChanged += CrewID_TextChanged; 
        }

        private bool ValidateID(string id)
        {
            return Regex.IsMatch(id, @"^\d{1,6}$");
        }

        private void LoadCrewMembers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM CREW_MEMBERS";
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nameSurname = reader.GetString(1);
                        string position = reader.GetString(2);
                        int age = reader.GetInt32(3);
                        int experience = reader.GetInt32(4);
                        int planeID = reader.GetInt32(6);
                        BitmapImage photo = null;

                        if (!reader.IsDBNull(6))
                        {
                            byte[] photoBytes = (byte[])reader["Photo"];
                            using (MemoryStream ms = new MemoryStream(photoBytes))
                            {
                                photo = new BitmapImage();
                                photo.BeginInit();
                                photo.StreamSource = ms;
                                photo.CacheOption = BitmapCacheOption.OnLoad;
                                photo.EndInit();
                            }
                        }

                        CrewMember crew = new CrewMember(id, nameSurname, position, age, experience, photo, planeID);
                        DataGridEditCrew.Items.Add(crew);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки членов экипажа: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.jpeg)|*.jpg; *.png; *.jpeg";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                selectedImage.Source = bitmap;

                selectedImageBytes = ConvertBitmapImageToByteArray(bitmap);
                crewNewParameter.Text = Convert.ToBase64String(selectedImageBytes);
            }
        }

        private void CrewParameter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (crewNewParameter != null && crewParameter.SelectedItem != null && chooseImageButton != null && selectedImage != null)
            {
                crewNewParameter.Text = string.Empty;

                var selectedText = ((ComboBoxItem)crewParameter.SelectedItem).Content.ToString();
                if (selectedText == "Photo")
                {
                    chooseImageButton.Visibility = Visibility.Visible;
                    selectedImage.Visibility = Visibility.Visible;
                }
                else
                {
                    chooseImageButton.Visibility = Visibility.Collapsed;
                    selectedImage.Visibility = Visibility.Collapsed;
                }
            }
        }


        private void CrewNewParameter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (crewParameter.SelectedItem != null && crewNewParameter != null)
            {
                string parameter = ((ComboBoxItem)crewParameter.SelectedItem).Content.ToString();
                string newValue = crewNewParameter.Text;

                if (!ValidateInput(parameter, newValue))
                {
                    crewNewParameter.BorderBrush = Brushes.Red;
                }
                else
                {
                    crewNewParameter.BorderBrush = Brushes.LimeGreen;
                }
            }
        }


        private void ElementToEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string crewIDValue = crewID.Text;

                if (!ValidateID(crewIDValue))
                {
                    MessageBox.Show("ID должен содержать от 1 до 6 цифр.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string parameter = ((ComboBoxItem)crewParameter.SelectedItem).Content.ToString();
                string newValue = crewNewParameter.Text;

                if (!ValidateInput(parameter, newValue))
                {
                    MessageBox.Show("Некорректное значение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();

                    string updateQuery = "";
                    switch (parameter)
                    {
                        case "NameSurname":
                            updateQuery = $"UPDATE CREW_MEMBERS SET NameSurname = '{newValue}' WHERE ID = {crewIDValue}";
                            break;
                        case "Position":
                            updateQuery = $"UPDATE CREW_MEMBERS SET Position = '{newValue}' WHERE ID = {crewIDValue}";
                            break;
                        case "Age":
                            int newBirthYear = int.Parse(newValue);
                            int currentYear = DateTime.Now.Year;
                            int newAge = currentYear - newBirthYear;
                            int currentExperience = GetExperienceFromDatabase(int.Parse(crewIDValue));
                            int earliestExperience = newAge - 18;

                            if (newBirthYear <= currentYear && newAge >= 18 && newAge <= 100 && currentExperience >= 0 && currentExperience <= earliestExperience)
                            {
                                updateQuery = $"UPDATE CREW_MEMBERS SET Age = {newBirthYear} WHERE ID = {crewIDValue}";
                            }
                            else
                            {
                                MessageBox.Show($"Невозможно обновить год рождения до {newBirthYear}, так как это приведет к недопустимой ситуации по возрасту и стажу.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            break;
                        case "Experience":
                            int newExperience;
                            if (int.TryParse(newValue, out newExperience))
                            {
                                int currentAge = DateTime.Now.Year - GetBirthYearFromDatabase(int.Parse(crewIDValue));
                                int maxExperience = currentAge - 18;
                                if (newExperience >= 0 && newExperience <= maxExperience)
                                {
                                    updateQuery = $"UPDATE CREW_MEMBERS SET Experience = {newExperience} WHERE ID = {crewIDValue}";
                                }
                                else
                                {
                                    MessageBox.Show($"Некорректное значение для стажа. Допустимый стаж от 0 до {maxExperience}.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                            }
                            break;
                        case "Plane_ID":
                            updateQuery = $"UPDATE CREW_MEMBERS SET Plane_ID = {newValue} WHERE ID = {crewIDValue}";
                            break;
                        case "Photo":
                            byte[] imageBytes = Convert.FromBase64String(newValue);
                            updateQuery = $"UPDATE CREW_MEMBERS SET Photo = @Photo WHERE ID = {crewIDValue}";
                            command.Parameters.AddWithValue("@Photo", imageBytes);
                            break;
                        default:
                            MessageBox.Show("Некорректный параметр для обновления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                    }

                    command.CommandText = updateQuery;
                    command.ExecuteNonQuery();
                }

                DataGridEditCrew.Items.Clear();
                LoadCrewMembers();

                MessageBox.Show("Данные изменены", "Редактирование данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private int GetBirthYearFromDatabase(int crewId)
        {
            int birthYear = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Age FROM CREW_MEMBERS WHERE ID = @Id";
                    command.Parameters.AddWithValue("@Id", crewId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows && reader.Read())
                    {
                        birthYear = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении года рождения из базы данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return birthYear;
        }

        private int GetAgeFromDatabase(int crewId)
        {
            int age = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Age FROM CREW_MEMBERS WHERE ID = @Id";
                    command.Parameters.AddWithValue("@Id", crewId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows && reader.Read())
                    {
                        age = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении возраста из базы данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return age;
        }


        private bool ValidateInput(string parameter, string value)
        {
            switch (parameter)
            {
                case "NameSurname":
                    if (Regex.IsMatch(value, @"^([\p{L}\p{M}-]+\s){0,2}[\p{L}\p{M}-]+$"))
                    {
                        return true;
                    }
                    break;
                case "Position":
                    if (value == "Стюард" || value == "Пилот")
                    {
                        return true;
                    }
                    break;
                case "Age":
                    int newBirthYear;
                    if (int.TryParse(value, out newBirthYear) && newBirthYear <= DateTime.Now.Year && newBirthYear >= DateTime.Now.Year - 100)
                    {
                        int currentExperience = GetExperienceFromDatabase(int.Parse(crewID.Text));
                        int newAge = DateTime.Now.Year - newBirthYear;
                        if (currentExperience <= newAge - 18)
                        {
                            return true;
                        }
                    }
                    break;
                case "Experience":
                    int newExperience;
                    if (int.TryParse(value, out newExperience))
                    {
                        int currentAge = DateTime.Now.Year - GetBirthYearFromDatabase(int.Parse(crewID.Text));
                        int maxExperience = currentAge - 18;
                        if (newExperience >= 0 && newExperience <= maxExperience)
                        {
                            return true;
                        }
                    }
                    break;
                case "Plane_ID":
                    if (Regex.IsMatch(value, @"^\d{1,6}$"))
                    {
                        return true;
                    }
                    break;
                case "Photo":
                    return true;
                default:
                    return false;
            }
            return false;
        }

        private int GetExperienceFromDatabase(int crewId)
        {
            int experience = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Experience FROM CREW_MEMBERS WHERE ID = @Id";
                    command.Parameters.AddWithValue("@Id", crewId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows && reader.Read())
                    {
                        experience = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении стажа из базы данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return experience;
        }


        private void CrewID_TextChanged(object sender, TextChangedEventArgs e)
        {
            selectedCrewMember = null;
        }

        private void DataGridEditCrew_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridEditCrew.SelectedItem != null)
            {
                selectedCrewMember = DataGridEditCrew.SelectedItem as CrewMember;
                if (selectedCrewMember != null && selectedCrewMember.Photo != null)
                {
                    selectedImage.Source = selectedCrewMember.Photo;
                }
                else
                {
                    selectedImage.Source = null;
                }
            }
            else
            {
                selectedCrewMember = null; 
                selectedImage.Source = null;
            }
        }


        private byte[] ConvertBitmapImageToByteArray(BitmapImage bitmapImage)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(ms);
                return ms.ToArray();
            }
        }
    }
}
