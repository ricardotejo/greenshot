using Greenshot.IniFile;
using GreenshotPlugin.Controls;
using GreenshotPlugin.Core;
using log4net;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GreenshotGoogleDrivePlugin
{
    public partial class UploadForm : GreenshotForm
    {


        private static readonly ILog LOG = LogManager.GetLogger(typeof(UploadForm));
        private static readonly GoogleDriveConfiguration config = IniConfig.GetIniSection<GoogleDriveConfiguration>();

        public UploadForm()
        {
            
            InitializeComponent();
            Application.EnableVisualStyles();
            Font = SystemFonts.MessageBoxFont;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
            {
                e.Cancel = true;
            }
        }

        GoogleDriveUtils.DriveFolder currentFolder = null;

        private async void Form1_Load(object sender, EventArgs e)
        {
            currentFolder = await GoogleDriveUtils.GetFolder(config.FolderId);

            UpdateList();
        }

        private async void UpdateList()
        {
            var folders = await GoogleDriveUtils.ListFolders(currentFolder.Id);
            ListBoxFolders.Items.Clear();
            ListBoxFolders.Items.AddRange(folders.ToArray());
            textBox1.Text = currentFolder.Name;
            btnUp.Enabled = currentFolder.Parents != null && currentFolder.Parents.Count > 0;
        }

        private void ListBoxFolders_DoubleClick(object sender, EventArgs e)
        {
            if (ListBoxFolders.SelectedItem != null)
            {
                currentFolder = ListBoxFolders.SelectedItem as GoogleDriveUtils.DriveFolder;
                UpdateList();
            }
        }

        private void ListBoxFolders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListBoxFolders_DoubleClick(null, null);
            }
        }

        private async void btnUp_Click(object sender, EventArgs e)
        {
            if (currentFolder.Parents != null && currentFolder.Parents.Count > 0)
            {
                var parentId = currentFolder.Parents[0];
                currentFolder = await GoogleDriveUtils.GetFolder(currentFolder.Parents[0]);
                UpdateList();
            }


        }

        private void greenshotButton1_Click(object sender, EventArgs e)
        {
            if (config.RememberFolder)
            {
                config.FolderId = currentFolder.Id;
                IniConfig.Save();
            }

            Tag = currentFolder.Id;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
