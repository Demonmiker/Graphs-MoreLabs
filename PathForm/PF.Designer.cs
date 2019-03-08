namespace PathForm
{
    partial class PF
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
            this.btn__OK = new System.Windows.Forms.Button();
            this.tb_From = new System.Windows.Forms.TextBox();
            this.tb_To = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn__OK
            // 
            this.btn__OK.Location = new System.Drawing.Point(335, 54);
            this.btn__OK.Name = "btn__OK";
            this.btn__OK.Size = new System.Drawing.Size(113, 21);
            this.btn__OK.TabIndex = 0;
            this.btn__OK.Text = "Ok";
            this.btn__OK.UseVisualStyleBackColor = true;
            this.btn__OK.Click += new System.EventHandler(this.btn__OK_Click);
            // 
            // tb_From
            // 
            this.tb_From.Location = new System.Drawing.Point(133, 24);
            this.tb_From.Name = "tb_From";
            this.tb_From.Size = new System.Drawing.Size(119, 20);
            this.tb_From.TabIndex = 2;
            // 
            // tb_To
            // 
            this.tb_To.Location = new System.Drawing.Point(335, 24);
            this.tb_To.Name = "tb_To";
            this.tb_To.Size = new System.Drawing.Size(113, 20);
            this.tb_To.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Найти путь из";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "в - >";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Алгоритм:";
            // 
            // cb
            // 
            this.cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb.FormattingEnabled = true;
            this.cb.Items.AddRange(new object[] {
            "Дейкстра",
            "Дейкстра(с двоичной кучей)"});
            this.cb.Location = new System.Drawing.Point(102, 54);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(227, 21);
            this.cb.TabIndex = 7;
            // 
            // PF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 91);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_To);
            this.Controls.Add(this.tb_From);
            this.Controls.Add(this.btn__OK);
            this.Name = "PF";
            this.Text = "Поиск пути";
            this.Shown += new System.EventHandler(this.PF_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn__OK;
        private System.Windows.Forms.TextBox tb_From;
        private System.Windows.Forms.TextBox tb_To;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb;
    }
}

