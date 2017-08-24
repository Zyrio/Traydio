using Traydio.Data.Enums;

namespace Traydio.Data.Models
{
    public class SettingsModel
    {
        public bool CheckForUpdate { get; set; }
        public StreamEngineEnum StreamEngine { get; } = StreamEngineEnum.WindowsMediaPlayer;
    }
}
