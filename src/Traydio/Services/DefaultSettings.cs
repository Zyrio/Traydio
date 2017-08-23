using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Traydio.Data.Constants;

namespace Traydio.Services
{
    public class DefaultSettings
    {
        public void LoadDefaultSettings(string path)
        {
            Default defaultData = new Default();

            // var applicationSettingsPath = Path.Combine(path, "settings.ini");
            var stationsSettingsPath = Path.Combine(path, "stations.xml");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //if (!File.Exists(applicationSettingsPath))
            //    CreateDefaultSettings(defaultData.Application, stationsSettingsPath);

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
