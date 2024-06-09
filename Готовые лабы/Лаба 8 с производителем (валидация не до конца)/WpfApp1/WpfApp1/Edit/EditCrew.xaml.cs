using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
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
            if (crewParameter.SelectedItem != null)
            {
                var selectedText = ((TextBlock)crewParameter.SelectedItem).Text;
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

        private void ElementToEditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string crewIDValue = crewID.Text;

                    if (!ValidateID(crewIDValue))
                    {
                        MessageBox.Show("ID должен содержать от 1 до 6 цифр.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    string parameter = ((TextBlock)crewParameter.SelectedItem).Text;
                    string newValue = crewNewParameter.Text;

                    connection.Open();
                    SqlCommand command = connection.CreateCommand();

                    string sqlCommand;
                    if (parameter == "NameSurname" || parameter == "Position")
                    {
                        sqlCommand = $"UPDATE CREW_MEMBERS SET {parameter} = @Value WHERE ID = @ID";
                    }
                    else if (parameter == "Age" || parameter == "Experience" || parameter == "Plane_ID")
                    {
                        sqlCommand = $"UPDATE CREW_MEMBERS SET {parameter} = @ValueInt WHERE ID = @ID";
                    }
                    else if (parameter == "Photo")
                    {
                        sqlCommand = $"UPDATE CREW_MEMBERS SET Photo = @ValueBlob WHERE ID = @ID";
                    }
                    else
                    {
                        throw new ArgumentException("Выберите хотя бы один параметр для изменения");
                    }

                    command.CommandText = sqlCommand;
                    command.Parameters.AddWithValue("@ID", crewIDValue);
                    if (parameter == "Age" || parameter == "Experience" || parameter == "Plane_ID")
                    {
                        command.Parameters.AddWithValue("@ValueInt", int.Parse(newValue));
                    }
                    else if (parameter == "Photo")
                    {
                        if (selectedImageBytes != null && selectedImageBytes.Length > 0)
                        {
                            command.Parameters.AddWithValue("@ValueBlob", selectedImageBytes);
                        }
                        else
                        {
                            throw new ArgumentException("Выберите изображение");
                        }
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Value", newValue);
                    }

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные изменены", "Изменение данных", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGridEditCrew.Items.Clear();
                        LoadCrewMembers();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось изменить данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
