using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ВАРИАНТ 1
// разработайте программу на c# winforms.
// на форме разместите компонент DateTimePicker.
// по выбраннуму времени в DateTimePicker
// в строке состояния должно выводится
// сообщение "до полудня" или "после полудня"
namespace var1_exam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string message = dateTimePicker1.Value.Hour < 12 ? "До полудня" : "После полудня";
            toolStripStatusLabel1.Text = message;
        }
    }
}
