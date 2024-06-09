using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam_3
{
    public partial class Form2 : Form
    {
        public string String { 
            set 
            { 
                label1.Text = value; 
            } 
        }

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string str)
        {
            InitializeComponent();
            String = str;
        }
    }
}
