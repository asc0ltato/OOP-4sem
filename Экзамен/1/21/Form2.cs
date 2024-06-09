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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.Parent is  Form1 form) 
            {
                form.ParentText(textBox1.Text);
            }
        }

        public void UpdateText(string text)
        {
            textBox1.Text = text;
        }

        public void UpdateLabel (string label)
        {
            label1.Text = label;
        }
    }
}
