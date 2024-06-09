namespace WinFormsApp2
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            годуВыпускаToolStripMenuItem1 = new ToolStripMenuItem();
            датеПоследнегоТехОбслуживанияToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(545, 0);
            button1.Name = "button1";
            button1.Size = new Size(30, 27);
            button1.TabIndex = 1;
            button1.Text = "-";
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.Click += button1_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(551, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { годуВыпускаToolStripMenuItem1, датеПоследнегоТехОбслуживанияToolStripMenuItem1 });
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(135, 24);
            toolStripDropDownButton1.Text = "Сортировать по";
            // 
            // годуВыпускаToolStripMenuItem1
            // 
            годуВыпускаToolStripMenuItem1.Name = "годуВыпускаToolStripMenuItem1";
            годуВыпускаToolStripMenuItem1.Size = new Size(343, 26);
            годуВыпускаToolStripMenuItem1.Text = "Году выпуска";
            годуВыпускаToolStripMenuItem1.Click += годуВыпускаToolStripMenuItem1_Click;
            // 
            // датеПоследнегоТехОбслуживанияToolStripMenuItem1
            // 
            датеПоследнегоТехОбслуживанияToolStripMenuItem1.Name = "датеПоследнегоТехОбслуживанияToolStripMenuItem1";
            датеПоследнегоТехОбслуживанияToolStripMenuItem1.Size = new Size(343, 26);
            датеПоследнегоТехОбслуживанияToolStripMenuItem1.Text = "Дате последнего тех. обслуживания";
            датеПоследнегоТехОбслуживанияToolStripMenuItem1.Click += датеПоследнегоТехОбслуживанияToolStripMenuItem1_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(138, 24);
            toolStripButton1.Text = "Сохранить в JSON";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(77, 24);
            toolStripButton2.Text = "Очистить";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(69, 24);
            toolStripButton3.Text = "Удалить";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(55, 24);
            toolStripButton4.Text = "Назад";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // toolStripButton5
            // 
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(64, 24);
            toolStripButton5.Text = "Вперёд";
            toolStripButton5.Click += toolStripButton5_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(437, 49);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(620, 426);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(163, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(226, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(163, 100);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(226, 27);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(163, 146);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(226, 27);
            textBox4.TabIndex = 3;
            textBox4.TextChanged += textBox4_TextChanged;
            textBox4.KeyPress += textBox4_KeyPress;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(163, 197);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(226, 27);
            textBox5.TabIndex = 4;
            textBox5.TextChanged += textBox5_TextChanged;
            textBox5.KeyPress += textBox5_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 52);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 5;
            label1.Text = "Авиакомпания";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 103);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 6;
            label2.Text = "Тип";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 149);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 7;
            label3.Text = "Количество мест";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 200);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 8;
            label4.Text = "Грузоподъемность";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel2, toolStripStatusLabel3, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 502);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1086, 26);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(151, 20);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(151, 20);
            toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 528);
            Controls.Add(button1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(richTextBox1);
            Name = "Form3";
            Text = "Form3";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn name;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem годуВыпускаToolStripMenuItem1;
        private ToolStripMenuItem датеПоследнегоТехОбслуживанияToolStripMenuItem1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private Button button1;
        private ToolStripStatusLabel toolStripStatusLabel3;
    }
}