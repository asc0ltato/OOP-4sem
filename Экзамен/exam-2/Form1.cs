using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam_2
{
    public partial class Form1 : Form
    {
        private static string allLetters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧЪЫЬЭЮЯ";
        private static int length = allLetters.Length;
        private static Random random = new Random();
        int rand = random.Next(0, length);

        public Form1()
        {
            InitializeComponent();
            checkLabel.Text = allLetters[rand].ToString();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if(letterTextBox.Text.ToUpper() == allLetters[rand].ToString())
            {
                MessageBox.Show("Угадано");
            }
            else
            {
                MessageBox.Show("Не угадано");

            }
        }
    }
}
