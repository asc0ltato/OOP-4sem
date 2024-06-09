using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OOP_Lab4_5.Classes;

namespace OOP_Lab4_5
{
    public partial class ViewAllBooks : Window
    {
        private Library _listOfBooks;

        public ViewAllBooks()
        {
            InitializeComponent();
            _listOfBooks = DataTransfer.DeserializeBooks();
            tableView.ItemsSource = _listOfBooks.booksList;
            var sri = Application.GetResourceStream(new Uri("./Styles/arrow.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CommandBinding_Executed_1(object sender, RoutedEventArgs e)
        {
            _listOfBooks = DataTransfer.DeserializeBooks();
            var library = new Library();
            string searchText = searchBox.Text.ToLower();

            foreach (var item in _listOfBooks.booksList)
            {
                string title = item.Title.ToLower();
                string pattern = @"\b" + searchText + @"\w*";

                if (Regex.IsMatch(title, pattern, RegexOptions.IgnoreCase))
                {
                    library.booksList.Add(item);
                }
            }
            tableView.ItemsSource = library.booksList;
        }


        private void CommandBinding_Executed_2(object sender, RoutedEventArgs e)
        {
            AddingBook book = new AddingBook();
            book.Closed += (s, args) =>
            {
                _listOfBooks = DataTransfer.DeserializeBooks(); 
                tableView.ItemsSource = _listOfBooks.booksList;
                tableView.Items.Refresh(); 
            };
            book.Show();
        }

        private void CommandBinding_Executed_3(object sender, RoutedEventArgs e)
        {
            var bookEdit = (Book)tableView.SelectedItem;
            if (bookEdit != null)
            {
                RedactingBook edit = new RedactingBook(bookEdit);
                edit.Owner = this;
                if (edit.ShowDialog() == false)
                {
                    bookEdit.Title = edit.bookName.Text;
                    bookEdit.Author = edit.bookAuthor.Text;
                    bookEdit.Genre = edit.genre.Text;
                    bookEdit.InStock = int.Parse(edit.in_stock.Text);
                    bookEdit.Rating = edit.rating.Text;
                    bookEdit.Photo = edit.preview.Source.ToString();

                    tableView.Items.Refresh();

                    DataTransfer.SerializeBooks(_listOfBooks);
                }
            }
        }


        private void CommandBinding_Executed_4(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book)tableView.SelectedItem;
            if (selectedBook != null)
            {
                _listOfBooks.booksList.Remove(selectedBook);
                tableView.ItemsSource = _listOfBooks.booksList;
                DataTransfer.SerializeBooks(_listOfBooks);
                MessageBox.Show("Книга удалена.", "Успешно!", MessageBoxButton.OK);
                tableView.Items.Refresh();
            }
        }

        private void CommandBinding_Executed_5(object sender, RoutedEventArgs e)
        {
            _listOfBooks = DataTransfer.DeserializeBooks();
            tableView.ItemsSource = _listOfBooks.booksList;
        }

        private void CommandBinding_Executed_6(object sender, RoutedEventArgs e)
        {
            _listOfBooks = DataTransfer.DeserializeBooks();
            var library = new Library();

            foreach (var item in _listOfBooks.booksList)
                if (item.Genre == comboBoxFilterSelect.Text)
                    library.booksList.Add(item);

            tableView.ItemsSource = library.booksList;
        }

        private void tableView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (tableView.SelectedItem != null)
            {
                Book selectedBook = (Book)tableView.SelectedItem;
                BookDetailsWindow bookDetailsWindow = new BookDetailsWindow(selectedBook);
                bookDetailsWindow.Owner = this;
                bookDetailsWindow.Show();
            }
        }
    }
}