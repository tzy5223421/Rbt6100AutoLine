using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Rbt6100AutoLine.Plc;

namespace Rbt6100AutoLine
{
    public class RobotControlThread
    {
        private Thread controlThread;
        private TcpPLC_Binary plc;
        private bool isThreadRun = false;
        public RobotControlThread()
        {
            LoadConfig();
            plc = new TcpPLC_Binary(Settings.Instance.Plc_ConnectIP, Convert.ToInt16(Settings.Instance.Plc_ConnectPort));
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
        private void RunThread()
        {
            while (isThreadRun)
            {
                Thread.Sleep(50);
                byte[] buf = new byte[1024];
                if (plc.DeviceRead(plc.Bit_ReadCommand, plc.X_address, 8, buf) == 0)
                {
                    if (buf[3] == 0x10) //停止
                    {

                    }
                    if (buf[3] == 0x01)
                    {

                    }
                }
            }
        }
        public void StartThread()
        {
            controlThread = new Thread(RunThread);
            controlThread.IsBackground = true;
            isThreadRun = true;
            controlThread.Start();
        }
        public void StopThread()
        {
            controlThread.Join();
            isThreadRun = false;
            controlThread.Join();
        }
    }
}
