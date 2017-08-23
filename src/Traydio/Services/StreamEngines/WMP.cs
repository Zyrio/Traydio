using System.IO;
using System.Net;
using AxWMPLib;
using IniParser;
using IniParser.Model;
using Traydio.Data.Enums;

namespace Traydio.Services.StreamEngines
{
    public class WMP
    {
        public void StreamAudio(string url, AxWindowsMediaPlayer mediaPlayer)
        {
            if(url.Contains(".pls"))
            {
                WebClient wc = new WebClient();
                using (MemoryStream stream = new MemoryStream(wc.DownloadData(url)))
                {
                    var parser = new FileIniDataParser();
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8, true);

                    IniData data = parser.ReadData(reader);

                    var recoveredUrl = data["playlist"]["File1"];

                    mediaPlayer.URL = recoveredUrl;
                    mediaPlayer.Ctlcontrols.play();
                }
            } else
            {
                mediaPlayer.URL = url;
                mediaPlayer.Ctlcontrols.play();
            }
        }

        public void ControlAudio(AudioControlEnum control, AxWindowsMediaPlayer mediaPlayer)
        {
            switch(control) {
                case (AudioControlEnum.Play):
                    mediaPlayer.Ctlcontrols.play();
                    break;
                case (AudioControlEnum.Stop):
                    mediaPlayer.Ctlcontrols.stop();
                    break;
                case (AudioControlEnum.Pause):
                    mediaPlayer.Ctlcontrols.pause();
                    break;
                case (AudioControlEnum.Reload):
                    mediaPlayer.Ctlcontrols.stop();
                    mediaPlayer.Ctlcontrols.play();
                    break;
            }
        }
    }
}
