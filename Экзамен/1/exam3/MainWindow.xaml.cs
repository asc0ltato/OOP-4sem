using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace exam3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Counter.Visibility = Visibility.Hidden;
        }

        public bool style = true;
        public bool counterVisible = false;
        public int counter = 0;

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (counterVisible)
            {
                Counter.Visibility = Visibility.Visible;

                if (counter % 2 == 0)
                {
                    Counter.Foreground = Brushes.Red;
                }
                else
                {
                    Counter.Foreground = Brushes.Gray;
                }
            } 
            else
            {
                Counter.Visibility= Visibility.Visible;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (!style)
            {
                btn1.Style = FindResource("ButtonStyle") as Style;
            }
            else
            {
                btn1.Style = FindResource("ButtonStyleTwo") as Style;
            }
            style = !style;

            counter++;
            Counter.Content = counter;
        }
    }
}