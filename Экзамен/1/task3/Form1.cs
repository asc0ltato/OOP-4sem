using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task3
{
    public partial class Form1 : Form
    {
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width / 2,
                Screen.PrimaryScreen.WorkingArea.Height / 2);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width / 2,
                Screen.PrimaryScreen.WorkingArea.Height / 2);
            timer.Stop();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Size = new System.Drawing.Size((int)(this.Width * 0.9), (int)(this.Height * 0.9));
                timer.Start();
            }
        }
    }
}
