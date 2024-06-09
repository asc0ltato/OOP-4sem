using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            listBox1.ClearSelected();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(10);
            listBox1.Items.Add(10);
            listBox1.Items.Add(10);
            textBox1.Text = listBox1.Items.Count.ToString();
        }
    }
}
