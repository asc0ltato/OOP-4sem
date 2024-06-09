using System;
using System.Collections.Generic;
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
        private Stack<Library> undoStack = new Stack<Library>();
        private Stack<Library> redoStack = new Stack<Library>();


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
            string searchText = searchBox.myTextBox.Text.ToLower();

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
            undoStack.Push(new Library(_listOfBooks));
            AddingBook book = new AddingBook(_listOfBooks, undoStack, redoStack);
            book.Closed += (s, args) =>
            {
                tableView.ItemsSource = _listOfBooks.booksList;
                tableView.Items.Refresh();
                redoStack.Push(new Library(_listOfBooks));
            };
            book.Show();
        }

        private void CommandBinding_Executed_3(object sender, RoutedEventArgs e)
        {
            Library oldList = new Library();
            foreach (var book in _listOfBooks.booksList)
            {
                Book originalBook = new Book(book.Title, book.Author, book.Genre, book.InStock, book.Rating, book.Photo);
                oldList.booksList.Add(originalBook);
            }
            undoStack.Push(oldList);
            var bookEdit = (Book)tableView.SelectedItem;
            if (bookEdit != null)
            {
                RedactingBook edit = new RedactingBook(bookEdit, _listOfBooks, undoStack, redoStack)
                {
                    Owner = this 
                };
                if (edit.ShowDialog() == true)
                {
                    bookEdit.Title = edit.bookName.Text;
                    bookEdit.Author = edit.bookAuthor.Text;
                    bookEdit.Genre = edit.genre.Text;
                    bookEdit.InStock = int.Parse(edit.in_stock.Text);
                    bookEdit.Rating = edit.rating.Text;
                    bookEdit.Photo = edit.preview.Source.ToString();

                    tableView.ItemsSource = _listOfBooks.booksList;
                    tableView.Items.Refresh(); 
                }
            }
        }


        private void CommandBinding_Executed_4(object sender, RoutedEventArgs e)
        {
            Book selectedBook = (Book)tableView.SelectedItem;
            if (selectedBook != null)
            {
                undoStack.Push(new Library(_listOfBooks));
                _listOfBooks.booksList.Remove(selectedBook);
                tableView.ItemsSource = _listOfBooks.booksList;
                DataTransfer.SerializeBooks(_listOfBooks);
                tableView.Items.Refresh();
                MessageBox.Show($"Книга удалена", "Успешно!", MessageBoxButton.OK);
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

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(new Library(_listOfBooks)); 
                _listOfBooks = undoStack.Pop();
                tableView.ItemsSource = _listOfBooks.booksList;
                tableView.Items.Refresh();
            }
        }

        private void redoButton_Click(object sender, RoutedEventArgs e)
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(new Library(_listOfBooks)); 
                _listOfBooks = redoStack.Pop(); 
                tableView.ItemsSource = _listOfBooks.booksList;
                tableView.Items.Refresh();
            }
        }
    }
}