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

namespace exam_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int previousCount = 0;
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int count;
            if (int.TryParse(input.Text, out count))
            {
                if (count < previousCount) // это в случае если количество кружков введется меньше чем было
                {
                    for (int i = count; i < previousCount; i++)
                    {
                        output.Children.RemoveAt(count);
                    }
                }

                for (int i = previousCount; i < count; i++) // это наоборот
                {
                    Ellipse circle = new Ellipse
                    {
                        Width = 50,
                        Height = 50,
                        Fill = Brushes.HotPink
                    };
                    Canvas.SetLeft(circle, 50 + i * 60);
                    Canvas.SetTop(circle, 50);
                    output.Children.Add(circle);
                }
                previousCount = count;
            }
        }
    }
}