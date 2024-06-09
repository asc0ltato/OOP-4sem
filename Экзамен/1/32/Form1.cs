using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _32
{
    public partial class Form1 : Form
    {
        Timer timer;
        int check = 1;

        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (check)
            {
                case 1:
                    checkBox1.Checked = true;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    break;
                case 2:
                    checkBox1.Checked = false;
                    checkBox2.Checked = true;
                    checkBox3.Checked = false;
                    break;
                case 3:
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = true;
                    break;
            }
            check++;
            if(check > 3)
            {
                check = 1;
            }
        }
    }
}
