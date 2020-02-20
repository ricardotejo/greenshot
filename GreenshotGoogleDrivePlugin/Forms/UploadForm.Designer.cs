using System;

namespace GreenshotGoogleDrivePlugin
{
    partial class UploadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadForm));
            this.ListBoxFolders = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.greenshotButton1 = new GreenshotPlugin.Controls.GreenshotButton();
            this.greenshotButton2 = new GreenshotPlugin.Controls.GreenshotButton();
            this.btnUp = new GreenshotPlugin.Controls.GreenshotButton();
            this.SuspendLayout();
            // 
            // ListBoxFolders
            // 
            this.ListBoxFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxFolders.FormattingEnabled = true;
            this.ListBoxFolders.Location = new System.Drawing.Point(12, 39);
            this.ListBoxFolders.Name = "ListBoxFolders";
            this.ListBoxFolders.Size = new System.Drawing.Size(194, 199);
            this.ListBoxFolders.TabIndex = 1;
            this.ListBoxFolders.DoubleClick += new System.EventHandler(this.ListBoxFolders_DoubleClick);
            this.ListBoxFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxFolders_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(52, 9);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(154, 24);
            this.textBox1.TabIndex = 3;
            // 
            // greenshotButton1
            // 
            this.greenshotButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.greenshotButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greenshotButton1.LanguageKey = "OK";
            this.greenshotButton1.Location = new System.Drawing.Point(110, 260);
            this.greenshotButton1.Name = "greenshotButton1";
            this.greenshotButton1.Size = new System.Drawing.Size(96, 24);
            this.greenshotButton1.TabIndex = 4;
            this.greenshotButton1.Text = "Ok";
            this.greenshotButton1.UseVisualStyleBackColor = true;
            this.greenshotButton1.Click += new System.EventHandler(this.greenshotButton1_Click);
            // 
            // greenshotButton2
            // 
            this.greenshotButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.greenshotButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.greenshotButton2.LanguageKey = "CANCEL";
            this.greenshotButton2.Location = new System.Drawing.Point(12, 260);
            this.greenshotButton2.Name = "greenshotButton2";
            this.greenshotButton2.Size = new System.Drawing.Size(72, 24);
            this.greenshotButton2.TabIndex = 4;
            this.greenshotButton2.Text = "Cancel";
            this.greenshotButton2.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.LanguageKey = "button_folder_up";
            this.btnUp.Location = new System.Drawing.Point(12, 9);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 24);
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.greenshotButton2;
            this.ClientSize = new System.Drawing.Size(214, 296);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.greenshotButton2);
            this.Controls.Add(this.greenshotButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ListBoxFolders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "browse_title";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(230, 320);
            this.Name = "UploadForm";
            this.Text = "Upload to Google Drive";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     
        #endregion
        private System.Windows.Forms.ListBox ListBoxFolders;
        private System.Windows.Forms.TextBox textBox1;
        private GreenshotPlugin.Controls.GreenshotButton greenshotButton1;
        private GreenshotPlugin.Controls.GreenshotButton greenshotButton2;
        private GreenshotPlugin.Controls.GreenshotButton btnUp;
    }
}