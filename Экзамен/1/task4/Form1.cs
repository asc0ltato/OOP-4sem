using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4
{
    public partial class Form1 : Form
    {
        private List<People> peopleList;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            People people = new People {Name = textBox1.Text, Age = textBox2.Text};
            peopleList.Add(people);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                peopleList.
            }
        }
    }

    public class People
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
