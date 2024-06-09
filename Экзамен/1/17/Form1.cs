using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string str1 = "", str2 = "";
            foreach (char c in input)
            {
                if (Char.IsDigit(c))
                {
                    str1 += c;
                } 
                else if (Char.IsLetter(c))
                {
                    str2 += c;
                }
            }
            this.Text = this.Name + str1;
            toolStripStatusLabel1.Text = str2;
        }
    }
}
