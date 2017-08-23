
namespace Traydio.Data.Models
{
    public class AutoUpdateModel
    {
        public string CurrentVersion { get; set; }
        public bool IsUpdateAvailable { get; set; }
        public string NewVersion { get; set; }
        public string Url { get; set; }
    }
}
