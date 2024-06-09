using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Configuration;
using Microsoft.Win32;
using System.IO;
using System.Data;

namespace WpfApp1.Add
{
    /// <summary>
    /// Логика взаимодействия для CrewElement.xaml
    /// </summary>
    public partial class CrewElement : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;
        private byte[] currentImageBytes;

        public CrewElement()
        {
            InitializeComponent();
        }

        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    BitmapImage image = new BitmapImage(new Uri(openFileDialog.FileName));
                    crewPhoto.Source = image;

                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        encoder.Save(memoryStream);
                        currentImageBytes = memoryStream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка выбора изображения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CrewElement_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM CREW_MEMBERS";
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nameSurname = reader.GetString(1);
                            string position = reader.GetString(2);
                            int age = reader.GetInt32(3);
                            int experience = reader.GetInt32(4);
                            int planeID = reader.GetInt32(6);
                            BitmapImage photo = null;
                            if (!reader.IsDBNull(5))
                            {
                                byte[] photoBytesFromDb = (byte[])reader["Photo"];
                                using (MemoryStream memoryStream = new MemoryStream(photoBytesFromDb))
                                {
                                    photo = new BitmapImage();
                                    photo.BeginInit();
                                    photo.CacheOption = BitmapCacheOption.OnLoad;
                                    photo.StreamSource = memoryStream;
                                    photo.EndInit();
                                }
                            }
                            CrewMember crew = new CrewMember(id, nameSurname, position, age, experience, photo, planeID);
                            DataGridCrew.Items.Add(crew);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка загрузки данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddCrewMemberButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridCrew.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = transaction;

                    if (ValidateFields())
                    {
                        byte[] photoBytes = null;
                        if (crewPhoto.Source != null)
                        {
                            BitmapImage image = (BitmapImage)crewPhoto.Source;
                            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(image));
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                encoder.Save(memoryStream);
                                photoBytes = memoryStream.ToArray();
                            }
                        }

                        command.CommandText = "INSERT INTO CREW_MEMBERS (ID, Name_Surname, Position, Age, Experience, Photo, Plane_ID) VALUES (@id, @nameSurname, @position, @age, @experience, @photo, @planeID)";
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(crewID.Text));
                        command.Parameters.AddWithValue("@nameSurname", Convert.ToString(crewFIO.Text));
                        command.Parameters.AddWithValue("@position", Convert.ToString(crewPosition.Text));
                        command.Parameters.AddWithValue("@age", Convert.ToInt32(crewBirthYear.Text));
                        command.Parameters.AddWithValue("@experience", Convert.ToInt32(crewExperience.Text));
                        command.Parameters.AddWithValue("@photo", (object)photoBytes ?? DBNull.Value);
                        command.Parameters.AddWithValue("@planeID", Convert.ToInt32(crewPlaneID.Text));
                        command.ExecuteNonQuery();
                        transaction.Commit();

                        DataGridCrew.Items.Clear();
                        command.CommandText = "SELECT * FROM CREW_MEMBERS";
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nameSurname = reader.GetString(1);
                                string position = reader.GetString(2);
                                int age = reader.GetInt32(3);
                                int experience = reader.GetInt32(4);
                                int planeID = reader.GetInt32(6);
                                BitmapImage photo = null;
                                if (!reader.IsDBNull(5))
                                {
                                    byte[] photoBytesFromDb = (byte[])reader["Photo"];
                                    using (MemoryStream memoryStream = new MemoryStream(photoBytesFromDb))
                                    {
                                        photo = new BitmapImage();
                                        photo.BeginInit();
                                        photo.CacheOption = BitmapCacheOption.OnLoad;
                                        photo.StreamSource = memoryStream;
                                        photo.EndInit();
                                    }
                                }
                                CrewMember crew = new CrewMember(id, nameSurname, position, age, experience, photo, planeID);
                                DataGridCrew.Items.Add(crew);
                            }
                        }
                        MessageBox.Show("Данные добавлены", "Добавление данных", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, заполните все поля правильно.", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void crewID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(crewID.Text, @"^\d{1,6}$"))
                crewID.BorderBrush = Brushes.Red;
            else
                crewID.BorderBrush = Brushes.LimeGreen;
        }

        private void crewPlaneID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(crewPlaneID.Text, @"^\d{1,6}$"))
                crewPlaneID.BorderBrush = Brushes.Red;
            else
                crewPlaneID.BorderBrush = Brushes.LimeGreen;
        }

        private void crewFIO_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(crewFIO.Text, @"^([\p{L}\p{M}-]+\s){0,2}[\p{L}\p{M}-]+$"))
                crewFIO.BorderBrush = Brushes.Red;
            else
                crewFIO.BorderBrush = Brushes.LimeGreen;
        }

        private void crewBirthYear_LostFocus(object sender, RoutedEventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            if (!Regex.IsMatch(crewBirthYear.Text, @"^\d{4}$") || Convert.ToInt32(crewBirthYear.Text) > currentYear - 18)
                crewBirthYear.BorderBrush = Brushes.Red;
            else
                crewBirthYear.BorderBrush = Brushes.LimeGreen;
        }

        private void crewExperience_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(crewExperience.Text, @"^\d{1,2}$"))
                crewExperience.BorderBrush = Brushes.Red;
            else
                crewExperience.BorderBrush = Brushes.LimeGreen;
        }

        private bool ValidateFields()
        {
            bool isValid = true;

            int currentYear = DateTime.Now.Year;
            int age = currentYear - Convert.ToInt32(crewBirthYear.Text);
            int experience = Convert.ToInt32(crewExperience.Text);

            if (!Regex.IsMatch(crewID.Text, @"^\d{1,6}$"))
            {
                crewID.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                crewID.BorderBrush = Brushes.LimeGreen;
            }

            if (!Regex.IsMatch(crewPlaneID.Text, @"^\d{1,6}$"))
            {
                crewPlaneID.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                crewPlaneID.BorderBrush = Brushes.LimeGreen;
            }

            if (!Regex.IsMatch(crewFIO.Text, @"^([\p{L}\p{M}-]+\s){0,2}[\p{L}\p{M}-]+$"))
            {
                crewFIO.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                crewFIO.BorderBrush = Brushes.LimeGreen;
            }

            if (!Regex.IsMatch(crewBirthYear.Text, @"^\d{4}$") || age < 18)
            {
                crewBirthYear.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                crewBirthYear.BorderBrush = Brushes.LimeGreen;
            }

            if (!Regex.IsMatch(crewExperience.Text, @"^\d{1,2}$"))
            {
                crewExperience.BorderBrush = Brushes.Red;
                isValid = false;
            }
            else
            {
                crewExperience.BorderBrush = Brushes.LimeGreen;
            }

            int minimumExperience = 0;
            int maximumExperience = age - 18;
            if (experience < minimumExperience || experience > maximumExperience)
            {
                crewExperience.BorderBrush = Brushes.Red;
                isValid = false;
                MessageBox.Show($"При возрасте {age} лет стаж должен быть в диапазоне от {minimumExperience} до {maximumExperience} лет", "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                crewExperience.BorderBrush = Brushes.LimeGreen;
            }

            return isValid;
        }
    }
}
