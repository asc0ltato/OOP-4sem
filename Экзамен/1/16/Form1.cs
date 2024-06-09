using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            col = rand.Next(10, 50);
        }

        int col, h, w;
        int horizontal = 0;
        Brush brush = new SolidBrush(Color.DarkRed);

        private void Form1_Paint (object sender, PaintEventArgs e)
        {
            h = e.ClipRectangle.Height;
            w = e.ClipRectangle.Width;

            for (int i = 0; i < col; i++) 
            {
                e.Graphics.FillEllipse(brush, setcoord());
            }
        }

        int prevx = 0, prevy = 0;

        public Rectangle setcoord()
        {
            Rectangle r = new Rectangle();
            r.Width = 20;
            r.Height = 20;

            if(horizontal < w)
            {
                r.X = prevx;
                r.Y = prevy;
                prevx += 35;
                horizontal += 35;
            }
            else
            {
                prevy += 35;
                horizontal = 0;
                prevx = 0;
                r.X = prevx;
                r.Y = prevy;
            }
            return r;
        }
    }
}