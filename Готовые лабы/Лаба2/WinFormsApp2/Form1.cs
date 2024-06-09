using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private List<Plane> planes = new List<Plane>();
        private List<Worker> workerList = new List<Worker>();
        public bool IsJobTitle1Selected { get; set; }
        public bool IsJobTitle2Selected { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        public void SetJobTitle(bool isJobTitle1Selected, bool isJobTitle2Selected)
        {
            IsJobTitle1Selected = isJobTitle1Selected;
            IsJobTitle2Selected = isJobTitle2Selected;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = "Пассажирские места - " + trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label7.Text = "Грузоподъемность - " + trackBar2.Value.ToString();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Некорректный ввод. Пожалуйста, введите год в формате YYYY.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(maskedTextBox1.Text, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime maskedDate))
            {
                string id = textBox1.Text;

                if (planes.Any(p => p.ID == id))
                {
                    MessageBox.Show("Такой ID уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Worker> crewList = new List<Worker>();
                foreach (var item in listBox1.Items)
                {
                    if (item is Worker worker)
                    {
                        crewList.Add(worker);
                    }
                }

                if (dateTimePicker1.Value.Year < maskedDate.Year)
                {
                    MessageBox.Show("Год последнего технического обслуживания не может быть раньше года выпуска.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Plane pl = new Plane(textBox1.Text, comboBox1.Text, comboBox2.Text, crewList, trackBar1.Value, trackBar2.Value, maskedDate, dateTimePicker1.Value);
                planes.Add(pl);
                var validationContext = new ValidationContext(pl, null, null);
                var validationResults = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(pl, validationContext, validationResults, true);
            }
            else
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void AddWorkerToList(Worker work)
        {
            workerList.Add(work);
            listBox1.Items.Add(work);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText("plane.json");
            MessageBox.Show(json);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.Show();
        }
    }
}