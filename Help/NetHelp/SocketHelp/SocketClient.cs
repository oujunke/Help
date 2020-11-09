using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Help.NetHelp.SocketHelp
{
    public class SocketClient : SocketBase
    {
        public SocketClient(string url, int port)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint = new IPEndPoint(IPAddress.Parse(url), port);
            Connect();
        }
        /// <summary>
        /// 连接
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                Socket.Connect(IPEndPoint);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
