using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(Width + 100, Height + 100);
        }

        private void Form1_MouseUp(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(Width - 100, Height - 100);
        }
    }
}
