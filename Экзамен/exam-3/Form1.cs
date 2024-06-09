using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam_3
{
    public partial class Form1 : Form
    {
        private Form2 form2;

        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Show();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           form2.String = textBox1.Text;
        }
    }
}
