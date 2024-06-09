namespace _18
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Свердлова, 13");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Немига, 25");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Минск", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Первомайская, 31");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Ленинская, 23");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Брест", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Адреса", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(54, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Узел2";
            treeNode1.Text = "Свердлова, 13";
            treeNode2.Name = "Узел3";
            treeNode2.Text = "Немига, 25";
            treeNode3.Name = "Узел1";
            treeNode3.Text = "Минск";
            treeNode4.Name = "Узел5";
            treeNode4.Text = "Первомайская, 31";
            treeNode5.Name = "Узел6";
            treeNode5.Text = "Ленинская, 23";
            treeNode6.Name = "Узел4";
            treeNode6.Text = "Брест";
            treeNode7.Name = "Узел0";
            treeNode7.Text = "Адреса";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView1.Size = new System.Drawing.Size(339, 228);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 292);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(339, 22);
            this.textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 369);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

