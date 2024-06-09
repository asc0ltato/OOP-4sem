using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        private int quartLoc = 1;
        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width / 2, 
                Screen.PrimaryScreen.WorkingArea.Height / 2);
            Location = new Point(0, 0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                switch (quartLoc)
                {
                    case 1:
                        Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, 0);
                        break;
                    case 2:
                        Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, 
                            Screen.PrimaryScreen.WorkingArea.Height / 2);
                        break;
                    case 3:
                        Location = new Point(0, Screen.PrimaryScreen.WorkingArea.Height / 2);
                        break;
                    case 4:
                        Location = new Point(0, 0);
                        break;
                }
                if (++quartLoc > 4)
                {
                    quartLoc = 1;
                }
            }
        }
    }
}
