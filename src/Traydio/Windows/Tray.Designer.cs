namespace Traydio.Windows
{
    partial class Tray
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem StationsTrayItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tray));
            this.OpenStationsTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadStationsTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NowPlayingTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Seperator2TrayItem = new System.Windows.Forms.ToolStripSeparator();
            this.NoStationsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Seperator3TrayItem = new System.Windows.Forms.ToolStripSeparator();
            this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator4MenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.EngineTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MpdTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowsMediaPlayerTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Seperator1TrayItem = new System.Windows.Forms.ToolStripSeparator();
            this.AboutTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutTraydioTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator5TrayItem = new System.Windows.Forms.ToolStripSeparator();
            this.WebsiteTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GitHubTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            StationsTrayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // StationsTrayItem
            // 
            StationsTrayItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenStationsTrayItem,
            this.ReloadStationsTrayItem});
            StationsTrayItem.Name = "StationsTrayItem";
            StationsTrayItem.Size = new System.Drawing.Size(169, 22);
            StationsTrayItem.Text = "Stations";
            // 
            // OpenStationsTrayItem
            // 
            this.OpenStationsTrayItem.Name = "OpenStationsTrayItem";
            this.OpenStationsTrayItem.Size = new System.Drawing.Size(155, 22);
            this.OpenStationsTrayItem.Text = "Edit Stations";
            this.OpenStationsTrayItem.Click += new System.EventHandler(this.OpenStationsTrayItem_Click);
            // 
            // ReloadStationsTrayItem
            // 
            this.ReloadStationsTrayItem.Name = "ReloadStationsTrayItem";
            this.ReloadStationsTrayItem.Size = new System.Drawing.Size(155, 22);
            this.ReloadStationsTrayItem.Text = "Reload Stations";
            this.ReloadStationsTrayItem.Click += new System.EventHandler(this.ReloadStationsTrayItem_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Traydio";
            this.TrayIcon.Visible = true;
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NowPlayingTrayItem,
            this.Seperator2TrayItem,
            this.NoStationsMenuItem,
            this.Seperator3TrayItem,
            this.playbackToolStripMenuItem,
            StationsTrayItem,
            this.Seperator1TrayItem,
            this.AboutTrayItem,
            this.QuitTrayItem});
            this.TrayMenu.Name = "TrayMenu";
            this.TrayMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.TrayMenu.Size = new System.Drawing.Size(170, 176);
            // 
            // NowPlayingTrayItem
            // 
            this.NowPlayingTrayItem.Enabled = false;
            this.NowPlayingTrayItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NowPlayingTrayItem.Image = global::Traydio.Properties.Resources.play;
            this.NowPlayingTrayItem.Name = "NowPlayingTrayItem";
            this.NowPlayingTrayItem.Size = new System.Drawing.Size(169, 22);
            this.NowPlayingTrayItem.Text = "(Nothing Playing)";
            // 
            // Seperator2TrayItem
            // 
            this.Seperator2TrayItem.Name = "Seperator2TrayItem";
            this.Seperator2TrayItem.Size = new System.Drawing.Size(166, 6);
            // 
            // NoStationsMenuItem
            // 
            this.NoStationsMenuItem.Enabled = false;
            this.NoStationsMenuItem.Name = "NoStationsMenuItem";
            this.NoStationsMenuItem.Size = new System.Drawing.Size(169, 22);
            this.NoStationsMenuItem.Text = "(No Stations)";
            // 
            // Seperator3TrayItem
            // 
            this.Seperator3TrayItem.Name = "Seperator3TrayItem";
            this.Seperator3TrayItem.Size = new System.Drawing.Size(166, 6);
            // 
            // playbackToolStripMenuItem
            // 
            this.playbackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayTrayItem,
            this.StopTrayItem,
            this.ReloadTrayItem,
            this.Separator4MenuItem,
            this.EngineTrayItem});
            this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
            this.playbackToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.playbackToolStripMenuItem.Text = "Playback";
            // 
            // PlayTrayItem
            // 
            this.PlayTrayItem.Name = "PlayTrayItem";
            this.PlayTrayItem.Size = new System.Drawing.Size(110, 22);
            this.PlayTrayItem.Text = "Play";
            this.PlayTrayItem.Click += new System.EventHandler(this.PlayTrayItem_Click);
            // 
            // StopTrayItem
            // 
            this.StopTrayItem.Name = "StopTrayItem";
            this.StopTrayItem.Size = new System.Drawing.Size(110, 22);
            this.StopTrayItem.Text = "Stop";
            this.StopTrayItem.Click += new System.EventHandler(this.StopTrayItem_Click);
            // 
            // ReloadTrayItem
            // 
            this.ReloadTrayItem.Name = "ReloadTrayItem";
            this.ReloadTrayItem.Size = new System.Drawing.Size(110, 22);
            this.ReloadTrayItem.Text = "Reload";
            this.ReloadTrayItem.Click += new System.EventHandler(this.ReloadTrayItem_Click);
            // 
            // Separator4MenuItem
            // 
            this.Separator4MenuItem.Name = "Separator4MenuItem";
            this.Separator4MenuItem.Size = new System.Drawing.Size(107, 6);
            // 
            // EngineTrayItem
            // 
            this.EngineTrayItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MpdTrayItem,
            this.WindowsMediaPlayerTrayItem});
            this.EngineTrayItem.Name = "EngineTrayItem";
            this.EngineTrayItem.Size = new System.Drawing.Size(110, 22);
            this.EngineTrayItem.Text = "Engine";
            // 
            // MpdTrayItem
            // 
            this.MpdTrayItem.Name = "MpdTrayItem";
            this.MpdTrayItem.Size = new System.Drawing.Size(194, 22);
            this.MpdTrayItem.Text = "mpd";
            this.MpdTrayItem.Visible = false;
            // 
            // WindowsMediaPlayerTrayItem
            // 
            this.WindowsMediaPlayerTrayItem.Checked = true;
            this.WindowsMediaPlayerTrayItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WindowsMediaPlayerTrayItem.Name = "WindowsMediaPlayerTrayItem";
            this.WindowsMediaPlayerTrayItem.Size = new System.Drawing.Size(194, 22);
            this.WindowsMediaPlayerTrayItem.Text = "Windows Media Player";
            this.WindowsMediaPlayerTrayItem.Click += new System.EventHandler(this.WindowsMediaPlayerTrayItem_Click);
            // 
            // Seperator1TrayItem
            // 
            this.Seperator1TrayItem.Name = "Seperator1TrayItem";
            this.Seperator1TrayItem.Size = new System.Drawing.Size(166, 6);
            // 
            // AboutTrayItem
            // 
            this.AboutTrayItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutTraydioTrayItem,
            this.Separator5TrayItem,
            this.WebsiteTrayItem,
            this.GitHubTrayItem});
            this.AboutTrayItem.Name = "AboutTrayItem";
            this.AboutTrayItem.Size = new System.Drawing.Size(169, 22);
            this.AboutTrayItem.Text = "About";
            // 
            // AboutTraydioTrayItem
            // 
            this.AboutTraydioTrayItem.Name = "AboutTraydioTrayItem";
            this.AboutTraydioTrayItem.Size = new System.Drawing.Size(152, 22);
            this.AboutTraydioTrayItem.Text = "About Traydio";
            this.AboutTraydioTrayItem.Click += new System.EventHandler(this.AboutTraydioTrayItem_Click);
            // 
            // Separator5TrayItem
            // 
            this.Separator5TrayItem.Name = "Separator5TrayItem";
            this.Separator5TrayItem.Size = new System.Drawing.Size(149, 6);
            // 
            // WebsiteTrayItem
            // 
            this.WebsiteTrayItem.Name = "WebsiteTrayItem";
            this.WebsiteTrayItem.Size = new System.Drawing.Size(152, 22);
            this.WebsiteTrayItem.Text = "Website";
            this.WebsiteTrayItem.Click += new System.EventHandler(this.WebsiteTrayItem_Click);
            // 
            // GitHubTrayItem
            // 
            this.GitHubTrayItem.Name = "GitHubTrayItem";
            this.GitHubTrayItem.Size = new System.Drawing.Size(152, 22);
            this.GitHubTrayItem.Text = "GitHub";
            this.GitHubTrayItem.Click += new System.EventHandler(this.GitHubTrayItem_Click);
            // 
            // QuitTrayItem
            // 
            this.QuitTrayItem.Name = "QuitTrayItem";
            this.QuitTrayItem.Size = new System.Drawing.Size(169, 22);
            this.QuitTrayItem.Text = "Quit";
            this.QuitTrayItem.Click += new System.EventHandler(this.QuitTrayItem_Click);
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(520, 357);
            this.MediaPlayer.TabIndex = 2;
            // 
            // Tray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 357);
            this.Controls.Add(this.MediaPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tray";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traydio";
            this.Load += new System.EventHandler(this.Tray_Load);
            this.TrayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.ToolStripMenuItem NowPlayingTrayItem;
        private System.Windows.Forms.ToolStripMenuItem NoStationsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutTrayItem;
        private System.Windows.Forms.ToolStripMenuItem QuitTrayItem;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        private System.Windows.Forms.ToolStripMenuItem OpenStationsTrayItem;
        private System.Windows.Forms.ToolStripMenuItem ReloadStationsTrayItem;
        private System.Windows.Forms.ToolStripSeparator Seperator2TrayItem;
        private System.Windows.Forms.ToolStripSeparator Seperator3TrayItem;
        private System.Windows.Forms.ToolStripSeparator Seperator1TrayItem;
        private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PlayTrayItem;
        private System.Windows.Forms.ToolStripMenuItem StopTrayItem;
        private System.Windows.Forms.ToolStripMenuItem ReloadTrayItem;
        private System.Windows.Forms.ToolStripSeparator Separator4MenuItem;
        private System.Windows.Forms.ToolStripMenuItem EngineTrayItem;
        private System.Windows.Forms.ToolStripMenuItem WindowsMediaPlayerTrayItem;
        private System.Windows.Forms.ToolStripMenuItem MpdTrayItem;
        private System.Windows.Forms.ToolStripMenuItem AboutTraydioTrayItem;
        private System.Windows.Forms.ToolStripSeparator Separator5TrayItem;
        private System.Windows.Forms.ToolStripMenuItem WebsiteTrayItem;
        private System.Windows.Forms.ToolStripMenuItem GitHubTrayItem;
    }
}

