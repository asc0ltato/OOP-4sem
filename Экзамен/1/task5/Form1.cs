using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("txt.txt"))
            {
                sw.WriteLine(textBox1.Text);
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("txt.txt"))
            {
                string line = reader.ReadLine();
                textBox2.Text = line;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("xml.xml"))
            {
                string text = textBox3.Text;
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(string));
                xmlSerializer.Serialize(sw, text);
                textBox3.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("xml.xml"))
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(string));
                string xml = (string)xmlSerializer.Deserialize(sr);
                textBox4.Text = xml;
            }
        }
    }
}
