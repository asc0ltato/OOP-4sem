using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Random rand = new Random();
            int x = rand.Next(Screen.PrimaryScreen.WorkingArea.Width - this.Width);
            int y = rand.Next(Screen.PrimaryScreen.WorkingArea.Height - this.Height);

            this.Location = new Point(x, y);
        }
    }
}
