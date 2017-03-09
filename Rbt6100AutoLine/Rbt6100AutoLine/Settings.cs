using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Rbt6100AutoLine
{
    public class Settings
    {
        static Settings _instance;
        static int Revision = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Revision;
        static int iBuild = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build;
        public static string VersionString = "  V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Settings();
                }
                return _instance;
            }
        }
        public Settings() { }

        public static Dictionary<string, string> config = new Dictionary<string, string>();
        const string FileName = "config.xml";

        public string this[string key]
        {
            get
            {
                string value = null;
                config.TryGetValue(key, out value);
                return value;
            }
            set { config[key] = value; }
        }
        public IEnumerable<string> Keys
        {
            // the "ToArray" makes this safe for someone to add items while enumerating.
            get { return config.Keys.ToArray(); }
        }

        public bool ContainsKey(string key)
        {
            return config.ContainsKey(key);
        }

        #region 属性
        public string Version
        {
            get
            {
                string str = this["Version"];
                if (str == "")
                {
                    this["Version"] = VersionString;
                }
                return this["Version"];
            }
            set { this["Version"] = value; }
        }
        public string Publisher
        {
            get
            {
                this["Publisher"] = "湖南科瑞特科技股份有限公司";
                return this["Publisher"];
            }
            set { this["Publisher"] = value; }
        }
        public string Plc_ConnectIP
        {
            get
            {
                string str = this["Plc_ConnectIP"];
                if (str == "")
                {
                    this["Plc_ConnectIP"] = "192.168.2.250";
                }
                return this["Plc_ConnectIP"];
            }
            set { this["Plc_ConnectIP"] = value; }
        }
        public string Plc_ConnectPort
        {
            get
            {
                string str = this["Plc_ConnectPort"];
                if (str == "")
                {
                    this["Plc_ConnectPort"] = "3000";
                }
                return this["Plc_ConnectPort"];
            }
            set { this["Plc_ConnectPort"] = value; }
        }
        public string ServerIP
        {
            get
            {
                string str = this["ServerIP"];
                if (str == "")
                {
                    this["ServerIP"] = "192.168.2.1";
                }
                return this["ServerIP"];
            }
            set { this["ServerIP"] = value; }
        }
        public string ServerPort
        {
            get
            {
                string str = this["ServerPort"];
                if (str == "")
                {
                    this["ServerPort"] = "5000";
                }
                return this["ServerPort"];
            }
            set { this["ServerPort"] = value; }
        }
        public string LastTimeLogin
        {
            get { return this["LastTimeLogin"]; }
            set { this["LastTimeLogin"] = value; }
        }
        public string ProtocolPath
        {
            get
            {
                string str = this["ProtocolPath"];
                if (string.IsNullOrEmpty(str))
                {
                    str = GetDefaultProtocolPath();
                    if (!Directory.Exists(str))
                    {
                        Directory.CreateDirectory(str);
                    }
                }
                return str;
            }
            set { this["ProtocolPath"] = value; }
        }
        #endregion

        #region 方法

        public static string GetDefaultProtocolPath()
        {
            return Application.StartupPath + Path.DirectorySeparatorChar;
            // return path;
        }
        /// <summary>
        /// Install directory path
        /// </summary>
        /// <returns></returns>
        public static string GetRunningDirectory()
        {
            return Application.StartupPath + Path.DirectorySeparatorChar;
        }
        static string GetConfigFullPath()
        {
            // old path details
            string directory = GetRunningDirectory();
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var path = Path.Combine(directory, FileName);

            // get new path details
            var newdir = GetDefaultProtocolPath();

            if (!Directory.Exists(newdir))
            {
                Directory.CreateDirectory(newdir);
            }

            var newpath = Path.Combine(newdir, FileName);

            // check if oldpath config exists
            if (File.Exists(path))
            {
                // is new path exists already, then dont do anything
                if (!File.Exists(newpath))
                {
                    // move to new path
                    File.Move(path, newpath);

                    // copy other xmls as this will be first run
                    var files = Directory.GetFiles(directory, "*.xml", SearchOption.TopDirectoryOnly);

                    foreach (var file in files)
                    {
                        File.Copy(file, newdir + Path.GetFileName(file));
                    }
                }
            }
            return newpath;
        }

        public void Load()
        {
            using (XmlTextReader xmlreader = new XmlTextReader(GetConfigFullPath()))
            {
                while (xmlreader.Read())
                {
                    if (xmlreader.NodeType == XmlNodeType.Element)
                    {
                        try
                        {
                            switch (xmlreader.Name)
                            {
                                case "config":
                                    break;
                                case "Config":
                                    break;
                                case "xml":
                                    break;
                                default:
                                    config[xmlreader.Name] = xmlreader.ReadString();
                                    break;
                            }
                        }
                        // silent fail on bad entry
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }
        public void Save()
        {
            string filename = GetConfigFullPath();
            using (XmlTextWriter xmlwriter = new XmlTextWriter(filename, Encoding.UTF8))
            {
                xmlwriter.Formatting = Formatting.Indented;
                xmlwriter.WriteStartDocument();
                xmlwriter.WriteStartElement("Config");
                foreach (string key in config.Keys)
                {
                    try
                    {
                        if (key == "Config" || key.Contains("/")) // "/dev/blah"
                            continue;

                        xmlwriter.WriteElementString(key, "" + config[key]);
                    }
                    catch
                    {
                    }
                }
                xmlwriter.WriteEndElement();
                xmlwriter.WriteEndDocument();
                xmlwriter.Close();
            }
        }
        #endregion 
    }
}
