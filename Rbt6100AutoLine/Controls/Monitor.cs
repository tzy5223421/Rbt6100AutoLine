using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Rbt6100AutoLine.Log;

namespace Rbt6100AutoLine.Views
{
    public delegate void UpdataUIEvent(int UIID, string str);
    public partial class Monitor : UserControl
    {
        public event UpdataUIEvent updataui;
        Rbt6100AutoLineThread RbtThread;
        RobotControlThread RcThread;
        public Monitor()
        {
            InitializeComponent();
        }

        private void processControl1_Load(object sender, EventArgs e)
        {

        }
        public void InitMonitor()
        {
            LoadConfig();
            this.Text = this.Text + Settings.Instance.Version;
            Settings.Instance.Version = Settings.VersionString;
            Settings.Instance.Save();
            RbtThread = new Rbt6100AutoLineThread();
            RbtThread.StartThread("ListenRobot");
            RcThread = new RobotControlThread();
            RcThread.StartThread();
            RbtThread.returnthreadInfo += RbtThread_returnthreadInfo;
            updataui(0, Settings.Instance.ServerIP);
            updataui(1, Settings.Instance.ServerPort);
        }
        private void RbtThread_returnthreadInfo(string text)
        {
            //throw new NotImplementedException();
            string[] str = text.Split('|');
            if (str[0] == "AutoLine")
            {
                if (str[1] == "Statue")
                {
                    if (str[2] == "ListenStart")
                    {
                        updataui(2, "开始监听，等待机械手接入");
                    }
                }
            }
            if (str[0] == "Feed")
            {
                if (str[1] == "Connect")
                {
                    robotInfo1.InfoFmbText("上料工作站:" + str[2] + "已连接" + '\r');
                    connectStatue1.FeedIsConnect = true;
                }
                if (str[1] == "DisConnect")
                {
                    robotInfo1.InfoFmbText("上料工作站:" + str[2] + "已断开" + '\r');
                    connectStatue1.FeedIsConnect = false;
                }
                if (str[1] == "Command")
                {
                    if (str[2] == "FeedSort_Start")
                    {
                        robotInfo1.InfoFmbText("开始上料" + '\r');
                    }
                    if (str[2] == "FeedSort_Complete")
                    {
                        robotInfo1.InfoFmbText("上料完成" + '\r');
                    }
                    if (str[2] == "Camera_Start")
                    {
                        robotInfo1.InfoFmbText("开始识别二维码" + '\r');
                    }
                    if (str[2] == "Camera_Complete")
                    {
                        if (str[3] == "Code_Success")
                        {
                            robotInfo1.InfoFmbText("二维码识别成功:" + str[4] + '\r');
                        }
                        if (str[3] == "Code_Error")
                        {
                            robotInfo1.ErrorFmbText("二维码识别失败" + '\r');
                        }
                    }
                    if (str[2] == "FeedSort_Error")
                    {
                        robotInfo1.ErrorFmbText("上料错误,请检查流水线各部件或流程是否正常" + '\r');
                    }
                }
            }
            if (str[0] == "Assembling")
            {
                if (str[1] == "Connect")
                {
                    robotInfo1.InfoMtbText("装配工作站:" + str[2] + "已连接" + '\r');
                    connectStatue1.AssembIsConnect = true;
                }
                if (str[1] == "DisConnect")
                {
                    robotInfo1.InfoMtbText("装配工作站:" + str[2] + "已断开" + '\r');
                    connectStatue1.AssembIsConnect = false;
                }
                if (str[1] == "Command")
                {
                    if (str[2] == "Assembling_Start")
                    {
                        robotInfo1.InfoMtbText("开始装配" + '\r');
                    }
                    if (str[2] == "Assembling_Complete")
                    {
                        robotInfo1.InfoMtbText("装配完成" + '\r');
                    }
                    if (str[2] == "Assembling_Error")
                    {
                        robotInfo1.ErrorMtbText("装配错误,请检查流水线各部件或流程是否正常" + '\r');
                    }
                }
            }
            if (str[0] == "Baiting")
            {
                if (str[1] == "Connect")
                {
                    robotInfo1.InfoRbbText("下料工作站:" + str[2] + "已连接" + '\r');
                    connectStatue1.BaitIsConnect = true;
                }
                if (str[1] == "DisConnect")
                {
                    robotInfo1.InfoRbbText("下料工作站" + str[2] + "已断开" + '\r');
                    connectStatue1.BaitIsConnect = false;
                }
                if (str[1] == "Command")
                {
                    if (str[2] == "BaitingSort_Start")
                    {
                        robotInfo1.InfoRbbText("开始下料" + '\r');
                    }
                    if (str[2] == "BaitingSort_Complete")
                    {
                        robotInfo1.InfoRbbText("下料完成" + '\r');
                    }
                    if (str[2] == "Camera_Start")
                    {
                        robotInfo1.InfoRbbText("开始拍照" + '\r');
                    }
                    if (str[2] == "Camera_Complete")
                    {
                        robotInfo1.InfoRbbText("拍照完成" + '\r');
                    }
                }
            }
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        public void LoadConfig()
        {
            try
            {
                Settings.Instance.Load();
            }
            catch (Exception ex)
            {
                //Loger.Debug(ex.Data.ToString());
                // throw;
            }
        }
        public void StartAutoLine()
        {
            RbtThread.StartThread("Feeding");
        }
        public void StopAutoLine()
        {
            RbtThread.StopThread();
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            robotInfo1.ClearText();
        }
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Rbt6100AutoLine.Controls.DataBase database = new Rbt6100AutoLine.Controls.DataBase("TZY-PC", "Rbt6100Admin", "Rbt6100Admin");
            database.CreateTable();
            //    this.dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rbt6100AutoLine.Controls.DataBase database = new Rbt6100AutoLine.Controls.DataBase("TZY-PC", "Rbt6100Admin", "Rbt6100Admin");
            database.InsertData("AutoLineStatue", i.ToString(), "100", "1", "1");
            i++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = i - 1;
            Rbt6100AutoLine.Controls.DataBase database = new Rbt6100AutoLine.Controls.DataBase("TZY-PC", "Rbt6100Admin", "Rbt6100Admin");
            database.UpDate("AutoLineStatue", "下料状况", id.ToString(), "100");
        }
    }
}
