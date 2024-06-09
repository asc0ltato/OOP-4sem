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

namespace exam_6
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Line line = new Line
            {
                X1 = 10,
                Y1 = 10,
                X2 = 100,
                Y2 = 100,
                StrokeThickness = 3,
                Stroke = Brushes.Red
            };
            Canvas.SetLeft(line, 50);
            Canvas.SetTop(line, 50);
            output.Children.Add(line);
            Line line2 = new Line
            {
                X1 = 10,
                Y1 = 10,
                X2 = 100,
                Y2 = 100,
                Stroke = Brushes.Orange,
                StrokeThickness = 3,
                StrokeDashArray = new DoubleCollection { 4, 2 }
            };
            Canvas.SetLeft(line2, 100);
            Canvas.SetTop(line2, 50);
            output.Children.Add(line2);
            Line line3 = new Line
            {
                X1 = 10,
                Y1 = 10,
                X2 = 100,
                Y2 = 100,
                Stroke = Brushes.Green,
                StrokeThickness = 3,
                StrokeDashArray = new DoubleCollection { 1, 5 }
            };
            Canvas.SetLeft(line3, 150);
            Canvas.SetTop(line3, 50);
            output.Children.Add(line3);
            Polyline polyline = new Polyline
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 3
            };
            for (int i = 0; i < 70; i++)
            {
                double x = i * Math.PI;
                double y = 40 + 30 * Math.Sin(x / 10);
                polyline.Points.Add(new Point(x, y));
            }
            Canvas.SetLeft(polyline, 250);
            Canvas.SetTop(polyline, 50);
            output.Children.Add(polyline);
            Polyline polyline2 = new Polyline
            {
                Stroke = Brushes.Purple,
                StrokeThickness = 3
            };
            for (int i = 0; i < 50; i++)
            {
                double y = i * Math.PI;
                double x = 10* Math.Sin(y / 2);
                polyline2.Points.Add(new Point(x, y));
            }
            Canvas.SetLeft(polyline2, 500);
            Canvas.SetTop(polyline2, 50);
            output.Children.Add(polyline2);
        }
    }
}