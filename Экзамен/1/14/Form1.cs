using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Day.ToString() + " День";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Month.ToString() + " Месяц";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Year.ToString() + " Год";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Minute.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(button5_Click);
            timer.Interval = 1000;
            timer.Start();
            label2.Text = DateTime.Now.ToString();
        }
    }
}
