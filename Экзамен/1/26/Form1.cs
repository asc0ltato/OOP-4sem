using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value == 1) 
            {
                pictureBox1.Image = new Bitmap(@"D:\Программы\Фотографии\15fda545373abf0b624756bd39f0c428.jpg");
            }
            else if (numericUpDown1.Value == 2) 
            {
                pictureBox1.Image = new Bitmap(@"D:\Программы\Фотографии\51b0dd2d8a9d1013c593e07340e555c4.jpg");
            }
            else if (numericUpDown1.Value == 3)
            {
                pictureBox1.Image = new Bitmap(@"D:\Программы\Фотографии\78e31aca33a2d759dec1b4c896490b1d.jpg");
            }
        }
    }
}
