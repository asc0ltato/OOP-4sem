using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            comboBox2 = new ComboBox();
            label4 = new Label();
            trackBar1 = new TrackBar();
            label6 = new Label();
            label7 = new Label();
            trackBar2 = new TrackBar();
            dateTimePicker1 = new DateTimePicker();
            label8 = new Label();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            listBox1 = new ListBox();
            button3 = new Button();
            label5 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            поискToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(139, 47);
            textBox1.MaxLength = 0;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(322, 27);
            textBox1.TabIndex = 0;
            textBox1.Text = "1";
            // 
            // label1
            // 
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(27, 20);
            label1.TabIndex = 1;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.Location = new Point(6, 83);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 1;
            label2.Text = "Тип:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Пассажирский", "Военный", "Грузовой" });
            comboBox1.Location = new Point(139, 95);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(322, 28);
            comboBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.Location = new Point(6, 126);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 3;
            label3.Text = "Модель";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "SkyWings", "AeroJet", "BlueBird Airlines", "Airwave", "Starflyer", "Velocity Airways", "Jetset Airlines", "Nimbus Aviation", "Oceanic Air", "Skyline Express" });
            comboBox2.Location = new Point(139, 138);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(322, 28);
            comboBox2.TabIndex = 4;
            // 
            // label4
            // 
            label4.Location = new Point(6, 173);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 5;
            label4.Text = "Экипаж";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(132, 245);
            trackBar1.Maximum = 200;
            trackBar1.Minimum = 10;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(322, 56);
            trackBar1.TabIndex = 7;
            trackBar1.TickFrequency = 10;
            trackBar1.Value = 10;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label6
            // 
            label6.Location = new Point(6, 243);
            label6.Name = "label6";
            label6.Size = new Size(120, 51);
            label6.TabIndex = 9;
            label6.Text = "Пассажирские места - 10";
            // 
            // label7
            // 
            label7.Location = new Point(6, 294);
            label7.Name = "label7";
            label7.Size = new Size(120, 47);
            label7.TabIndex = 10;
            label7.Text = "Грузоподъемность - 1";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(132, 294);
            trackBar2.Maximum = 100;
            trackBar2.Minimum = 1;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(322, 56);
            trackBar2.TabIndex = 11;
            trackBar2.TickFrequency = 10;
            trackBar2.Value = 1;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(132, 389);
            dateTimePicker1.MaxDate = new DateTime(2024, 3, 5, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(322, 27);
            dateTimePicker1.TabIndex = 12;
            dateTimePicker1.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.Location = new Point(6, 347);
            label8.Name = "label8";
            label8.Size = new Size(120, 42);
            label8.TabIndex = 13;
            label8.Text = "Год выпуска";
            // 
            // button1
            // 
            button1.Location = new Point(110, 504);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 14;
            button1.Text = "Write JSON";
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(235, 504);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 15;
            button2.Text = "Read JSON";
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(maskedTextBox1);
            groupBox1.Controls.Add(trackBar1);
            groupBox1.Controls.Add(trackBar2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(11, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(502, 472);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Самолет";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(240, 173);
            listBox1.Name = "listBox1";
            listBox1.SelectionMode = SelectionMode.None;
            listBox1.Size = new Size(210, 64);
            listBox1.TabIndex = 16;
            // 
            // button3
            // 
            button3.Location = new Point(128, 173);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 15;
            button3.Text = "Добавить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.Location = new Point(6, 389);
            label5.Name = "label5";
            label5.Size = new Size(120, 71);
            label5.TabIndex = 14;
            label5.Text = "Последнее техническое обслуживание";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(134, 344);
            maskedTextBox1.Mask = "0000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(49, 27);
            maskedTextBox1.TabIndex = 12;
            maskedTextBox1.TextAlign = HorizontalAlignment.Center;
            maskedTextBox1.ValidatingType = typeof(DateTime);
            maskedTextBox1.MaskInputRejected += maskedTextBox1_MaskInputRejected;
            maskedTextBox1.KeyPress += maskedTextBox1_KeyPress;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(32, 19);
            // 
            // поискToolStripMenuItem
            // 
            поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            поискToolStripMenuItem.Size = new Size(32, 19);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 551);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
        private ComboBox comboBox2;
        private Label label4;
        private TrackBar trackBar1;
        private Label label6;
        private Label label7;
        private TrackBar trackBar2;
        private DateTimePicker dateTimePicker1;
        private Label label8;
        private Button button1;
        private Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaskedTextBox maskedTextBox1;
        private Label label5;
        private Button button3;
        private ListBox listBox1;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem поискToolStripMenuItem;
    }
}
