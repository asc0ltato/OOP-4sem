using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Configuration;
using System.Text.RegularExpressions;

namespace WpfApp1.Remove
{
    /// <summary>
    /// Логика взаимодействия для RemoveElementForm.xaml
    /// </summary>
    public partial class RemoveElementForm : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;

        public RemoveElementForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow element = new MainWindow();
            element.Show();
            this.Close();
        }

        private bool ValidateID(string id)
        {
            return Regex.IsMatch(id, @"^\d{1,6}$");
        }

        private void IDToRemove_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(IDToRemove.Text, @"^\d{1,6}$"))
            {
                IDToRemove.BorderBrush = Brushes.Red;
            }
            else
            {
                IDToRemove.BorderBrush = Brushes.LimeGreen;
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tableName = Convert.ToString(ElementToRemoveBox.Text);
                string idName = Convert.ToString(IDToRemove.Text);
                int planeRowCount = 0, planeRowCountNew = 0;

                if (!ValidateID(idName))
                {
                    MessageBox.Show("ID должен содержать от 1 до 6 цифр.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                command.CommandText = "SELECT COUNT(*) FROM " + tableName + "";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        planeRowCount = reader.GetInt32(0);
                    }
                reader.Close();

                command.CommandText = "DELETE FROM " + tableName + " WHERE ID=" + idName + "";
                command.ExecuteNonQuery();
                transaction.Commit();
                command.CommandText = "SELECT COUNT(*) FROM " + tableName + "";
                SqlDataReader readerNew = command.ExecuteReader();
                if (readerNew.HasRows)
                    while (readerNew.Read())
                    {
                        planeRowCountNew = readerNew.GetInt32(0);
                    }

                if (planeRowCount == planeRowCountNew)
                    MessageBox.Show("Элемента с таким ID не существует", "Удаление данных", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show("Данные удалены", "Удаление данных", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception x)
            {
                MessageBox.Show($"Ошибка: {x.Message}", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}