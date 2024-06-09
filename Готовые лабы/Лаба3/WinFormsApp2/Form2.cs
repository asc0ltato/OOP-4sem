namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        private bool isJobTitle1Selected;
        private bool isJobTitle2Selected;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fullName = textBox1.Text;
            string ageText = textBox2.Text;
            string seniorityText = textBox3.Text;

            isJobTitle1Selected = radioButton1.Checked;
            isJobTitle2Selected = radioButton2.Checked;

            if (!isJobTitle1Selected && !isJobTitle2Selected)
            {
                MessageBox.Show("Пожалуйста, выберите должность.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(ageText) || string.IsNullOrEmpty(seniorityText))
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(ageText, out int age) || age < 18)
            {
                MessageBox.Show("Возраст должен быть целым числом и не менее 18.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(seniorityText, out int seniority) || seniority < 0 || seniority > (age - 18))
            {
                MessageBox.Show($"Стаж должен быть целым числом от 0 до {age - 18}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            form1.SetJobTitle(isJobTitle1Selected, isJobTitle2Selected);

            Worker worker = new Worker(fullName, isJobTitle1Selected ? radioButton1.Text : radioButton2.Text, age, seniority);
            form1.AddWorkerToList(worker);
            this.Close();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
