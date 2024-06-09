using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22
{
    public partial class Form1 : Form
    {//включить AllowDrop
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.DoDragDrop(textBox.Text, DragDropEffects.Copy);
        }

        private void textBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBox_DragDrop(object sender, DragEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = (string)e.Data.GetData(DataFormats.Text);
        }
    }
}
