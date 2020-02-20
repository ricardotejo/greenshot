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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Greenshot.IniFile;
using Greenshot.Plugin;
using GreenshotPlugin.Controls;
using GreenshotPlugin.Core;
using log4net;

namespace GreenshotGoogleDrivePlugin
{
    /// <summary>
    /// This is the Google Drive base code
    /// </summary>
    public class GoogleDrivePlugin : IGreenshotPlugin
    {

        private const string LanguagePrefix = "gdrive";
        private static readonly ILog Log = LogManager.GetLogger(typeof(GoogleDrivePlugin));
        private static GoogleDriveConfiguration _config;
        public static PluginAttribute Attributes;
        private IGreenshotHost _host;
        private ComponentResourceManager _resources;
        private ToolStripMenuItem _itemPlugInConfig;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            if (_itemPlugInConfig == null)
            {
                return;
            }
            _itemPlugInConfig.Dispose();
            _itemPlugInConfig = null;
        }
        public string LastFolderId { get { return _config.FolderId; } }

        public IEnumerable<IDestination> Destinations()
        {
            yield return new GoogleDriveDestination(this);
            yield return new GoogleDriveBrowseDestination(this);
        }


        public IEnumerable<IProcessor> Processors()
        {
            yield break;
        }

        /// <summary>
        /// Implementation of the IGreenshotPlugin.Initialize
        /// </summary>
        /// <param name="pluginHost">Use the IGreenshotPluginHost interface to register events</param>
        /// <param name="pluginAttribute">My own attributes</param>
        public virtual bool Initialize(IGreenshotHost pluginHost, PluginAttribute pluginAttribute)
        {
            _host = pluginHost;
            Attributes = pluginAttribute;

            // Register configuration (don't need the configuration itself)
            _config = IniConfig.GetIniSection<GoogleDriveConfiguration>();
            _resources = new ComponentResourceManager(typeof(GoogleDrivePlugin));

            _itemPlugInConfig = new ToolStripMenuItem
            {
                Text = Language.GetString(LanguagePrefix, LangKey.Configure),
                Tag = _host,
                Image = (Image)_resources.GetObject("gdrive")
            };
            _itemPlugInConfig.Click += ConfigMenuClick;

            PluginUtils.AddToContextMenu(_host, _itemPlugInConfig);
            Language.LanguageChanged += OnLanguageChanged;
            return true;
        }

        public void OnLanguageChanged(object sender, EventArgs e)
        {
            if (_itemPlugInConfig != null)
            {
                _itemPlugInConfig.Text = Language.GetString(LanguagePrefix, LangKey.Configure);
            }
        }

        public virtual void Shutdown()
        {
            Log.Debug("Google Drive Plugin shutdown.");
        }

        /// <summary>
        /// Implementation of the IPlugin.Configure
        /// </summary>
        public virtual void Configure()
        {
            _config.ShowConfigDialog();
        }

        public void ConfigMenuClick(object sender, EventArgs eventArgs)
        {
            _config.ShowConfigDialog();
        }

        public bool Upload(ICaptureDetails captureDetails, ISurface surface, string folder, out string uploadUrl)
        {
            SurfaceOutputSettings outputSettings = new SurfaceOutputSettings(_config.UploadFormat, _config.UploadJpegQuality, false);
            uploadUrl = null;
            try
            {
                string fileUrl = null;

                new PleaseWaitForm().ShowAndWait(Attributes.Name, Language.GetString(LanguagePrefix, LangKey.communication_wait),
                    delegate
                    {
                        string filename = Path.GetFileName(FilenameHelper.GetFilename(_config.UploadFormat, captureDetails));

                        fileUrl = GoogleDriveUtils.UploadToDrive(surface, outputSettings, folder, filename);
                    }
                );

                uploadUrl = fileUrl;

                if (_config.ShareLinkToClipBoard)
                {
                    if (_config.ShortenLink)
                    {
                        var shortenTask = Task.Run(async () => await UrlShortener(fileUrl));
                        shortenTask.Wait();
                        if (shortenTask.Result == null)
                        {
                            Log.Error("Error creating the sortened link for Google Drive file");
                            MessageBox.Show(Language.GetString(LanguagePrefix, LangKey.shortlink_failure));
                            ClipboardHelper.SetClipboardData(fileUrl);
                        }
                        else
                        {
                            ClipboardHelper.SetClipboardData(shortenTask.Result);
                        }

                    }
                    else
                    {
                        ClipboardHelper.SetClipboardData(fileUrl);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Log.Error("Error uploading.", e);
                MessageBox.Show(Language.GetString(LanguagePrefix, LangKey.upload_failure) + " " + e.Message);
            }
            return false;
        }

        private async Task<string> UrlShortener(string link)
        {
            // request: https://cutt.ly/api/api.php?key=6a9d298861f443f446f85f0193366a374e4d1&short=http://sbcd.com/image.jpg
            // response: {"url":{"status":7,"fullLink":"http:\/\/sbcd.com\/image.jpg","date":"20.02.2020","shortLink":"https:\/\/cutt.ly\/8rMNRIY","title":"sbcd.com"}}

            string key = "6a9d298861f443f446f85f0193366a374e4d1";
            string uri = string.Format("https://cutt.ly/api/api.php?key={0}&short={1}", key, link);
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                HttpClient client = new HttpClient();

                var resp = await client.GetAsync(uri);
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string body = await resp.Content.ReadAsStringAsync();
                    string shortLink = (JSONHelper.JsonDecode(body)["url"] as Dictionary<string, object>)["shortLink"] as string;
                    return shortLink;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
