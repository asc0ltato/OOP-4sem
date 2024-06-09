namespace exam_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.checkLabel = new System.Windows.Forms.Label();
            this.checkButton = new System.Windows.Forms.Button();
            this.letterTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 230);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Проверка буквы:  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkLabel
            // 
            this.checkLabel.AutoSize = true;
            this.checkLabel.Location = new System.Drawing.Point(157, 230);
            this.checkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.checkLabel.Name = "checkLabel";
            this.checkLabel.Size = new System.Drawing.Size(0, 16);
            this.checkLabel.TabIndex = 1;
            this.checkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(95, 123);
            this.checkButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(156, 43);
            this.checkButton.TabIndex = 2;
            this.checkButton.Text = "check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // letterTextBox
            // 
            this.letterTextBox.Location = new System.Drawing.Point(20, 76);
            this.letterTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.letterTextBox.Name = "letterTextBox";
            this.letterTextBox.Size = new System.Drawing.Size(313, 22);
            this.letterTextBox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 257);
            this.Controls.Add(this.letterTextBox);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.checkLabel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label checkLabel;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.TextBox letterTextBox;
    }
}

