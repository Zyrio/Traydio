using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Traydio.Services
{
    public class Stations
    {
        public bool ReloadStations(ContextMenuStrip menuStrip, string file)
        {
            menuStrip.Items.RemoveAt(2);

            LoadDynamicMenu(menuStrip, file);

            return true;
        }

        private void LoadDynamicMenu(ContextMenuStrip menuStrip, string xmlPath)
        {
            MemoryStream xmlStream = CompatibalizeConfig(xmlPath);

            XmlTextReader reader = new XmlTextReader(xmlStream);
            LoadDynamicMenu(menuStrip, reader);
        }

        private MemoryStream CompatibalizeConfig(string path)
        {
            var content = File.ReadAllText(path);

            var updatedContent = Utilities.ReplaceLastOccurrence(content, "</group>", "");
            updatedContent = updatedContent.Replace("<group name=\"root\">", "");

            MemoryStream contentStream = Utilities.GenerateStreamFromString(updatedContent, Encoding.Unicode);

            return contentStream;
        }

        private void LoadDynamicMenu(ContextMenuStrip menuStrip, XmlTextReader xmlReader)
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
                if (node.Attributes["url"] != null)
                {
                    menuItem.ToolTipText = node.Attributes["url"].Value;
                }

                menuStrip.Items.Insert(2, menuItem);
                GenerateMenusFromXML(node, (ToolStripMenuItem)menuStrip.Items[2], menuItemName);
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
    }
}
