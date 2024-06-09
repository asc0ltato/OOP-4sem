using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void сортироватьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var items = listBox1.Items.Cast<string>().ToList();
            items.Sort();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(items.ToArray());
        }

        private void удалитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
