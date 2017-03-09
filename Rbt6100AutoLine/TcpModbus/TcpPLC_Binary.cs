using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace Rbt6100AutoLine.Plc
{
    public class TcpPLC_Binary
    {
        //MC协议各元件对应地址
        public int X_address = 8280;//十进制地址，十六进制为20H，58H
        public int Y_address = 8281;//十进制地址，十六进制为20H，59H
        public int M_address = 8269;//十进制地址，十六进制为20H，4DH

        //MC协议命令种类
        //Bit读取单个位；
        //Byte读取字节；
        public int Bit_ReadCommand = 0x00;
        public int Byte_ReadCommand = 0x01;
        public int Bit_WriteCommand = 0x02;
        public int Byte_WriteCommand = 0x03;
        public int Bit_TestCommmand = 0x04;
        public int Byte_TestCommand = 0x05;
        //
        public string ErrorMessage = null;
        public int ErrorCode = 0;
        private IPAddress ipAddress;
        private int Port = 0;
        public TcpPLC_Binary() { }

        public TcpPLC_Binary(string ip, int port)
        {
            ipAddress = IPAddress.Parse(ip);
            Port = port;
        }

        /// <summary>
        /// 读取PLC数据
        /// </summary>
        /// <param name="command"></param>
        /// <param name="address"></param>
        /// <param name="size"></param>
        /// <param name="buf"></param>
        /// <returns></returns>
        public int DeviceRead(int command, int address, int size, byte[] buf)
        {
            byte[] sendBuf = new byte[12];
            sendBuf[0] = (byte)command;
            sendBuf[1] = 0xff;
            sendBuf[2] = 0x0A;
            sendBuf[3] = 0x00;
            sendBuf[4] = 0x00;
            sendBuf[5] = 0x00;
            sendBuf[6] = 0x00;
            sendBuf[7] = 0x00;
            sendBuf[8] = (byte)(address >> 8);
            sendBuf[9] = (byte)((address << 8) | address);
            sendBuf[10] = (byte)size;
            sendBuf[11] = 0x00;
            try
            {
                Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.Connect(ipAddress, Port);
                if (ClientSocket.Connected)
                {
                    ClientSocket.Send(sendBuf, SocketFlags.None);
                    int len = 0;
                    len = ClientSocket.Receive(buf, SocketFlags.None);
                    if (len == 2)
                    {
                        buf[1] = 0x56;
                        ErrorMessage = "读取指令有误";
                        ClientSocket.Disconnect(true);
                        ClientSocket.Dispose();
                        return -2;
                    }
                    ClientSocket.Disconnect(true);
                    ClientSocket.Dispose();
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            catch (SocketException ex)
            {
                ErrorMessage = ex.Message;
                ErrorCode = ex.ErrorCode;
                return -1;
            }
        }

        /// <summary>
        /// 写入PLC数据
        /// </summary>
        /// <param name="address"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public int DeviceWrite(int address, int bit)
        {
            return 0;
        }
    }
}
