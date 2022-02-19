using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LauncherUpdater
{
    internal class Settings
    {
        public static string IP_ADDRESS = "116.202.144.25";
        public static int PORT = 20;

        private string SETTINGS_DIR = "Settings.xml";

        // Load settings.
        public void Load()
        {
            if (File.Exists(SETTINGS_DIR))
            {
                using (var xml = new XmlTextReader(SETTINGS_DIR))
                {
                    try
                    {
                        while (xml.Read())
                        {
                            if (xml.NodeType == XmlNodeType.Element && xml.Name == "IP_Address")
                            {
                                IP_ADDRESS = xml.ReadString();
                            }
                            else if (xml.NodeType == XmlNodeType.Element && xml.Name == "Port")
                            {
                                PORT = int.Parse(xml.ReadString());
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
        }

        // Save/Create settings.
        public bool Save()
        {
            try
            {
                var document = new XmlDocument();
                var main_node = document.CreateElement("Settings");
                document.AppendChild(main_node);

                var address_node = document.CreateElement("IP_Address");
                address_node.InnerText = IP_ADDRESS;
                main_node.AppendChild(address_node);

                var port_node = document.CreateElement("Port");
                port_node.InnerText = PORT.ToString();
                main_node.AppendChild(port_node);

                document.Save(SETTINGS_DIR);

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
