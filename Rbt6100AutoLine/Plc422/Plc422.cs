using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Plc422
{
    public class Plc422
    {
        //只能操作M寄存器
        SerialPort ComPort;
        public int X_Addr = 128;
        public int Y_Addr = 160;
        public int M_Addr = 256;

        public enum Plc_Force_Addr
        {
            X_Force_Addr = 1024,
            Y_Force_Addr = 1280,
            M_Force_Addr = 2048,
        }
        public Plc422(string port)
        {
            ComPort = new SerialPort();
            ComPort.BaudRate = 9600;
            ComPort.PortName = port;
            ComPort.StopBits = StopBits.One;
            ComPort.DataBits = 7;
            ComPort.Parity = Parity.Even;
            ComPort.ReadTimeout = 1000;
            try
            {
                ComPort.Open();
            }
            catch (System.Exception ex)
            {
                //    MessageBox.Show(ex.Message);
            }
        }
        ~Plc422()
        {
            ComPort.Close();
        }
        public int ForceON(int addr)
        {
            byte[] SendBuf = new byte[64];
            int tmpAddr = addr;
            int SendAddr = (tmpAddr & 0xff) << 8;
            SendAddr = SendAddr | ((tmpAddr & 0xff00) >> 8);
            SendBuf[0] = 0x02;
            SendBuf[1] = 0x37;
            string SendAddrStr = SendAddr.ToString("X4");
            SendBuf[2] = (byte)SendAddrStr[0];
            SendBuf[3] = (byte)SendAddrStr[1];
            SendBuf[4] = (byte)SendAddrStr[2];
            SendBuf[5] = (byte)SendAddrStr[3];
            SendBuf[6] = 0x03;
            byte Sum = 0;
            for (int i = 1; i < 7; i++)
            {
                Sum += SendBuf[i];
            }
            string SendSumStr = Sum.ToString("X2");
            SendBuf[7] = (byte)SendSumStr[0];
            SendBuf[8] = (byte)SendSumStr[1];
            try
            {
                try
                {
                    ComPort.Write(SendBuf, 0, 9);
                }
                catch (System.TimeoutException ex)
                {
                    //   MessageBox.Show(ex.Message);
                }
                try
                {
                    int RcvByte = ComPort.ReadByte();
                    if (RcvByte == 0x06)
                    {
                        return 0;
                    }
                    else
                    {
                        return -2;
                    }
                }
                catch (System.TimeoutException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            catch (System.Exception ex)
            {
                //  Log.Loger.Error(ex.Message);
            }
            return -1;
        }
        public int ForceOFF(int addr)
        {
            byte[] SendBuf = new byte[64];
            int tmpAddr = addr;
            int SendAddr = (tmpAddr & 0xff) << 8;
            SendAddr = SendAddr | ((tmpAddr & 0xff00) >> 8);
            SendBuf[0] = 0x02;
            SendBuf[1] = 0x38;
            string SendAddrStr = SendAddr.ToString("X4");
            SendBuf[2] = (byte)SendAddrStr[0];
            SendBuf[3] = (byte)SendAddrStr[1];
            SendBuf[4] = (byte)SendAddrStr[2];
            SendBuf[5] = (byte)SendAddrStr[3];
            SendBuf[6] = 0x03;
            byte Sum = 0;
            for (int i = 1; i < 7; i++)
            {
                Sum += SendBuf[i];
            }
            string SendSumStr = Sum.ToString("X2");
            SendBuf[7] = (byte)SendSumStr[0];
            SendBuf[8] = (byte)SendSumStr[1];
            try
            {
                try
                {
                    ComPort.Write(SendBuf, 0, 9);
                }
                catch (System.TimeoutException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                try
                {
                    int RcvByte = ComPort.ReadByte();
                    if (RcvByte == 0x06)
                    {
                        return 0;
                    }
                    else
                    {
                        return -2;
                    }
                }
                catch (System.TimeoutException ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }
            catch (System.Exception ex)
            {
                // Log.Loger.Error(ex.Message);
            }
            return -1;
        }
        public int DeviceWrite(int addr, int size, byte[] buf)
        {
            byte[] SendBuf = new byte[256];
            int SendAddr = addr;
            SendBuf[0] = 0x02;
            SendBuf[1] = 0x31;
            string SendAddrStr = SendAddr.ToString("X4");
            SendBuf[2] = (byte)SendAddrStr[0];
            SendBuf[3] = (byte)SendAddrStr[1];
            SendBuf[4] = (byte)SendAddrStr[2];
            SendBuf[5] = (byte)SendAddrStr[3];
            string SendSizeStr = size.ToString("X2");
            SendBuf[6] = (byte)SendSizeStr[0];
            SendBuf[7] = (byte)SendSizeStr[1];
            for (int i = 0; i < size; i++)
            {
                string SendDataStr = buf[i].ToString("X2");
                SendBuf[8 + i * 2] = (byte)SendDataStr[0];
                SendBuf[8 + i * 2 + 1] = (byte)SendDataStr[1];
            }
            SendBuf[8 + size * 2] = 0x03;
            byte Sum = 0;
            for (int i = 1; i < 8 + size * 2 + 1; i++)
            {
                Sum += SendBuf[i];
            }
            string SendSumStr = Sum.ToString("X2");
            SendBuf[8 + size * 2 + 1] = (byte)SendSumStr[0];
            SendBuf[8 + size * 2 + 2] = (byte)SendSumStr[1];
            try
            {
                try
                {
                    ComPort.Write(SendBuf, 0, 8 + size * 2 + 2 + 1);
                }
                catch (System.TimeoutException ex)
                {
                    //   MessageBox.Show(ex.Message);
                }
                try
                {
                    int RcvByte = ComPort.ReadByte();
                    if (RcvByte == 0x06)
                    {
                        return 0;
                    }
                    else
                    {
                        return -2;
                    }
                }
                catch (System.TimeoutException ex)
                {
                    //   MessageBox.Show(ex.Message);
                }

            }
            catch (System.Exception ex)
            {
                // Log.Loger.Error(ex.Message);
            }
            return -1;
        }
        public int DeviceRead(int addr, int size, byte[] buf)
        {
            byte[] SendBuf = new byte[256];
            int SendAddr = addr;
            SendBuf[0] = 0x02;
            SendBuf[1] = 0x30;
            string SendAddrStr = SendAddr.ToString("X4");
            SendBuf[2] = (byte)SendAddrStr[0];
            SendBuf[3] = (byte)SendAddrStr[1];
            SendBuf[4] = (byte)SendAddrStr[2];
            SendBuf[5] = (byte)SendAddrStr[3];
            string SendSizeStr = size.ToString("X2");
            SendBuf[6] = (byte)SendSizeStr[0];
            SendBuf[7] = (byte)SendSizeStr[1];
            SendBuf[8] = 0x03;
            byte Sum = 0;
            for (int i = 1; i < 9; i++)
            {
                Sum += SendBuf[i];
            }
            string SendSumStr = Sum.ToString("X2");
            SendBuf[9] = (byte)SendSumStr[0];
            SendBuf[10] = (byte)SendSumStr[1];
            try
            {
                try
                {
                    ComPort.Write(SendBuf, 0, 11);
                }
                catch (System.TimeoutException ex)
                {
                    //  MessageBox.Show(ex.Message);
                }
                int len = 0;
                for (int i = 0; i < size * 2 + 4; i++)
                {
                    try
                    {
                        buf[i] = (byte)ComPort.ReadByte();
                    }
                    catch (System.TimeoutException ex)
                    {
                        //  MessageBox.Show(ex.Message);
                        break;
                    }
                    len++;
                    if (i == 0)
                    {
                        if (buf[0] == 0x15)
                        {
                            break;
                        }
                    }
                }
                //  int len = ComPort.Read(buf, 0, size * 2 + 4);
                if (len == 1)
                {
                    if (buf[0] == 0x15)
                    {
                        return -2;
                    }
                }
                else if (len == (size * 2 + 4))
                {
                    Sum = 0;
                    for (int i = 1; i < size * 2 + 4 - 2; i++)
                    {
                        Sum += buf[i];
                    }
                    if ((Sum.ToString("X2").ToUpper()[0] == buf[size * 2 + 4 - 2]) && (Sum.ToString("X2").ToUpper()[1] == buf[size * 2 + 4 - 1]))
                    {
                        return 0;
                    }
                }
            }
            catch (System.Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
            return -1;
        }
    }
}
