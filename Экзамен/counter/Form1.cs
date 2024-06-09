using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace counter
{
    public partial class Form1 : Form
    {
        private int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton1.Text = $"Counter: {counter}";
        }

        private void IncrementCounter()
        {
            counter++;
            toolStripButton1.Text = $"Counter: {counter}";
        }

        private void button1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncrementCounter();
        }

        private void button2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncrementCounter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter++;
            toolStripButton1.Text = $"Counter: {counter}";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            counter++;
            toolStripButton1.Text = $"Counter: {counter}";
        }
    }
}
