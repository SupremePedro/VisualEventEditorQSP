namespace VisualEventEditor
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохраранитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьJSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gENERATECODEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(977, 613);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.gENERATECODEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(977, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохраранитьФайлToolStripMenuItem,
            this.загрузитьФайлToolStripMenuItem,
            this.очиститьToolStripMenuItem,
            this.создатьJSONToolStripMenuItem,
            this.загрузитьJSONToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // сохраранитьФайлToolStripMenuItem
            // 
            this.сохраранитьФайлToolStripMenuItem.Name = "сохраранитьФайлToolStripMenuItem";
            this.сохраранитьФайлToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.сохраранитьФайлToolStripMenuItem.Text = "Сохраранить файл";
            this.сохраранитьФайлToolStripMenuItem.Click += new System.EventHandler(this.сохраранитьФайлToolStripMenuItem_Click);
            // 
            // загрузитьФайлToolStripMenuItem
            // 
            this.загрузитьФайлToolStripMenuItem.Name = "загрузитьФайлToolStripMenuItem";
            this.загрузитьФайлToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.загрузитьФайлToolStripMenuItem.Text = "Загрузить файл";
            this.загрузитьФайлToolStripMenuItem.Click += new System.EventHandler(this.загрузитьФайлToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // создатьJSONToolStripMenuItem
            // 
            this.создатьJSONToolStripMenuItem.Name = "создатьJSONToolStripMenuItem";
            this.создатьJSONToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.создатьJSONToolStripMenuItem.Text = "Создать JSON";
            this.создатьJSONToolStripMenuItem.Click += new System.EventHandler(this.создатьJSONToolStripMenuItem_Click);
            // 
            // загрузитьJSONToolStripMenuItem
            // 
            this.загрузитьJSONToolStripMenuItem.Name = "загрузитьJSONToolStripMenuItem";
            this.загрузитьJSONToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.загрузитьJSONToolStripMenuItem.Text = "Загрузить JSON";
            this.загрузитьJSONToolStripMenuItem.Click += new System.EventHandler(this.загрузитьJSONToolStripMenuItem_Click);
            // 
            // gENERATECODEToolStripMenuItem
            // 
            this.gENERATECODEToolStripMenuItem.Name = "gENERATECODEToolStripMenuItem";
            this.gENERATECODEToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.gENERATECODEToolStripMenuItem.Text = "GENERATE CODE";
            this.gENERATECODEToolStripMenuItem.Click += new System.EventHandler(this.gENERATECODEToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 637);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохраранитьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьJSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьJSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gENERATECODEToolStripMenuItem;
    }
}

