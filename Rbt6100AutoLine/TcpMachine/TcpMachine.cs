using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Rbt6100AutoLine.TcpMachine
{
    public delegate void ReciveSocketData(Socket Client, string strData);
    public class TcpMachine_Server
    {

        private Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public event ReciveSocketData reciveSocketData;
        private Thread ServerThread;
        public List<Socket> Client = new List<Socket>();
        private byte[] MsgBuffer = new byte[1024];

        public TcpMachine_Server()
        {
        }

        public void StartListen(int port)
        {
            try
            {
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Any, port);
                ServerSocket.Bind(EndPoint);
                ServerThread = new Thread(new ThreadStart(ReciveAccept));
                ServerThread.IsBackground = true;
                ServerThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void ReadData(object obj)
        {
            Socket ReadClient = (Socket)obj;
            bool run = true;
            while (run)
            {
                try
                {
                    Thread.Sleep(50);
                    byte[] result = new byte[1024];
                    int length = ReadClient.Receive(result);
                    if (length == 0)
                    {
                        //  reciveSocketData(ReadClient.RemoteEndPoint, result);
                        for (int i = 0; i < Client.Count; i++)
                        {
                            if (ReadClient.RemoteEndPoint == Client[i].RemoteEndPoint)
                            {
                                reciveSocketData(ReadClient, "DisConnect");
                                Client.Remove(Client[i]);
                            }
                        }
                        ReadClient.Close();
                        break;
                    }
                    //string str = System.Text.Encoding.Default.GetString(result);
                    //if (send)
                    //{
                    //    Send_Byte(result);
                    //    send = false;
                    //}
                    reciveSocketData(ReadClient, Encoding.Default.GetString(result, 0, length));
                }
                catch { }
            }
        }

        protected void ReciveAccept()
        {
            while (true)
            {
                Thread.Sleep(50);
                try
                {
                    ServerSocket.Listen(10);
                    while (true)
                    {
                        Socket sokcet = ServerSocket.Accept();
                        Client.Add(sokcet);
                        ThreadPool.QueueUserWorkItem(new WaitCallback(ReadData), sokcet);
                    }
                }
                catch (SocketException sex)
                {
                    Console.WriteLine(sex.Message);
                }
            }
        }

        public void SendAll_Str(string str)
        {
            byte[] buffer = Encoding.Default.GetBytes(str);
            try
            {
                if (Client.Count != 0)
                {
                    for (int i = 0; i < Client.Count; i++)
                    {
                        Client[i].Send(buffer, 0, buffer.Length, SocketFlags.None);
                    }
                }
                else
                {
                }
            }
            catch { }
        }

        public void Send_Byte(byte[] buffer)
        {
            try
            {
                if (Client.Count != 0)
                {
                    for (int i = 0; i < Client.Count; i++)
                    {
                        Client[i].Send(buffer, 0, buffer.Length, SocketFlags.None);
                    }

                }
            }
            catch { }
        }

        public void Send(Socket client, string str)
        {
            byte[] buffer = Encoding.Default.GetBytes(str);
            if (client.Connected)
            {
                try { client.Send(buffer, 0, buffer.Length, SocketFlags.None); }
                catch { }
            }
        }

        public void Close()
        {
            try
            {
                ServerThread.Abort();
                ServerSocket.Disconnect(true);
                ServerSocket.Close();
            }
            catch { }
        }
    }
}
