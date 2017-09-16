using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Traydio.Data.Enums;
using Traydio.Data.Models;
using Traydio.Services;
using Traydio.Services.StreamEngines;

namespace Traydio.Windows
{
    public partial class Tray : Form
    {
        public string _appDataPath { get; set; }
        public string _configPath { get; set; }
        public SettingsModel _settings { get; set; }
        public Utilities _utilities { get; set; }

        public Tray()
        {
            _utilities = new Utilities();

            InitializeComponent();
        }

        private void Tray_Load(object sender, EventArgs e)
        {
            Settings settingsService = new Settings();

            _appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _configPath = Path.Combine(_appDataPath, "Traydio");

            var settingsPath = Path.Combine(_configPath, "Settings.ini");

            settingsService.LoadDefaultSettings(_configPath);
            _settings = settingsService.LoadSettings(settingsPath);

            ReloadStationsMenu();

            if (_settings.CheckForUpdate)
            {
                CheckUpdate();
            }

            this.ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;

            this.ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        void TrayMenu_Click(object sender, EventArgs e)
        {
            var name = (sender as ToolStripMenuItem).Text;
            var url = (sender as ToolStripMenuItem).ToolTipText;

            if(!String.IsNullOrEmpty(url))
            {
                var wmp = new WMP();
                wmp.StreamAudio(url, MediaPlayer);

                NowPlayingTrayItem.Text = name;
                TrayIcon.Text = "Traydio: " + name;
            }
        }

        /// <summary>
        /// (Tray) -> Quit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitTrayItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// (Tray) -> About -> GitHub
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GitHubTrayItem_Click(object sender, EventArgs e)
        {
            _utilities.OpenWebsite("https://github.com/zyrio/traydio");
        }

        /// <summary>
        /// (Tray) -> About -> Website
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebsiteTrayItem_Click(object sender, EventArgs e)
        {
            _utilities.OpenWebsite("https://zyr.io/traydio");
        }

        private void CheckForUpdateTrayItem_Click(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        /// <summary>
        /// (Tray) -> About -> About Traydio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutTraydioTrayItem_Click(object sender, EventArgs e)
        {
            var aboutWindow = new About();

            if (Application.OpenForms.OfType<About>().Count() == 0)
            {
                aboutWindow.Show();
            }
        }

        /// <summary>
        /// (Tray) -> Stations -> Reload Stations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadStationsTrayItem_Click(object sender, EventArgs e)
        {
            ReloadStationsMenu();
        }

        /// <summary>
        /// (Tray) -> Stations -> Edit Stations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenStationsTrayItem_Click(object sender, EventArgs e)
        {
            var stationsPath = Path.Combine(_configPath, "stations.xml");

            _utilities.OpenFile(stationsPath);
        }

        /// <summary>
        /// (Tray) -> Playback -> Engine -> Windows Media Player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowsMediaPlayerTrayItem_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                this.Show();
                this.Opacity = 100;
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// (Tray) -> Playback -> Reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadTrayItem_Click(object sender, EventArgs e)
        {
            WMP wmpStreamEngine = new WMP();

            wmpStreamEngine.ControlAudio(AudioControlEnum.Reload, MediaPlayer);
        }

        /// <summary>
        /// (Tray) -> Playback -> Stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopTrayItem_Click(object sender, EventArgs e)
        {
            WMP wmpStreamEngine = new WMP();

            wmpStreamEngine.ControlAudio(AudioControlEnum.Stop, MediaPlayer);

            TrayIcon.Text = "Traydio";
        }

        /// <summary>
        /// (Tray) -> Playback -> Play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayTrayItem_Click(object sender, EventArgs e)
        {
            WMP wmpStreamEngine = new WMP();

            wmpStreamEngine.ControlAudio(AudioControlEnum.Play, MediaPlayer);
        }

        public void CheckUpdate()
        {
            AutoUpdate autoUpdateService = new AutoUpdate();

            var checkUpdate = autoUpdateService.CheckUpdate();

            if (checkUpdate.IsUpdateAvailable)
            {
                var updateMessage = string.Format("Update available for Traydio!{0}You are on version {1}; the latest version is {2}.{3}{4}Do you want to download the latest version?",
                    Environment.NewLine, checkUpdate.CurrentVersion, checkUpdate.NewVersion, Environment.NewLine, Environment.NewLine);

                if (MessageBox.Show(updateMessage, "Update Traydio", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    _utilities.OpenWebsite(checkUpdate.Url);
                }
            }
        }

        private void ReloadStationsMenu()
        {
            Stations stationsService = new Stations();

            var reloadStationsSuccess = stationsService.ReloadStations(TrayMenu, Path.Combine(_configPath, "stations.xml"));
            if (reloadStationsSuccess)
            {
                foreach (var item in TrayMenu.Items)
                {
                    NoStationsMenuItem.Visible = false;

                    Type itemType = item.GetType();

                    if (itemType.Equals(typeof(ToolStripMenuItem)))
                        SubscribeToolStripClick((ToolStripMenuItem)item, TrayMenu_Click);
                }
            }
        }

        private static void SubscribeToolStripClick(ToolStripMenuItem item, EventHandler eventHandler)
        {
            if (item.DropDownItems.Count == 0)
            {
                item.Click += eventHandler;
            }
            else
            {
                foreach (var subItem in item.DropDownItems)
                {
                    Type subItemType = subItem.GetType();

                    if (subItemType.Equals(typeof(ToolStripMenuItem)))
                    {
                        SubscribeToolStripClick((ToolStripMenuItem)subItem, eventHandler);
                    }
                }
            }
        }
    }
}
