using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OOP_Lab4_5
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent MouseDownEvent = EventManager.RegisterRoutedEvent(
            "MouseDown",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(UserControl4));

        public static readonly RoutedEvent PreviewMouseMoveEvent = EventManager.RegisterRoutedEvent(
            "PreviewMouseMove",
            RoutingStrategy.Tunnel,
            typeof(RoutedEventHandler),
            typeof(UserControl4));

        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
            "Click",
            RoutingStrategy.Direct,
            typeof(RoutedEventHandler),
            typeof(UserControl4));

        public event RoutedEventHandler PreviewMouseMove
        {
            add { AddHandler(PreviewMouseMoveEvent, value); }
            remove { RemoveHandler(PreviewMouseMoveEvent, value); }
        }

        public event RoutedEventHandler MouseDown
        {
            add { AddHandler(MouseDownEvent, value); }
            remove { RemoveHandler(MouseDownEvent, value); }
        }

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (directRad.IsChecked == true)
            {
                MessageBox.Show("Жук Светлана" + '\n' + sender.ToString() + '\n' + e.Source.ToString() + "\n\n", "Информация об авторе-Direct");
            }
        }

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (bubbleRad.IsChecked == true)
            {
                MessageBox.Show("Жук Светлана" + '\n' + sender.ToString() + '\n' + e.Source.ToString() + "\n\n", "Информация об авторе-Bubble");
            }
        }

        private void Control_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (tunnleRad.IsChecked == true)
            {
                MessageBox.Show("Жук Светлана" + '\n' + sender.ToString() + '\n' + e.Source.ToString() + "\n\n", "Информация об авторе-Tunnle");
            }
        }
    }
}
