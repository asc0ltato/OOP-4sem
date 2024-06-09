using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.DayOfWeek.ToString();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.DayOfYear.ToString();
        }
    }
}
