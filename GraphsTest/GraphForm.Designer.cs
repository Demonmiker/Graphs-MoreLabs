﻿namespace GraphsTest
{
    partial class GraphForm
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
            this.components = new System.ComponentModel.Container();
            this.Render = new System.Windows.Forms.Timer(this.components);
            this.ContextNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TsTbName = new System.Windows.Forms.ToolStripTextBox();
            this.ContextEmpty = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инструментыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показыватьВесаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.убратьВесаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.двойнаяСвязьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поискПутиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContexLink = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsLinkDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TsLinktb = new System.Windows.Forms.ToolStripTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_Left = new System.Windows.Forms.Button();
            this.btn_Right = new System.Windows.Forms.Button();
            this.lb_PathNum = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.ContextNode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ContexLink.SuspendLayout();
            this.SuspendLayout();
            // 
            // Render
            // 
            this.Render.Interval = 1;
            this.Render.Tick += new System.EventHandler(this.Render_Tick);
            // 
            // ContextNode
            // 
            this.ContextNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsDelete,
            this.TsTbName});
            this.ContextNode.Name = "ContextNode";
            this.ContextNode.Size = new System.Drawing.Size(161, 51);
            this.ContextNode.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.ContextNode_Closed);
            this.ContextNode.Opening += new System.ComponentModel.CancelEventHandler(this.ContextNode_Opening);
            // 
            // TsDelete
            // 
            this.TsDelete.Name = "TsDelete";
            this.TsDelete.Size = new System.Drawing.Size(160, 22);
            this.TsDelete.Text = "Удалить";
            this.TsDelete.Click += new System.EventHandler(this.TsDelete_Click);
            // 
            // TsTbName
            // 
            this.TsTbName.Name = "TsTbName";
            this.TsTbName.Size = new System.Drawing.Size(100, 23);
            this.TsTbName.Tag = "";
            // 
            // ContextEmpty
            // 
            this.ContextEmpty.Name = "ContextEmpty";
            this.ContextEmpty.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.инструментыToolStripMenuItem,
            this.поискПутиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(858, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.loadToolStripMenuItem.Text = "Загрузить";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // инструментыToolStripMenuItem
            // 
            this.инструментыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показыватьВесаToolStripMenuItem,
            this.убратьВесаToolStripMenuItem,
            this.двойнаяСвязьToolStripMenuItem});
            this.инструментыToolStripMenuItem.Name = "инструментыToolStripMenuItem";
            this.инструментыToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.инструментыToolStripMenuItem.Text = "Инструменты";
            // 
            // показыватьВесаToolStripMenuItem
            // 
            this.показыватьВесаToolStripMenuItem.Checked = true;
            this.показыватьВесаToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.показыватьВесаToolStripMenuItem.Name = "показыватьВесаToolStripMenuItem";
            this.показыватьВесаToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.показыватьВесаToolStripMenuItem.Text = "Показывать Веса";
            this.показыватьВесаToolStripMenuItem.Click += new System.EventHandler(this.показыватьВесаToolStripMenuItem_Click);
            // 
            // убратьВесаToolStripMenuItem
            // 
            this.убратьВесаToolStripMenuItem.Name = "убратьВесаToolStripMenuItem";
            this.убратьВесаToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.убратьВесаToolStripMenuItem.Text = "Убрать Веса";
            this.убратьВесаToolStripMenuItem.Click += new System.EventHandler(this.убратьВесаToolStripMenuItem_Click);
            // 
            // двойнаяСвязьToolStripMenuItem
            // 
            this.двойнаяСвязьToolStripMenuItem.Name = "двойнаяСвязьToolStripMenuItem";
            this.двойнаяСвязьToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.двойнаяСвязьToolStripMenuItem.Text = "Двойная связь";
            this.двойнаяСвязьToolStripMenuItem.Click += new System.EventHandler(this.двойнаяСвязьToolStripMenuItem_Click);
            // 
            // поискПутиToolStripMenuItem
            // 
            this.поискПутиToolStripMenuItem.Name = "поискПутиToolStripMenuItem";
            this.поискПутиToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.поискПутиToolStripMenuItem.Text = "Поиск пути";
            this.поискПутиToolStripMenuItem.Click += new System.EventHandler(this.поискПутиToolStripMenuItem_Click);
            // 
            // ContexLink
            // 
            this.ContexLink.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsLinkDelete,
            this.TsLinktb});
            this.ContexLink.Name = "ContexLink";
            this.ContexLink.Size = new System.Drawing.Size(161, 51);
            this.ContexLink.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.ContexLink_Closed);
            this.ContexLink.Opening += new System.ComponentModel.CancelEventHandler(this.ContexLink_Opening);
            // 
            // TsLinkDelete
            // 
            this.TsLinkDelete.Name = "TsLinkDelete";
            this.TsLinkDelete.Size = new System.Drawing.Size(160, 22);
            this.TsLinkDelete.Text = "Удалить";
            this.TsLinkDelete.Click += new System.EventHandler(this.TsLinkDelete_Click);
            // 
            // TsLinktb
            // 
            this.TsLinktb.Name = "TsLinktb";
            this.TsLinktb.Size = new System.Drawing.Size(100, 23);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(879, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "123456789";
            this.label1.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Файл графа|*.grph";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Файл графа|*.grph";
            // 
            // btn_Left
            // 
            this.btn_Left.Location = new System.Drawing.Point(369, 0);
            this.btn_Left.Name = "btn_Left";
            this.btn_Left.Size = new System.Drawing.Size(25, 23);
            this.btn_Left.TabIndex = 5;
            this.btn_Left.Text = "<";
            this.btn_Left.UseVisualStyleBackColor = true;
            this.btn_Left.Click += new System.EventHandler(this.btn_Left_Click);
            // 
            // btn_Right
            // 
            this.btn_Right.Location = new System.Drawing.Point(441, 0);
            this.btn_Right.Name = "btn_Right";
            this.btn_Right.Size = new System.Drawing.Size(23, 23);
            this.btn_Right.TabIndex = 6;
            this.btn_Right.Text = ">";
            this.btn_Right.UseVisualStyleBackColor = true;
            this.btn_Right.Click += new System.EventHandler(this.btn_Right_Click);
            // 
            // lb_PathNum
            // 
            this.lb_PathNum.AutoSize = true;
            this.lb_PathNum.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_PathNum.Location = new System.Drawing.Point(411, 5);
            this.lb_PathNum.Name = "lb_PathNum";
            this.lb_PathNum.Size = new System.Drawing.Size(13, 13);
            this.lb_PathNum.TabIndex = 7;
            this.lb_PathNum.Text = "0";
            this.lb_PathNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(759, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(759, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(759, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(759, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(759, 157);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(858, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_PathNum);
            this.Controls.Add(this.btn_Right);
            this.Controls.Add(this.btn_Left);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GraphForm";
            this.Text = "GraphViewer3000";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ContextNode.ResumeLayout(false);
            this.ContextNode.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ContexLink.ResumeLayout(false);
            this.ContexLink.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Render;
        private System.Windows.Forms.ContextMenuStrip ContextNode;
        private System.Windows.Forms.ContextMenuStrip ContextEmpty;
        private System.Windows.Forms.ToolStripTextBox TsTbName;
        private System.Windows.Forms.ToolStripMenuItem TsDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ContexLink;
        private System.Windows.Forms.ToolStripMenuItem TsLinkDelete;
        private System.Windows.Forms.ToolStripTextBox TsLinktb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инструментыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показыватьВесаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem убратьВесаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem двойнаяСвязьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поискПутиToolStripMenuItem;
        private System.Windows.Forms.Button btn_Left;
        private System.Windows.Forms.Button btn_Right;
        private System.Windows.Forms.Label lb_PathNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

