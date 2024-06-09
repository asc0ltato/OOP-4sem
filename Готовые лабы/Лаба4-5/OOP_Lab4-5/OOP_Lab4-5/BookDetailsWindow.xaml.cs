using OOP_Lab4_5.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP_Lab4_5
{
    public partial class BookDetailsWindow : Window
    {
        public BookDetailsWindow(Book selectedBook)
        {
            InitializeComponent();
            DataContext = selectedBook;
        }
    }
}
