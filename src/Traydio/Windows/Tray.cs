using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Traydio.StreamEngines;

namespace Traydio.Windows
{
    public partial class Tray : Form
    {
        public Tray()
        {
            InitializeComponent();
        }

        private void Tray_Load(object sender, EventArgs e)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, @"Traydio");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            ReloadStations(Path.Combine(appDataPath, @"Traydio", @"stations.xml"));

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
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;

            this.ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void QuitTrayItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutTrayItem_Click(object sender, EventArgs e)
        {
            var aboutWindow = new About();

            if(Application.OpenForms.OfType<About>().Count() == 0) {
                aboutWindow.Show();
            }
        }

        private void MediaPlayer_Enter(object sender, EventArgs e)
        {

        }

        private void openWMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ReloadStations(string file)
        {
            this.TrayMenu.Items.RemoveAt(2);

            LoadDynamicMenu(file);

            NoStationsMenuItem.Visible = false;

            foreach (var item in TrayMenu.Items)
            {
                Type objectType = item.GetType();

                if (objectType.Equals(typeof(ToolStripMenuItem)))
                {
                    SubscribeToolStripClick((ToolStripMenuItem)item, TrayMenu_Click);
                }
            }
        }

        private static void SubscribeToolStripClick(ToolStripMenuItem item, EventHandler eventHandler)
        {
            // If leaf, add click handler
            if (item.DropDownItems.Count == 0)
            {
                item.Click += eventHandler;
            }
            else
            {
                foreach (var subItem in item.DropDownItems)
                {
                    Type objectType = subItem.GetType();

                    if (objectType.Equals(typeof(ToolStripMenuItem)))
                    {
                        SubscribeToolStripClick((ToolStripMenuItem)subItem, eventHandler);
                    }
                }
            }
        }

        public void LoadDynamicMenu(string xmlPath)
        {
            XmlTextReader reader = new XmlTextReader(xmlPath);
            LoadDynamicMenu(reader);
        }

        public void LoadDynamicMenu(XmlTextReader xmlReader)
        {
            XmlDocument document = new XmlDocument();
            document.Load(xmlReader);

            XmlElement element = document.DocumentElement;

            foreach (XmlNode node in document.FirstChild.ChildNodes)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();

                var menuItemName = Guid.NewGuid().ToString().Replace("-", "");

                menuItem.Name = menuItemName;
                menuItem.Text = node.Attributes["name"].Value;
                if(node.Attributes["url"] != null)
                {
                    menuItem.ToolTipText = node.Attributes["url"].Value;
                }

                this.TrayMenu.Items.Insert(2, menuItem);
                GenerateMenusFromXML(node, (ToolStripMenuItem)this.TrayMenu.Items[2], menuItemName);
            }
        }

        private void GenerateMenusFromXML(XmlNode rootNode, ToolStripMenuItem menuItem, string menuItemName)
        {
            ToolStripItem item = null;
            ToolStripSeparator separator = null;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Attributes["name"].Value.StartsWith("[separator"))
                {
                    separator = new ToolStripSeparator();

                    menuItem.DropDownItems.Add(separator);
                }
                else
                {
                    item = new ToolStripMenuItem();
                    item.Name = Guid.NewGuid().ToString().Replace("-", "");
                    item.Text = node.Attributes["name"].Value;
                    if (node.Attributes["url"] != null)
                    {
                        item.ToolTipText = node.Attributes["url"].Value;
                    }

                    menuItem.DropDownItems.Add(item);

                    GenerateMenusFromXML(node,
                      (ToolStripMenuItem)menuItem.DropDownItems[menuItem.DropDownItems.Count - 1], menuItemName);
                }
            }
        }

        private void ReloadStationsTrayItem_Click(object sender, EventArgs e)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, "Traydio", "stations.xml");

            ReloadStations(path);
        }

        private void OpenStationsTrayItem_Click(object sender, EventArgs e)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, "Traydio", "stations.xml");

            ProcessStartInfo processStartInfo = new ProcessStartInfo(path);
            Process.Start(processStartInfo);
        }

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

        private void PlayTrayItem_Click(object sender, EventArgs e)
        {
            var wmp =  new WMP();

            wmp.ControlAudio(Enums.AudioControl.Play, MediaPlayer);
        }

        private void StopTrayItem_Click(object sender, EventArgs e)
        {
            var wmp = new WMP();

            wmp.ControlAudio(Enums.AudioControl.Stop, MediaPlayer);
        }

        private void ReloadTrayItem_Click(object sender, EventArgs e)
        {
            var wmp = new WMP();

            wmp.ControlAudio(Enums.AudioControl.Reload, MediaPlayer);
        }
    }
}
