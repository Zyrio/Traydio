using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
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
            try
            {
                if (url.Contains(".pls"))
                {
                    WebClient webClient = new WebClient();
                    using (MemoryStream stream = new MemoryStream(webClient.DownloadData(url)))
                    {
                        var parser = new FileIniDataParser();
                        StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8, true);

                        IniData data = parser.ReadData(reader);

                        var recoveredUrl = data["playlist"]["File1"];

                        mediaPlayer.URL = recoveredUrl;
                        mediaPlayer.Ctlcontrols.play();
                    }
                }
                else
                {
                    mediaPlayer.URL = url;
                    mediaPlayer.Ctlcontrols.play();
                }
            } catch(WebException webException)
            {
                HttpWebResponse errorResponse = webException.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    var errorMessage = string.Format("404: Not Found{0}---{1}Stream '{2}' cannot be found",
                        Environment.NewLine, Environment.NewLine, url);

                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    var errorMessage = string.Format("Unknown Error");

                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
