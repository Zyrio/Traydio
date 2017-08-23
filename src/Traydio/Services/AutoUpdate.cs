using System;
using System.IO;
using System.Net;
using System.Reflection;
using IniParser;
using IniParser.Model;
using Traydio.Data.Models;

namespace Traydio.Services
{
    public class AutoUpdate
    {
        public AutoUpdateModel CheckUpdate()
        {
            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var url = "https://get.zyr.io/dist/Traydio/update.ini";

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            WebClient webClient = new WebClient();

            AutoUpdateModel returnModel = new AutoUpdateModel();

            try
            {
                using (MemoryStream stream = new MemoryStream(webClient.DownloadData(url)))
                {
                    var parser = new FileIniDataParser();
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8, true);

                    IniData data = parser.ReadData(reader);

                    var currentVersionString = assemblyVersion.Substring(0, assemblyVersion.LastIndexOf("."));
                    var newVersionString = data["Win32_x86"]["Version"];
                    var newVersionUrlString = data["Win32_x86"]["URL"];

                    returnModel.Url = newVersionUrlString;
                    returnModel.NewVersion = newVersionString;
                    returnModel.CurrentVersion = currentVersionString;

                    var currentVersion = new Version(currentVersionString);
                    var newVersion = new Version(newVersionString);

                    var result = currentVersion.CompareTo(newVersion);
                    if (result > 0)
                    {
                        // no update
                        returnModel.IsUpdateAvailable = false;
                        return returnModel;
                    }
                    else if (result < 0)
                    {
                        // update available
                        returnModel.IsUpdateAvailable = true;
                        return returnModel;
                    }
                    else
                    {
                        // no update (same version)
                        returnModel.IsUpdateAvailable = false;
                        return returnModel;
                    }
                }
            } catch
            {
                returnModel.IsUpdateAvailable = false;
                return returnModel;
            }
        }
    }
}
