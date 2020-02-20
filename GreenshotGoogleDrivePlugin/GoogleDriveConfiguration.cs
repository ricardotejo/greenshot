﻿/*
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
using System.Windows.Forms;
using Greenshot.IniFile;
using GreenshotPlugin.Core;

namespace GreenshotGoogleDrivePlugin
{

	/// <summary>
	/// Description of GoogleDriveConfiguration.
	/// </summary>
	[IniSection("GoogleDrive", Description = "Greenshot Google Drive Plugin configuration")]
	public class GoogleDriveConfiguration : IniSection 
	{

		[IniProperty("UploadFormat", Description="What file type to use for uploading", DefaultValue="png")]
		public OutputFormat UploadFormat { get; set; }

		[IniProperty("UploadJpegQuality", Description="JPEG file save quality in %.", DefaultValue="80")]
		public int UploadJpegQuality { get; set; }

		[IniProperty("ShareLinkToClipBoard", Description = "After upload share to anyone with the link and copy it to clipboard.", DefaultValue = "true")]
		public bool ShareLinkToClipBoard { get; set; }


		[IniProperty("ShortenLink", Description = "Also shorten the link.", DefaultValue = "false")]
		public bool ShortenLink { get; set; }


		[IniProperty("FolderId", Description = "Google Drive Folder Id were files will be uploaded.", DefaultValue = null)]
		public string FolderId { get; set; }

		[IniProperty("RememberFolder", Description = "Remember Last Google Drive Folder.", DefaultValue = "false")]
		public bool RememberFolder { get; set; }


		[IniProperty("EnableComments", Description = "Enable comments for the file.", DefaultValue = "false")]
		public bool EnableComments { get; set; }
		

				[IniProperty("ClientID", Description = "API Client ID", Encrypted = true, ExcludeIfNull = true)]
		public string ClientID { get; set; }
		[IniProperty("ClientSecret", Description = "API Client Secret", Encrypted = true, ExcludeIfNull = true)]
		public string ClientSecret { get; set; }

		/// <summary>
		/// A form for token
		/// </summary>
		/// <returns>bool true if OK was pressed, false if cancel</returns>
		public bool ShowConfigDialog() {
			DialogResult result = new SettingsForm().ShowDialog();
			if (result == DialogResult.OK) {
				return true;
			}
			return false;
		}
	}
}