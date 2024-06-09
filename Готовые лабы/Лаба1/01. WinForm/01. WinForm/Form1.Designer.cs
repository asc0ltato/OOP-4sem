namespace _01._WinForm
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button7 = new Button();
            button8 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            panel1 = new Panel();
            textBox4 = new TextBox();
            button5 = new Button();
            button6 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(47, 234);
            button1.Name = "button1";
            button1.Size = new Size(75, 75);
            button1.TabIndex = 0;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click +=  new System.EventHandler (this.button1_Click);
            // 
            // button2
            // 
            button2.Location = new Point(128, 234);
            button2.Name = "button2";
            button2.Size = new Size(75, 75);
            button2.TabIndex = 1;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            button3.Location = new Point(47, 393);
            button3.Name = "button3";
            button3.Size = new Size(75, 75);
            button3.TabIndex = 2;
            button3.Text = "/";
            button3.UseVisualStyleBackColor = true;
            button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            button4.Location = new Point(128, 393);
            button4.Name = "button4";
            button4.Size = new Size(75, 75);
            button4.TabIndex = 3;
            button4.Text = "*";
            button4.UseVisualStyleBackColor = true;
            button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            button7.Location = new Point(128, 315);
            button7.Name = "button7";
            button7.Size = new Size(75, 75);
            button7.TabIndex = 5;
            button7.Text = "//";
            button7.UseVisualStyleBackColor = true;
            button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button8
            // 
            button8.Location = new Point(47, 315);
            button8.Name = "button8";
            button8.Size = new Size(75, 75);
            button8.TabIndex = 4;
            button8.Text = "%";
            button8.UseVisualStyleBackColor = true;
            button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(60, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(209, 27);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += new System.EventHandler(this.Check);
            textBox1.Leave += new System.EventHandler(this.Change);
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Enabled = false;
            textBox2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(13, 42);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(209, 23);
            textBox2.TabIndex = 7;
            textBox2.Text = "+";
            textBox2.TextAlign = HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Window;
            textBox3.Location = new Point(13, 68);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(209, 27);
            textBox3.TabIndex = 8;
            textBox3.TextChanged += new System.EventHandler(this.Check);
            textBox3.Leave += new System.EventHandler(this.Change);
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Location = new Point(47, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(237, 141);
            panel1.TabIndex = 9;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.Location = new Point(13, 101);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(209, 20);
            textBox4.TabIndex = 9;
            textBox4.TextAlign = HorizontalAlignment.Right;
            // 
            // button5
            // 
            button5.Location = new Point(209, 315);
            button5.Name = "button5";
            button5.Size = new Size(75, 153);
            button5.TabIndex = 10;
            button5.Text = "=";
            button5.UseVisualStyleBackColor = true;
            button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            button6.Location = new Point(209, 234);
            button6.Name = "button6";
            button6.Size = new Size(75, 75);
            button6.TabIndex = 11;
            button6.Text = "C";
            button6.UseVisualStyleBackColor = true;
            button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button9
            // 
            button9.Location = new Point(47, 190);
            button9.Name = "button9";
            button9.Size = new Size(75, 38);
            button9.TabIndex = 12;
            button9.Text = "MRC";
            button9.UseVisualStyleBackColor = true;
            button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            button10.Location = new Point(128, 190);
            button10.Name = "button10";
            button10.Size = new Size(75, 38);
            button10.TabIndex = 13;
            button10.Text = "MR+";
            button10.UseVisualStyleBackColor = true;
            button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            button11.Location = new Point(209, 190);
            button11.Name = "button11";
            button11.Size = new Size(75, 38);
            button11.TabIndex = 14;
            button11.Text = "MR-";
            button11.UseVisualStyleBackColor = true;
            button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(333, 500);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(textBox1);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Calculator";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button7;
        private Button button8;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Panel panel1;
        private TextBox textBox4;
        private Button button5;
        private Button button6;
        private Button button9;
        private Button button10;
        private Button button11;
    }
}