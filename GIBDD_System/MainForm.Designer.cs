namespace GIBDD_System
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.водителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокВодителейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВодителяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.штрафыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.необработанныеШтрафыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортВФССПCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьКарточкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.StatusStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.водителиToolStripMenuItem,
            this.штрафыToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1421, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click_1);
            // 
            // водителиToolStripMenuItem
            // 
            this.водителиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокВодителейToolStripMenuItem,
            this.добавитьВодителяToolStripMenuItem});
            this.водителиToolStripMenuItem.Name = "водителиToolStripMenuItem";
            this.водителиToolStripMenuItem.Size = new System.Drawing.Size(89, 26);
            this.водителиToolStripMenuItem.Text = "Водители";
            // 
            // списокВодителейToolStripMenuItem
            // 
            this.списокВодителейToolStripMenuItem.Name = "списокВодителейToolStripMenuItem";
            this.списокВодителейToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.списокВодителейToolStripMenuItem.Text = "Список водителей";
            this.списокВодителейToolStripMenuItem.Click += new System.EventHandler(this.списокВодителейToolStripMenuItem_Click_1);
            // 
            // добавитьВодителяToolStripMenuItem
            // 
            this.добавитьВодителяToolStripMenuItem.Name = "добавитьВодителяToolStripMenuItem";
            this.добавитьВодителяToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.добавитьВодителяToolStripMenuItem.Text = "Добавить водителя";
            this.добавитьВодителяToolStripMenuItem.Click += new System.EventHandler(this.добавитьВодителяToolStripMenuItem_Click_1);
            // 
            // штрафыToolStripMenuItem
            // 
            this.штрафыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьJSONToolStripMenuItem,
            this.необработанныеШтрафыToolStripMenuItem});
            this.штрафыToolStripMenuItem.Name = "штрафыToolStripMenuItem";
            this.штрафыToolStripMenuItem.Size = new System.Drawing.Size(81, 26);
            this.штрафыToolStripMenuItem.Text = "Штрафы";
            // 
            // загрузитьJSONToolStripMenuItem
            // 
            this.загрузитьJSONToolStripMenuItem.Name = "загрузитьJSONToolStripMenuItem";
            this.загрузитьJSONToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.загрузитьJSONToolStripMenuItem.Text = "Загрузить JSON";
            this.загрузитьJSONToolStripMenuItem.Click += new System.EventHandler(this.загрузитьJSONToolStripMenuItem_Click);
            // 
            // необработанныеШтрафыToolStripMenuItem
            // 
            this.необработанныеШтрафыToolStripMenuItem.Name = "необработанныеШтрафыToolStripMenuItem";
            this.необработанныеШтрафыToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.необработанныеШтрафыToolStripMenuItem.Text = "Необработанные штрафы";
            this.необработанныеШтрафыToolStripMenuItem.Click += new System.EventHandler(this.необработанныеШтрафыToolStripMenuItem_Click_1);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортВФССПCSVToolStripMenuItem,
            this.печатьКарточкиToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 26);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // экспортВФССПCSVToolStripMenuItem
            // 
            this.экспортВФССПCSVToolStripMenuItem.Name = "экспортВФССПCSVToolStripMenuItem";
            this.экспортВФССПCSVToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.экспортВФССПCSVToolStripMenuItem.Text = "Экспорт в ФССП (CSV)";
            this.экспортВФССПCSVToolStripMenuItem.Click += new System.EventHandler(this.экспортВФССПCSVToolStripMenuItem_Click);
            // 
            // печатьКарточкиToolStripMenuItem
            // 
            this.печатьКарточкиToolStripMenuItem.Name = "печатьКарточкиToolStripMenuItem";
            this.печатьКарточкиToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.печатьКарточкиToolStripMenuItem.Text = "Печать карточки";
            this.печатьКарточкиToolStripMenuItem.Click += new System.EventHandler(this.печатьКарточкиToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 26);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripStatusLabel1.Location = new System.Drawing.Point(0, 720);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1421, 22);
            this.toolStripStatusLabel1.TabIndex = 6;
            this.toolStripStatusLabel1.Text = "statusStrip1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1421, 692);
            this.dataGridView1.TabIndex = 8;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 742);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStripStatusLabel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АИС ГИБДД: Главная панель";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem водителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокВодителейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьВодителяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem штрафыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьJSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem необработанныеШтрафыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортВФССПCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьКарточкиToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.StatusStrip toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}