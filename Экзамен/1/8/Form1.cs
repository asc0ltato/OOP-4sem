using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();

            Random random = new Random();
            int count = random.Next(10, 21);
            List<int> numbers = new List<int>();

            int maxNumber, maxNumberId;
            for (int i = 0; i < count; i++)
            {
                int number = random.Next(100, 1001);
                numbers.Add(number);
                listBox1.Items.Add(number);
                listBox2.Items.Add(i);
            }

            maxNumber = numbers.Max();
            maxNumberId = numbers.IndexOf(maxNumber);
            textBox1.Text = maxNumber.ToString();
            textBox2.Text = maxNumberId.ToString();
        }
    }
}
