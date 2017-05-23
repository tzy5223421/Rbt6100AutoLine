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
using Rbt6100AutoLine.Views;

namespace Rbt6100AutoLine
{
    public partial class RbtAutoMain : Form
    {
        public RbtAutoMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 界面UI更新
        /// </summary>
        /// <param name="UIID"></param>
        /// <param name="obj"></param>
        private void Monitor1_updataui(int UIID, object obj)
        {
            // throw new NotImplementedException();
            string str = obj as string;
            if (UIID == 0)
            {
                this.Invoke(new Action(() => { this.ipaddress.Text = str; }));
            }
            if (UIID == 1)
            {
                this.Invoke(new Action(() => { this.port.Text = str; }));
            }
            if (UIID == 2)
            {
                this.Invoke(new Action(() => { this.autolineStatue.Text = str; }));
            }
        }

        private void tsr_btn_config_Click(object sender, EventArgs e)
        {
            RbtSetting rbtsetting = new RbtSetting();
            rbtsetting.ShowDialog();
        }

        private void tsr_btn_check_Click(object sender, EventArgs e)
        {
            //    Rbt6100AutoLine.Controls.DataBase database = new Rbt6100AutoLine.Controls.DataBase("TZY-PC", "Rbt6100Admin", "Rbt6100Admin");
            //    database.InsertData("AutoLineStatue", "0", "100", "1", "1");
        }

        private void RbtAutoMain_Load(object sender, EventArgs e)
        {
            monitor1.updataui += Monitor1_updataui;
            monitor1.InitMonitor();
        }

        private void tsr_btn_disconnect_Click(object sender, EventArgs e)
        {
            //Rbt6100AutoLine.Controls.DataBase database = new Rbt6100AutoLine.Controls.DataBase("TZY-PC", "Rbt6100Admin", "Rbt6100Admin");
            //database.DeleteDate();
        }

        private void tsr_btn_connect_Click(object sender, EventArgs e)
        {
            //Rbt6100AutoLine.Controls.DataBase database = new Rbt6100AutoLine.Controls.DataBase("TZY-PC", "Rbt6100Admin", "Rbt6100Admin");
            //database.UpDate("AutoLineStatue", "下料状况", "0", "100");
        }
    }
}
