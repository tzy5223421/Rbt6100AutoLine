using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rbt6100AutoLine.Plc;
using Rbt6100AutoLine.Log;

namespace Rbt6100AutoLine
{
    public partial class RbtAutoMain : Form
    {
        TcpPLC_Binary plc;
        public RbtAutoMain()
        {
            InitializeComponent();
            LoadConfig();
            plc = new TcpPLC_Binary(Settings.Instance.Plc_ConnectIP, Convert.ToInt16(Settings.Instance.Plc_ConnectPort));
            backgroundWorker1.RunWorkerAsync(); toolStripStatusLabel1.Text = null;
            this.Text = this.Text + Settings.Instance.Version;
            Settings.Instance.Version = Settings.VersionString;
            Settings.Instance.Save();
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
                // throw;
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                byte[] buf = new byte[256];
                if (plc.DeviceRead(plc.Bit_ReadCommand, plc.X_address, 2, buf) == 0)
                {
                    if (buf[2] == 0x10)
                    {
                        panel1.BackgroundImage = Rbt6100AutoLine.Properties.Resources.green_Light;
                    }
                    else
                    {
                        panel1.BackgroundImage = Rbt6100AutoLine.Properties.Resources.red_Light;
                    }
                }
                else
                {
                    //toolStrip1.Invoke(new Action(() => { this.toolStripStatusLabel1.Text = plc.ErrorMessage; }));
                    UpdataStatueLabel(plc.ErrorMessage);
                    Loger.Info(string.Format("当前时间{0}", DateTime.Now.ToString()) + plc.ErrorMessage);
                    //  Loger.Error(plc.ErrorCode.ToString() + plc.ErrorMessage);
                }
                System.Threading.Thread.Sleep(30);
            }
        }

        public void UpdataStatueLabel(string str)
        {
            toolStrip1.Invoke(new Action(() => { this.toolStripStatusLabel1.Text = str; }));
            //Loger.Error();
        }
        private void tsr_btn_config_Click(object sender, EventArgs e)
        {
            RbtSetting rbtsetting = new RbtSetting();
            rbtsetting.ShowDialog();
        }
    }
}
