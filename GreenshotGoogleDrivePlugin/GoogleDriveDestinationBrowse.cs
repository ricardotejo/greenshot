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
using System.ComponentModel;
using System.Drawing;
using Greenshot.Plugin;
using GreenshotPlugin.Core;

namespace GreenshotGoogleDrivePlugin
{
    public class GoogleDriveBrowseDestination : AbstractDestination
    {

        private readonly GoogleDrivePlugin _plugin;

        public GoogleDriveBrowseDestination(GoogleDrivePlugin plugin)
        {
            _plugin = plugin;
        }

        public override string Designation => "GoogleDriveBrowse";

        public override string Description => Language.GetString("gdrive", LangKey.upload_browse_menu_item);

        public override Image DisplayIcon
        {
            get
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(GoogleDrivePlugin));
                return (Image)resources.GetObject("gdrive");
            }
        }

        public override ExportInformation ExportCapture(bool manuallyInitiated, ISurface surface, ICaptureDetails captureDetails)
        {
            ExportInformation exportInformation = new ExportInformation(Designation, Description);
            string uploadUrl;
            var uploadForm = new UploadForm();
            if (uploadForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool uploaded = _plugin.Upload(captureDetails, surface, uploadForm.Tag as string, out uploadUrl);
                if (uploaded)
                {
                    exportInformation.ExportMade = true;
                    exportInformation.Uri = uploadUrl;
                }
                ProcessExport(exportInformation, surface);
                return exportInformation;
            }
            else
            {
                exportInformation.ExportMade = false;

            }
            return exportInformation;

        }
    }
}
