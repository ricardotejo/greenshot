/*
 * Greenshot - a free and open source screenshot tool
 * Copyright (C) 2007-2016 Thomas Braun, Jens Klingen, Robin Krom, Francis Noel
 * 
 * For more information see: http://getgreenshot.org/
 * The Greenshot project is hosted on GitHub https://github.com/greenshot/greenshot
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
namespace GreenshotGoogleDrivePlugin
{
	partial class SettingsForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.buttonOK = new GreenshotPlugin.Controls.GreenshotButton();
            this.buttonCancel = new GreenshotPlugin.Controls.GreenshotButton();
            this.combobox_uploadimageformat = new GreenshotPlugin.Controls.GreenshotComboBox();
            this.label_upload_format = new GreenshotPlugin.Controls.GreenshotLabel();
            this.label_AfterUpload = new GreenshotPlugin.Controls.GreenshotLabel();
            this.checkboxAfterUploadLinkToClipBoard = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.greenshotLabel1 = new GreenshotPlugin.Controls.GreenshotLabel();
            this.greenshotLabel2 = new GreenshotPlugin.Controls.GreenshotLabel();
            this.greenshotTextBox1 = new GreenshotPlugin.Controls.GreenshotTextBox();
            this.greenshotTextBox2 = new GreenshotPlugin.Controls.GreenshotTextBox();
            this.greenshotLabel3 = new GreenshotPlugin.Controls.GreenshotLabel();
            this.greenshotTextBox3 = new GreenshotPlugin.Controls.GreenshotTextBox();
            this.greenshotCheckBox1 = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.greenshotCheckBox2 = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.greenshotCheckBox3 = new GreenshotPlugin.Controls.GreenshotCheckBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.LanguageKey = "OK";
            this.buttonOK.Location = new System.Drawing.Point(270, 176);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.LanguageKey = "CANCEL";
            this.buttonCancel.Location = new System.Drawing.Point(351, 176);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // combobox_uploadimageformat
            // 
            this.combobox_uploadimageformat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combobox_uploadimageformat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_uploadimageformat.FormattingEnabled = true;
            this.combobox_uploadimageformat.Location = new System.Drawing.Point(174, 6);
            this.combobox_uploadimageformat.Name = "combobox_uploadimageformat";
            this.combobox_uploadimageformat.PropertyName = "UploadFormat";
            this.combobox_uploadimageformat.SectionName = "GoogleDrive";
            this.combobox_uploadimageformat.Size = new System.Drawing.Size(251, 21);
            this.combobox_uploadimageformat.TabIndex = 1;
            // 
            // label_upload_format
            // 
            this.label_upload_format.LanguageKey = "gdrive.label_upload_format";
            this.label_upload_format.Location = new System.Drawing.Point(11, 9);
            this.label_upload_format.Name = "label_upload_format";
            this.label_upload_format.Size = new System.Drawing.Size(157, 20);
            this.label_upload_format.TabIndex = 3;
            this.label_upload_format.Text = "Image format";
            // 
            // label_AfterUpload
            // 
            this.label_AfterUpload.LanguageKey = "gdrive.label_AfterUpload";
            this.label_AfterUpload.Location = new System.Drawing.Point(13, 34);
            this.label_AfterUpload.Name = "label_AfterUpload";
            this.label_AfterUpload.Size = new System.Drawing.Size(155, 21);
            this.label_AfterUpload.TabIndex = 14;
            this.label_AfterUpload.Text = "After upload";
            // 
            // checkboxAfterUploadLinkToClipBoard
            // 
            this.checkboxAfterUploadLinkToClipBoard.AutoSize = true;
            this.checkboxAfterUploadLinkToClipBoard.LanguageKey = "gdrive.label_ShareLinkToClipBoard";
            this.checkboxAfterUploadLinkToClipBoard.Location = new System.Drawing.Point(174, 33);
            this.checkboxAfterUploadLinkToClipBoard.Name = "checkboxAfterUploadLinkToClipBoard";
            this.checkboxAfterUploadLinkToClipBoard.PropertyName = "ShareLinkToClipBoard";
            this.checkboxAfterUploadLinkToClipBoard.SectionName = "GoogleDrive";
            this.checkboxAfterUploadLinkToClipBoard.Size = new System.Drawing.Size(104, 17);
            this.checkboxAfterUploadLinkToClipBoard.TabIndex = 7;
            this.checkboxAfterUploadLinkToClipBoard.Text = "Link to clipboard";
            this.checkboxAfterUploadLinkToClipBoard.UseVisualStyleBackColor = true;
            // 
            // greenshotLabel1
            // 
            this.greenshotLabel1.AutoSize = true;
            this.greenshotLabel1.LanguageKey = "gdrive.label_api_client_id";
            this.greenshotLabel1.Location = new System.Drawing.Point(13, 69);
            this.greenshotLabel1.Name = "greenshotLabel1";
            this.greenshotLabel1.Size = new System.Drawing.Size(44, 13);
            this.greenshotLabel1.TabIndex = 15;
            this.greenshotLabel1.Text = "ClientID";
            // 
            // greenshotLabel2
            // 
            this.greenshotLabel2.AutoSize = true;
            this.greenshotLabel2.LanguageKey = "gdrive.label_api_client_secret";
            this.greenshotLabel2.Location = new System.Drawing.Point(13, 99);
            this.greenshotLabel2.Name = "greenshotLabel2";
            this.greenshotLabel2.Size = new System.Drawing.Size(67, 13);
            this.greenshotLabel2.TabIndex = 16;
            this.greenshotLabel2.Text = "Client Secret";
            // 
            // greenshotTextBox1
            // 
            this.greenshotTextBox1.Location = new System.Drawing.Point(174, 69);
            this.greenshotTextBox1.Name = "greenshotTextBox1";
            this.greenshotTextBox1.PropertyName = "ClientID";
            this.greenshotTextBox1.SectionName = "GoogleDrive";
            this.greenshotTextBox1.Size = new System.Drawing.Size(252, 20);
            this.greenshotTextBox1.TabIndex = 17;
            // 
            // greenshotTextBox2
            // 
            this.greenshotTextBox2.Location = new System.Drawing.Point(174, 96);
            this.greenshotTextBox2.Name = "greenshotTextBox2";
            this.greenshotTextBox2.PropertyName = "ClientSecret";
            this.greenshotTextBox2.SectionName = "GoogleDrive";
            this.greenshotTextBox2.Size = new System.Drawing.Size(252, 20);
            this.greenshotTextBox2.TabIndex = 18;
            this.greenshotTextBox2.UseSystemPasswordChar = true;
            // 
            // greenshotLabel3
            // 
            this.greenshotLabel3.AutoSize = true;
            this.greenshotLabel3.LanguageKey = "gdrive.label_target_folder_id";
            this.greenshotLabel3.Location = new System.Drawing.Point(13, 127);
            this.greenshotLabel3.Name = "greenshotLabel3";
            this.greenshotLabel3.Size = new System.Drawing.Size(84, 13);
            this.greenshotLabel3.TabIndex = 16;
            this.greenshotLabel3.Text = "Target Folder ID";
            // 
            // greenshotTextBox3
            // 
            this.greenshotTextBox3.Location = new System.Drawing.Point(174, 124);
            this.greenshotTextBox3.Name = "greenshotTextBox3";
            this.greenshotTextBox3.PropertyName = "FolderId";
            this.greenshotTextBox3.SectionName = "GoogleDrive";
            this.greenshotTextBox3.Size = new System.Drawing.Size(252, 20);
            this.greenshotTextBox3.TabIndex = 18;
            // 
            // greenshotCheckBox1
            // 
            this.greenshotCheckBox1.AutoSize = true;
            this.greenshotCheckBox1.LanguageKey = "gdrive.label_ShareShortLink";
            this.greenshotCheckBox1.Location = new System.Drawing.Point(339, 33);
            this.greenshotCheckBox1.Name = "greenshotCheckBox1";
            this.greenshotCheckBox1.PropertyName = "ShortenLink";
            this.greenshotCheckBox1.SectionName = "GoogleDrive";
            this.greenshotCheckBox1.Size = new System.Drawing.Size(86, 17);
            this.greenshotCheckBox1.TabIndex = 7;
            this.greenshotCheckBox1.Text = "Shorten Link";
            this.greenshotCheckBox1.UseVisualStyleBackColor = true;
            // 
            // greenshotCheckBox2
            // 
            this.greenshotCheckBox2.AutoSize = true;
            this.greenshotCheckBox2.LanguageKey = "gdrive.label_remember_folder";
            this.greenshotCheckBox2.Location = new System.Drawing.Point(294, 150);
            this.greenshotCheckBox2.Name = "greenshotCheckBox2";
            this.greenshotCheckBox2.PropertyName = "RememberFolder";
            this.greenshotCheckBox2.SectionName = "GoogleDrive";
            this.greenshotCheckBox2.Size = new System.Drawing.Size(132, 17);
            this.greenshotCheckBox2.TabIndex = 7;
            this.greenshotCheckBox2.Text = "Remember Last Folder";
            this.greenshotCheckBox2.UseVisualStyleBackColor = true;
            // 
            // greenshotCheckBox3
            // 
            this.greenshotCheckBox3.AutoSize = true;
            this.greenshotCheckBox3.LanguageKey = "gdrive.label_enable_comments";
            this.greenshotCheckBox3.Location = new System.Drawing.Point(174, 150);
            this.greenshotCheckBox3.Name = "greenshotCheckBox3";
            this.greenshotCheckBox3.PropertyName = "EnableComments";
            this.greenshotCheckBox3.SectionName = "GoogleDrive";
            this.greenshotCheckBox3.Size = new System.Drawing.Size(111, 17);
            this.greenshotCheckBox3.TabIndex = 7;
            this.greenshotCheckBox3.Text = "Enable Comments";
            this.greenshotCheckBox3.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(432, 211);
            this.Controls.Add(this.greenshotTextBox3);
            this.Controls.Add(this.greenshotTextBox2);
            this.Controls.Add(this.greenshotTextBox1);
            this.Controls.Add(this.greenshotLabel3);
            this.Controls.Add(this.greenshotLabel2);
            this.Controls.Add(this.greenshotLabel1);
            this.Controls.Add(this.greenshotCheckBox1);
            this.Controls.Add(this.greenshotCheckBox3);
            this.Controls.Add(this.greenshotCheckBox2);
            this.Controls.Add(this.checkboxAfterUploadLinkToClipBoard);
            this.Controls.Add(this.label_AfterUpload);
            this.Controls.Add(this.label_upload_format);
            this.Controls.Add(this.combobox_uploadimageformat);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LanguageKey = "gdrive.settings_title";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Google Drive settings";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private GreenshotPlugin.Controls.GreenshotComboBox combobox_uploadimageformat;
		private GreenshotPlugin.Controls.GreenshotLabel label_upload_format;
		private GreenshotPlugin.Controls.GreenshotButton buttonCancel;
		private GreenshotPlugin.Controls.GreenshotButton buttonOK;
		private GreenshotPlugin.Controls.GreenshotLabel label_AfterUpload;
		private GreenshotPlugin.Controls.GreenshotCheckBox checkboxAfterUploadLinkToClipBoard;
        private GreenshotPlugin.Controls.GreenshotLabel greenshotLabel1;
        private GreenshotPlugin.Controls.GreenshotLabel greenshotLabel2;
        private GreenshotPlugin.Controls.GreenshotTextBox greenshotTextBox1;
        private GreenshotPlugin.Controls.GreenshotTextBox greenshotTextBox2;
        private GreenshotPlugin.Controls.GreenshotLabel greenshotLabel3;
        private GreenshotPlugin.Controls.GreenshotTextBox greenshotTextBox3;
        private GreenshotPlugin.Controls.GreenshotCheckBox greenshotCheckBox1;
        private GreenshotPlugin.Controls.GreenshotCheckBox greenshotCheckBox2;
        private GreenshotPlugin.Controls.GreenshotCheckBox greenshotCheckBox3;
    }
}
