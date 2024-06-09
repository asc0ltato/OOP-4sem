using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string part1 = textBox1.Text.Substring(0, textBox1.Text.Length / 2);
                string part2 = textBox1.Text.Substring(textBox1.Text.Length / 2);
                textBox1.Text = part1;
                label2.Text = part2;
            }
        }
    }
}