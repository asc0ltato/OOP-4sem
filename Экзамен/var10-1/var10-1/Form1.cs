using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace var10_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(textBox1.Text);
                double result = 0;

                if (radioButton1.Checked)
                {
                    result = Math.Sin(x);
                }
                else if (radioButton2.Checked)
                { 
                    result = Math.Cos(x);
                }
                else if (radioButton3.Checked) 
                {
                    result = Math.Tan(x);
                }
                else if (radioButton4.Checked)
                {
                    result = 1 / Math.Tan(x);
                }
                textBox2.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show("Введите корректное значение для х", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBox1.Text);
                double result = 0;

                if (radioButton5.Checked)
                {
                    result = number * 0.3;
                }
                else if (radioButton6.Checked)
                {
                    result = number * 0.5;
                }
                else if (radioButton7.Checked)
                {
                    result = number * 0.7;
                }
                textBox3.Text = result.ToString();
            }
            catch
            {
                MessageBox.Show("Введите корректное значение для х", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(textBox1.Text);
                string result = string.Empty;

                if (radioButton8.Checked)
                {
                    result = Convert.ToString(number,2);
                }
                else if (radioButton9.Checked)
                {
                    result = Convert.ToString(number, 8);
                }
                else if (radioButton10.Checked)
                {
                    result = Convert.ToString(number, 16);
                }
                textBox4.Text = result;
            }
            catch
            {
                MessageBox.Show("Введите корректное значение для х", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}