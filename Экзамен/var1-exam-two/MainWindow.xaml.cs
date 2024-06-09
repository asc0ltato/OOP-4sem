using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace var1_exam_two
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadData(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "SELECT * FROM STUDENTS WHERE COURSE = 1";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(sqlDataReader);
                    dataGrid.ItemsSource = dataTable.DefaultView;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
