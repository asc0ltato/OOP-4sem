using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int number;

            for (int i = 1; i < 10; i++)
            {
                number = i;
                listBox1.Items.Add(number);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int number = listBox1.SelectedIndex + 2;
            int result = 1;
            for (int i = 1;i < number; i++)
            {
                result *= i;
            }
            label2.Text = result.ToString();
        }
    }
}