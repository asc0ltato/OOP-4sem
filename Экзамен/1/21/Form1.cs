using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 child = new Form2();
            child.MdiParent = this;
            child.Show();

            Form2 child2 = new Form2();
            child2.MdiParent = this;
            child2.Show();
        }

        public void ParentText(string text)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is Form2)
                {
                    ((Form2)f).UpdateText(text);
                }
            }
        }

        public void ParentLabel(string text)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is Form2)
                {
                    ((Form2)f).UpdateLabel(text);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ParentText(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParentLabel(textBox1.Text);
        }
    }
}
