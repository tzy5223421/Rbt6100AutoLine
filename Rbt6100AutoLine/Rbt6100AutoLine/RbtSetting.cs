using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rbt6100AutoLine.Log;

namespace Rbt6100AutoLine
{
    public partial class RbtSetting : Form
    {
        public RbtSetting()
        {
            InitializeComponent();
            LoadConfig();
            this.Text = "流水线控制设置";
            this.txt_plcConnectIP.Text = Settings.Instance.Plc_ConnectIP;
            this.txt_plcConnectPort.Text = Settings.Instance.Plc_ConnectPort;
            this.txt_serverIP.Text = Settings.Instance.ServerIP;
            this.txt_serverPort.Text = Settings.Instance.ServerPort;
        }
        public void LoadConfig()
        {
            try
            {
                Settings.Instance.Load();
            }
            catch (Exception ex)
            {
                Loger.Debug(ex.Data.ToString());
            }
        }
        public void SaveConfig()
        {
            try
            {
                Settings.Instance.ServerPort = this.txt_serverPort.Text;
                Settings.Instance.ServerIP = this.txt_serverIP.Text;
                Settings.Instance.Plc_ConnectIP = this.txt_plcConnectIP.Text;
                Settings.Instance.Plc_ConnectPort = this.txt_plcConnectPort.Text;
                Settings.Instance.Save();
            }
            catch (Exception ex)
            {
                Loger.Debug(ex.Data.ToString());
                //throw;
            }
        }

        private void RbtSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }
    }
}
