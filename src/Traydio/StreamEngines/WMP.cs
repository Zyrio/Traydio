using System.IO;
using System.Net;
using AxWMPLib;
using IniParser;
using IniParser.Model;

namespace Traydio.StreamEngines
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

        public void ControlAudio(Enums.AudioControl control, AxWindowsMediaPlayer mediaPlayer)
        {
            switch(control) {
                case (Enums.AudioControl.Play):
                    mediaPlayer.Ctlcontrols.play();
                    break;
                case (Enums.AudioControl.Stop):
                    mediaPlayer.Ctlcontrols.stop();
                    break;
                case (Enums.AudioControl.Pause):
                    mediaPlayer.Ctlcontrols.pause();
                    break;
                case (Enums.AudioControl.Reload):
                    mediaPlayer.Ctlcontrols.stop();
                    mediaPlayer.Ctlcontrols.play();
                    break;
            }
        }
    }
}
