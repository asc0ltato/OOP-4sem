using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace OOP_Lab4_5
{
    public partial class MainWindow : Window
    {
        private bool styleCheck = false;
        public MainWindow()
        {
            InitializeComponent();
            InitializeImageEventHandlers();
            var sri = Application.GetResourceStream(new Uri("./Styles/arrow.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;
            App.LanguageChanged += languageChanged;
            CultureInfo currLang = App.Language;
        }

        private void languageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;
        }

        private void buttonRu_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo lang = new CultureInfo("ru-RU");
            App.Language = lang;
        }

        private void buttonEng_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo lang = new CultureInfo("en-US");
            App.Language = lang;
        }

        private void darkTheme_Click(object sender, RoutedEventArgs e)
        {
            if (styleCheck)
            {
                var uri = new Uri("./Styles/BlackTheme.xaml", UriKind.Relative);
                var resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                styleCheck = false;
            }
            else
            {
                var uri = new Uri("./Styles/WhiteTheme.xaml", UriKind.Relative);
                var resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                styleCheck = true;
            }
        }

        private void viewBooks_Click(object sender, RoutedEventArgs e)
        {
            ViewAllBooks viewAllBooks = new ViewAllBooks();
            viewAllBooks.Show();
            this.Close();
        }

        private void InitializeImageEventHandlers()
        {
            Image image = Image; // Замените "YourImageControl" на имя вашего элемента управления Image
            if (image != null)
            {
                image.SizeChanged += Image_SizeChanged;
            }
        }

        private void Image_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Image image = sender as Image;
            if (image != null)
            {
                double maxWidth = 600; // Максимальная ширина изображения
                if (image.ActualWidth >= maxWidth)
                {
                    MessageBox.Show("Максимальная ширина изображения достигнута!");
                }
            }
        }

    }
}