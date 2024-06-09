using System.Data;
using System.Text;

namespace WinFormsApp2
{
    public partial class Form3 : Form
    {
        Flights flights = new Flights();
        IEnumerable<Plane> ordered;
        private string lastAction = "";

        public Form3()
        {
            lastAction = "Действие не выполнялось";
            InitializeComponent();
            DisplayPlanesInRichTextBox(flights.GetStringForPrintByFilters(textBox1, textBox2, textBox4, textBox5));
            ordered = flights.GetFlights();
            timer1.Start();
        }

        private void UpdateLastAction(string action)
        {
            lastAction = action;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            ordered = flights.GetStringForPrintByFilters(textBox1, textBox2, textBox4, textBox5);
            DisplayPlanesInRichTextBox(ordered);
        }

        private void DisplayPlanesInRichTextBox(IEnumerable<Plane> planes)
        {
            StringBuilder sb = new StringBuilder();
            if (planes != null)
            {
                foreach (Plane plane in planes)
                {
                    sb.Append(plane.ToString());
                }
                richTextBox1.Text = sb.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"Текущее время: {DateTime.Now}";
            toolStripStatusLabel2.Text = $"Текущее кол-во элементов {ordered.Count()}";
            toolStripStatusLabel3.Text = $"Последнее выполненное действие: {lastAction}";
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Flights.JsonSerelization(ordered, DateTime.Now.ToString());
            DisplayPlanesInRichTextBox(ordered);

            UpdateLastAction("Данные сохранены в JSON");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = !toolStrip1.Visible;

            button1.Text = toolStrip1.Visible ? "-" : "+";
        }

        private void годуВыпускаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ordered = flights.GetStringForPrintByFilters(textBox1, textBox2, textBox4, textBox5).OrderBy(p => p.YearOfManufacture);

            DisplayPlanesInRichTextBox(ordered);
            UpdateLastAction("Сортировка по году выпуска");
        }

        private void датеПоследнегоТехОбслуживанияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ordered = flights.GetStringForPrintByFilters(textBox1, textBox2, textBox4, textBox5).OrderBy(p => p.TechnicalInspection);

            DisplayPlanesInRichTextBox(ordered);
            UpdateLastAction("Сортировка по дате последнего тех. обслуживания");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            UpdateLastAction("Поля очищены");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            flights.Delete();
            ordered = flights.GetFlights();
            DisplayPlanesInRichTextBox(ordered);
            UpdateLastAction("Данные удалены");
        }

        private void ScrollUp()
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.ScrollToCaret();
        }

        private void ScrollDown()
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ScrollUp();
            UpdateLastAction("Сработал скролл вверх");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ScrollDown();
            UpdateLastAction("Сработал скролл вниз");
        }

    }
}