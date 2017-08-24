using System.IO;
using System.Text;
using IniParser;
using IniParser.Model;
using Traydio.Data.Constants;
using Traydio.Data.Models;

namespace Traydio.Services
{
    public class Settings
    {
        public SettingsModel LoadSettings(string path)
        {
            SettingsModel returnModel = new SettingsModel();

            var iniParser = new FileIniDataParser();
            IniData settings = iniParser.ReadFile(path);

            var checkForUpdateSetting = settings["Settings"]["CheckForUpdate"];

            if(checkForUpdateSetting == "true")
            {
                returnModel.CheckForUpdate = true;
            } else
            {
                returnModel.CheckForUpdate = false;
            }

            return returnModel;
        }

        public void LoadDefaultSettings(string path)
        {
            DefaultConstant defaultData = new DefaultConstant();

            var applicationSettingsPath = Path.Combine(path, "settings.ini");
            var stationsSettingsPath = Path.Combine(path, "stations.xml");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (!File.Exists(applicationSettingsPath))
                CreateDefaultSettings(defaultData.Application, applicationSettingsPath);

            if (!File.Exists(stationsSettingsPath))
                CreateDefaultSettings(defaultData.Stations, stationsSettingsPath);

        }

        public void CreateDefaultSettings(string data, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.Write(data);
                }
            }
        }
    }
}
