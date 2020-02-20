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
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using IO = System.IO;
using System.Threading;
using System.Xml;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Greenshot.IniFile;
using Greenshot.Plugin;
using GreenshotPlugin.Core;
using log4net;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GreenshotGoogleDrivePlugin
{
    /// <summary>
    /// Description of GoogleDriveUtils.
    /// </summary>
    public class GoogleDriveUtils
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(GoogleDriveUtils));
        private static readonly GoogleDriveConfiguration config = IniConfig.GetIniSection<GoogleDriveConfiguration>();
        private static DriveService ___driveService;
        private static DriveService driveService
        {
            get
            {
                if (___driveService == null)
                {
                    string[] Scopes = { DriveService.Scope.Drive };

                    string ApplicationName = "Greenshot Google Drive Plugin";

                    ClientSecrets gdriveSecrets = new ClientSecrets
                    {
                        ClientId = config.ClientID,
                        ClientSecret = config.ClientSecret
                    };

                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.

                    string credPath = IO.Path.Combine(new IO.FileInfo(IniConfig.ConfigLocation).Directory.FullName, "google-drive-token");
                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                            gdriveSecrets,
                            Scopes,
                            "user",
                            CancellationToken.None,
                            new FileDataStore(credPath, true)).Result;
                    LOG.Debug("Google Drive Credential file saved to: " + credPath);

                    // Create Drive API service.
                    ___driveService = new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = ApplicationName,
                    });
                }
                return ___driveService;
            }
        }
        /// <summary>
        /// Do the actual upload to Google Drive
        /// For more details on the available parameters, see: http://flickrnet.codeplex.com
        /// </summary>
        /// <param name="surfaceToUpload"></param>
        /// <param name="outputSettings"></param>
        /// <param name="title"></param>
        /// <param name="filename"></param>
        /// <returns>url to image</returns>
        public static string UploadToDrive(ISurface surfaceToUpload, SurfaceOutputSettings outputSettings, string folder, string filename)
        {
            try
            {
                string fileUrl = UploadToFolder(
                    new SurfaceContainer(surfaceToUpload, outputSettings, filename),
                    folder
                );

                return fileUrl;
            }
            catch (Exception ex)
            {
                LOG.Error("Upload error: ", ex);
                throw;
            }
        }

        private static string UploadToFolder(SurfaceContainer surface, string folder)
        {
            var fileMetadata = new File()
            {
                Name = surface.Filename,
                Parents = new List<string> { string.IsNullOrEmpty(folder) ? "root" : folder },
            };

            FilesResource.CreateMediaUpload request;

            // upload
            using (var stream = new IO.MemoryStream())
            {
                surface.WriteToStream(stream);
                stream.Seek(0, IO.SeekOrigin.Begin);

                request = driveService.Files.Create(fileMetadata, stream, surface.ContentType); //  "image/jpeg"
                request.Fields = "id";
                request.Upload();
            }
            if (request.GetProgress().Status != Google.Apis.Upload.UploadStatus.Completed)
            {
                throw new Exception("An error occurs during upload to Google Drive");
            }
            var fileId = request.ResponseBody.Id;
            LOG.Info("File uploaded to Google Drive with ID: " + fileId);


            if (config.ShareLinkToClipBoard)
            {

                // share link
                var req = driveService.Permissions.Create(
                    new Permission
                    {
                        Role = config.EnableComments ? "commenter" : "reader",
                        Type = "anyone"
                    }, fileId);
                var resPerm = req.Execute();

                return "https://drive.google.com/open?id=" + fileId;
            }

            return null;
        }

        public class DriveFolder
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public IList<string> Parents { get; set; }

            public override string ToString()
            {
                return Name;
            }

        }

        public static async Task<IEnumerable<DriveFolder>> ListFolders(string parentId = null)
        {
            if (parentId == null) { parentId = "root"; }

            var list = new List<DriveFolder>();
            try
            {
                FilesResource.ListRequest request;
                request = driveService.Files.List();
                request.PageSize = 20;
                request.Corpora = "user";
                request.Spaces = "drive";
                request.Fields = "nextPageToken, files(id, name, parents)";

                request.OrderBy = "name_natural";
                request.Q = "(mimeType = 'application/vnd.google-apps.folder') and ('" + parentId + "' in parents) and (trashed = false)";

                string nextToken = null;

                do
                {
                    request.PageToken = nextToken;
                    var response = await request.ExecuteAsync();

                    if (response != null && response.Files != null)
                    {
                        list.AddRange(response.Files.Select(f => new DriveFolder { Id = f.Id, Name = f.Name, Parents = f.Parents }));
                        //foreach (var x in response.Files)
                        //{
                        //    LOG.InfoFormat("DEBUG: {0} {1} {2}", x.Id, x.Name, x.Parents != null ? string.Join(" / ", x.Parents) : "{ROOT}");
                        //}

                    }
                    nextToken = response.NextPageToken;
                    //LOG.Debug("Next token = " + nextToken);
                }
                while (nextToken != null);
            }
            catch (Exception ex)
            {
                LOG.Error("Google Drive - Unable to list folders", ex);
            }
            return list;
        }

        public static async Task<DriveFolder> GetFolder(string fileID)
        {
            if (fileID == null)
            {
                return new DriveFolder { Name = "{root}", Id = null, Parents = null };
            }
            FilesResource.GetRequest request;
            request = driveService.Files.Get(fileID);
            request.Fields = "name, parents";
            var response = await request.ExecuteAsync();
            return new DriveFolder { Name = response.Name, Id = fileID, Parents = response.Parents };
        }

    }
}
