using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Rbt6100AutoLine.Plc;
using Rbt6100AutoLine.TcpMachine;
using System.Net.Sockets;
namespace Rbt6100AutoLine.Controls
{
    public delegate void ReturnThreadInfo(string text);
    public class Rbt6100AutoLineThread
    {
        private Thread runThread;
        private TcpPLC_Binary plc;
        private TcpMachine_Server tcpServer;
        public event ReturnThreadInfo returnthreadInfo;

        public Rbt6100AutoLineThread()
        {
            LoadConfig();
            plc = new TcpPLC_Binary(Settings.Instance.Plc_ConnectIP, Convert.ToInt16(Settings.Instance.Plc_ConnectPort));
            tcpServer = new TcpMachine_Server();
            //   returnthreadInfo("AutoLine|IP&Port|" + Settings.Instance.ServerIP + "|" + Settings.Instance.ServerPort);
        }

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
        private bool isFeedingRobot_Connect = false;
        private bool isAssemblingRobot_Connect = false;
        private bool isBaitingRobot_Connect = false;

        //传感器检测标志位
        private bool isAssemblingCheck_1 = false;
        private bool isBaitingCheck = true;

        /// <summary>
        /// 初始化参数
        /// </summary>
        public void InitParmater()
        {
            isAssemblingCheck_1 = false;
            isBaitingCheck = true;
        }
        /// <summary>
        /// 重置流水线
        /// </summary>
        public void ResetAutoLine()
        {
            //  tcpServer.DisConnect();
            isFeedingRobot_Connect = false;
            isAssemblingRobot_Connect = false;
            isBaitingRobot_Connect = false;
            tcpServer.Close();
            tcpServer = null;
            tcpServer = new TcpMachine_Server();
            InitParmater();
            StopThread();
            StartThread("ListenRobot");
        }

