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
    public partial class AddingBook : Window
    {
        private Book _book;
        public Library _booksList;
        private OpenFileDialog openFileDialog;
        private Stack<Library> undoStack;
        private Stack<Library> redoStack;

        public AddingBook(Library currentBooksList, Stack<Library> undoStack, Stack<Library> redoStack)
        {
            InitializeComponent();
            _book = new Book();
            this.undoStack = undoStack;
            this.redoStack = redoStack;
            _booksList = currentBooksList;
            var sri = Application.GetResourceStream(new Uri("./Styles/arrow.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                undoStack.Push(new Library(_booksList));
                _book = new Book(bookName.Text, bookAuthor.Text, genre.Text,
                int.Parse(in_stock.Text), rating.Text, openFileDialog.FileName);
                _booksList.Add(_book);
                DataTransfer.SerializeBooks(_booksList);

                MessageBox.Show($"Название: {bookName.Text}\n" +
                   $"Автор: {bookAuthor.Text}\nЖанр: {genre.Text}" +
                   $"\nВ наличии: {in_stock.Text}\nРейтинг: " +
                   $"{rating.Text}\nПуть к фото: {openFileDialog.FileName}",
                   "Книга добавлена", MessageBoxButton.OK);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show($"Заполните все поля.", "Ошибка!", MessageBoxButton.OK);
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