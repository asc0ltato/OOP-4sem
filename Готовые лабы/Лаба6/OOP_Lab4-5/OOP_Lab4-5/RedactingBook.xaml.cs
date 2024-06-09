using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;
using OOP_Lab4_5.Classes;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.Generic;

namespace OOP_Lab4_5
{
    public partial class RedactingBook : Window
    {
        private Book _book;
        public Library _booksList;
        public OpenFileDialog openFileDialog;
        private Stack<Library> undoStack;
        private Stack<Library> redoStack;

        public RedactingBook(Book book, Library currentBooksList, Stack<Library> undoStack, Stack<Library> redoStack)
        {
            InitializeComponent();
            _book = book;
            _booksList = currentBooksList;
            this.undoStack = undoStack;
            this.redoStack = redoStack;
            var sri = Application.GetResourceStream(new Uri("./Styles/arrow.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;
            FillFields();
        }

        private void FillFields()
        {
            if (_book != null)
            {
                bookName.Text = _book.Title;
                bookAuthor.Text = _book.Author;
                genre.Text = _book.Genre;
                in_stock.Text = _book.InStock.ToString();
                rating.Text = _book.Rating;

                if (!string.IsNullOrEmpty(_book.Photo))
                {
                    try
                    {
                        preview.Source = new BitmapImage(new Uri(_book.Photo));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                    }
                }
            }
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(bookName.Text) || string.IsNullOrEmpty(bookAuthor.Text) ||
                    string.IsNullOrEmpty(genre.Text) || string.IsNullOrEmpty(in_stock.Text) ||
                    string.IsNullOrEmpty(rating.Text))
                {
                    MessageBox.Show($"Заполните все поля.", "Ошибка!", MessageBoxButton.OK);
                    return;
                }

                if (openFileDialog != null && !string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    _book.Photo = openFileDialog.FileName;
                    try
                    {
                        preview.Source = new BitmapImage(new Uri(_book.Photo));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                        return;
                    }
                }
                _book.Title = bookName.Text;
                _book.Author = bookAuthor.Text;
                _book.Genre = genre.Text;
                _book.InStock = int.Parse(in_stock.Text);
                _book.Rating = rating.Text;

                DataTransfer.SerializeBooks(_booksList);
                DialogResult = true;

                MessageBox.Show($"Название: {bookName.Text}\n" +
                    $"Автор: {bookAuthor.Text}\nЖанр: {genre.Text}" +
                    $"\nВ наличии: {in_stock.Text}\nРейтинг: " +
                    $"{rating.Text}\nПуть к фото: {_book.Photo}",
                    "Книга изменена", MessageBoxButton.OK);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка при добавлении книги.", "Ошибка!", MessageBoxButton.OK);
            }
        }


        private void addPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    preview.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                }
                catch
                {
                    MessageBox.Show("Выберите файл подходящего формата.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            bookName.Text = "";
            bookAuthor.Text = "";
            genre.Text = "";
            in_stock.Text = "";
            rating.Text = "";
            preview.Source = null;
        }

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.Text, 0) && e.Text != " " && e.Text != "-" && e.Text != "!" && e.Text != "?" && e.Text != ".")
            {
                e.Handled = true;
            }
        }

        private void textBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0) && e.Text != " " && e.Text != "-")
            {
                e.Handled = true;
            }
        }

        private void textBox3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox4_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void textBox5_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }

            if (!e.Handled)
            {
                string newText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
                if (!string.IsNullOrEmpty(newText))
                {
                    if (!double.TryParse(newText, out double value) || value > 10)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
