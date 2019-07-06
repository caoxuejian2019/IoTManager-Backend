using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace IoTManager.Tcp.MonitorDataSync.Services
{
    public sealed class SockerManager
    {
        public void StartMonitorLocalMachinePort(string port)
        {
            //ip地址
            IPAddress ip = IPAddress.Parse(IPAddress.Any.ToString());
            //IP地址和端口号
            IPEndPoint point = new IPEndPoint(ip, int.Parse(port));
            //创建监听Socket
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定IP和端口号
            socket.Bind(point);
            ////通常每个套接字地址(协议/网络地址/端口)只允许使用一次。
            ////开启监听Socket     监听队列的长度
            socket.Listen(10);
            //监听端口号，如果有客户端连接，创建新的Socket用于通信
            //Socket connSocket = socket.Accept();
            Thread t = new Thread(Listen);
            t.IsBackground = true;
            t.Start(socket);
        }

        private void Listen(object obj)
        {
            Socket socket = obj as Socket;
            //这样可以不断的监听客户端发送的连接请求
            while (true)
            {
                //通常每个套接字地址(协议/网络地址/端口)只允许使用一次。
                //监听端口号，如果有客户端连接，创建新的Socket用于通信
                //socket.Accept();会阻塞窗体的运行
                Socket connSocket = socket.Accept();
                //当前连接的客户端IP和端口号
                string ipport = connSocket.RemoteEndPoint.ToString();
                //本机IP和端口号
                //connSocket.LocalEndPoint
                Thread t = new Thread(ReceiveMsg);
                t.IsBackground = true;
                t.Start(connSocket);
            }
        }

        private void ReceiveMsg(object obj)
        {
            Socket socket = obj as Socket;
            while (true)
            {
                byte[] buffer = new byte[1024 * 100];
                int num = socket.Receive(buffer);
                string message = Encoding.UTF8.GetString(buffer, 0, num);
                Console.WriteLine(message);
                //return message;
                //using (FileStream fs = new FileStream($"D:\\{num}.txt", FileMode.Append, FileAccess.Write))
                //{
                //    fs.Write(Encoding.UTF8.GetBytes(message));
                //}
                //File.AppendAllLines("C:\\1.txt", new string[] { message });
            }
        }

        public void SendCommand(string ipAddress, string port, string command)
        {
            IPAddress ip = IPAddress.Parse(ipAddress);
            //客户端连接服务器的IP和端口号
            IPEndPoint point = new IPEndPoint(ip, int.Parse(port));
            //创建通信连接的Socket
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(point);
                byte[] buffer = Encoding.UTF8.GetBytes(command);
                socket.Send(buffer);
            }
            catch (Exception ex)
            {
                throw ex;
                //ShowMsg(ex.Message);
            }
            finally
            {
                //socket.Disconnect(true);
                socket.Close();
                socket.Dispose();
            }
        }
    }
}