        /// <summary>
        /// 流水线运行线程
        /// </summary>
        /// <param name="obj"></param>
        public void AutoLineRun(object obj)
        {
            string Command = obj as string;
            if (Command == "ListenRobot")
            {
                tcpServer.StartListen(Convert.ToInt32(Settings.Instance.ServerPort));
                tcpServer.reciveSocketData += TcpServer_reciveSocketData;
                //  return;
            }
            //returnthreadInfo("AutoLine|Statue|ListenStart");
            if (isFeedingRobot_Connect && isAssemblingRobot_Connect && isBaitingRobot_Connect)
            {
                if (Command == "Feeding")
                {
                    for (int i = 0; i < clientList.Count; i++)
                    {
                        if (clientList[i].ClientName == "Feed")
                        {
                            tcpServer.Send(clientList[i].Client, "FeedSort_Start");
                            returnthreadInfo("Feed|Command|FeedSort_Start");
                        }
                    }
                }
                if (Command == "AssemblingCheck")
                {
                    bool isRun = true;
                    byte[] buf = new byte[1024];
                    while (isRun) //检测装配传感器1
                    {
                        if (plc.DeviceRead(plc.Bit_ReadCommand, plc.X_address, 1, buf) == 0)
                        {
                            if (buf[2] == 0x10)
                            {
                                isRun = false;
                                isAssemblingCheck_1 = true;
                            }
                        }
                    }
                    while (!((isAssemblingCheck_1 == true) && (isBaitingCheck == true)))
                    {
                        Thread.Sleep(50);
                    }
                    //StopBelt,停止传送带
                    Console.Write("我在执行");
                    Thread.Sleep(50);
                    for (int i = 0; i < clientList.Count; i++)
                    {
                        if (clientList[i].ClientName == "Assembling")
                        {
                            tcpServer.Send(clientList[i].Client, "Assembling_Start");
                            returnthreadInfo("Assembling_1|Command|Assembling_Start");
                        }
                    }
                    isAssemblingCheck_1 = false;
                    isBaitingCheck = false;
                }
                if (Command == "BaitingCheck")
                {
                    for (int i = 0; i < clientList.Count; i++)
                    {
                        if (clientList[i].ClientName == "Feed")
                        {
                            tcpServer.Send(clientList[i].Client, "FeedSort_Start");
                            returnthreadInfo("Feed|Command|FeedSort_Start");
                        }
                    }
                    bool isRun = true;
                    byte[] buf = new byte[1024];
                    while (isRun)
                    {
                        if (plc.DeviceRead(plc.Bit_ReadCommand, plc.X_address, 2, buf) == 0)
                        {
                            if (buf[2] == 0x11)
                            {
                                isRun = false;
                                isBaitingCheck = true;
                            }
                        }
                    }
                    Thread.Sleep(300);
                    Console.Write("我也在执行");
                    for (int i = 0; i < clientList.Count; i++)
                    {
                        if (clientList[i].ClientName == "Baiting")
                        {
                            tcpServer.Send(clientList[i].Client, "BaitingSort_Start");
                            returnthreadInfo("Baiting|Command|BaitingSort_Start");
                        }
                    }
                }
            }
        }
        private List<ClientFile> clientList = new List<ClientFile>();
        private void TcpServer_reciveSocketData(Socket Client, string data)
        {
            //  throw new NotImplementedException();
            if (data == "DisConnect")
            {
                for (int i = 0; i < clientList.Count; i++)
                {
                    if (clientList[i].Client == Client)
                    {
                        if (clientList[i].ClientName == "Feed")
                        {
                            isFeedingRobot_Connect = false;
                        }
                        if (clientList[i].ClientName == "Assembling")
                        {
                            isAssemblingRobot_Connect = false;
                        }
                        if (clientList[i].ClientName == "Baiting")
                        {
                            isBaitingRobot_Connect = false;
                        }
                        returnthreadInfo(clientList[i].ClientName + "|" + "DisConnect" + "|" + Client.RemoteEndPoint);
                        clientList.Remove(clientList[i]);
                    }
                }
            }

            if (data == "FeedingRobot_Connect")//上料机械手连接
            {
                isFeedingRobot_Connect = true;
                ClientFile clientfile = new ClientFile();
                clientfile.Client = Client;
                clientfile.ClientName = "Feed";
                clientList.Add(clientfile);
                returnthreadInfo("Feed|Connect" + "|" + Client.RemoteEndPoint);
            }
            if (data == "AssemblingRobot_Connect")//装配机械手1连接
            {
                isAssemblingRobot_Connect = true;
                ClientFile clientfile = new ClientFile();
                clientfile.Client = Client;
                clientfile.ClientName = "Assembling";
                clientList.Add(clientfile);
                returnthreadInfo("Assembling|Connect" + "|" + Client.RemoteEndPoint);
            }
            //if (data == "AssemblingRobot_2_Connect")//装配机械手2连接
            //{
            //    isAssemblingRobot_2_Connect = true;
            //    ClientFile clientfile = new ClientFile();
            //    clientfile.Client = Client;
            //    clientfile.ClientName = "Assembling_2";
            //    clientList.Add(clientfile);
            //    returnthreadInfo("Assembling_2|Connect" + "|" + Client.RemoteEndPoint);
            //}
            if (data == "BaitingRobot_Connect")//下料机械手连接
            {
                isBaitingRobot_Connect = true;
                ClientFile clientfile = new ClientFile();
                clientfile.Client = Client;
                clientfile.ClientName = "Baiting";
                clientList.Add(clientfile);
                returnthreadInfo("Baiting|Connect" + "|" + Client.RemoteEndPoint);
            }
            if (data == "FeedCamera_Start")//开始识别二维码
            {
                returnthreadInfo("Feed|Command|CameraStart");
                //二维码识别代码
                if (true)
                {
                    returnthreadInfo("Feed|Command|CameraComplete|FeedCamera_Success|Code");
                    tcpServer.Send(Client, "FeedCamera_Success");//机械手接收这条指令后执行上料的后续步骤

                }
                else
                {
                    returnthreadInfo("Feed|Command|CameraComplete|FeedCamera_Error");
                    tcpServer.Send(Client, "FeedCamera_Error");//机械手接收这条指令后回到原点并发送Feed_ReturnHome指令给上位机
                }
            }
            if (data == "Feed_ReturnHome")
            {
                StartThread("Feeding");
            }
            if (data == "FeedSort_Complete")
            {
                Thread.Sleep(30);
                byte[] buf = new byte[1024];
                if (plc.DeviceRead(plc.Bit_ReadCommand, plc.X_address, 2, buf) == 0)//上料传感器检测
                {
                    if (buf[2] == 0x10)
                    {
                        tcpServer.Send(Client, "FeedSort_Complete");//机械手接收这条指令回到原点但不回复Feed_ReturnHome
                        StartThread("AssemblingCheck");
                        returnthreadInfo("Feed|Command|FeedSort_Complete");
                        //startbelt，开启传送带
                    }
                    else
                    {
                        tcpServer.Send(Client, "FeedSort_Error");//机械手接收这条指令并返回原点报错
                        returnthreadInfo("Feed|Command|FeedSort_Error");
                    }
                }
            }
            if (data == "AssemblingCamera_Start")
            {
                returnthreadInfo("Assembling|Command|AssemblingCamera_Start");
                //识别拧螺丝情况
                if (true)
                {
                    returnthreadInfo("Assembling|Command|CameraComplete|AssemblingCamera_Success");
                }
                else
                {
                    // tcpServer.Send(Client, "AssemblingCamera_Error");//
                    returnthreadInfo("Assembling|Command|CameraComplete|AssemblingCamera_Error");
                }
                tcpServer.Send(Client, "AssemblingCamera_Complete");//机械手接收到这条指令后执行装配后的上料动作；
            }
            if (data == "Assembling_Complete")//装配完成指令
            {
                byte[] buf = new byte[1024];
                if (plc.DeviceRead(plc.Bit_ReadCommand, plc.X_address, 2, buf) == 0)//装配完成传感器检测
                {
                    if (buf[2] == 0x01)
                    {
                        StartThread("BaitingCheck");
                        returnthreadInfo("Assembling_1|Command|Assembling_Complete");
                    }
                    else
                    {
                        returnthreadInfo("Assembling_1|Command|Assembling_Error");//错误报错，并停止整条流水线
                    }
                }
            }
            if (data == "BaitingCamera_Start")
            {
                returnthreadInfo("Baiting|Command|CameraStart");
                //拍照
                if (true)
                {
                    tcpServer.Send(Client, "BaitingCamera_Success");
                    returnthreadInfo("Baiting|Command|CameraComplete|BaitingCamera_Success");
                }
            }
            if (data == "BaitingSort_Complete")
            {
                //   isBaitingCheck = false;
                returnthreadInfo("Baiting|Command|BaitingSort_Complete");
            }
        }

        public void StartThread(string command)
        {
            // if (!runThread.IsAlive)
            //  {
            runThread = new Thread(new ParameterizedThreadStart(AutoLineRun));
            runThread.IsBackground = true;
            runThread.Start(command);
            //k   }
        }
        public void StopThread()
        {
            if (runThread.IsAlive)
            {
                runThread.Join();
                runThread = null;
            }
        }
    }
}
