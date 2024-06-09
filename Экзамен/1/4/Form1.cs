using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.MaxLength = 12;
            textBox2.MaxLength = 12;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            string snovapassword = textBox2.Text;

            if (password.Length < 6)
            {
                MessageBox.Show("Длина должна быть в пределах 6-12");
            }
            else if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                MessageBox.Show("Пароль должен содержать и символы и числа");
            }
            else if (password != snovapassword)
            {
                MessageBox.Show("Пароли не совпадают");
            }
        }
    }
}