﻿namespace VisualEventEditor
{
    partial class LocEditForm
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
            this.txtLocName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShtLocDescription = new System.Windows.Forms.TextBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLocName
            // 
            this.txtLocName.Location = new System.Drawing.Point(486, 61);
            this.txtLocName.Name = "txtLocName";
            this.txtLocName.Size = new System.Drawing.Size(100, 20);
            this.txtLocName.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(256, 128);
            this.button2.TabIndex = 3;
            this.button2.Text = "Open QSP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Location name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Short location description:";
            // 
            // txtShtLocDescription
            // 
            this.txtShtLocDescription.Location = new System.Drawing.Point(30, 59);
            this.txtShtLocDescription.Multiline = true;
            this.txtShtLocDescription.Name = "txtShtLocDescription";
            this.txtShtLocDescription.Size = new System.Drawing.Size(294, 384);
            this.txtShtLocDescription.TabIndex = 6;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveChanges.Location = new System.Drawing.Point(118, 491);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(139, 39);
            this.btnSaveChanges.TabIndex = 7;
            this.btnSaveChanges.Text = "Save changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // LocEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 570);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.txtShtLocDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtLocName);
            this.Name = "LocEditForm";
            this.Text = "LocEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtLocName;
        public System.Windows.Forms.TextBox txtShtLocDescription;
        private System.Windows.Forms.Button btnSaveChanges;
    }
}