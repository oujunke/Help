using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Help.NetHelp.SocketHelp
{
    public class SocketServer : SocketBase
    {
        public SocketServer(int port)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint = new IPEndPoint(IPAddress.Any, port);
            Socket.Bind(IPEndPoint);
            Socket.Listen(100);
            Socket.ReceiveTimeout = 100;
        }
        /// <summary>
        /// 异步监听连接
        /// </summary>
        /// <param name="act"></param>
        public void AcceptAsync(Action<SocketAsyncEventArgs> act = null)
        {
            SocketAsyncEventArgs socketAsync = new SocketAsyncEventArgs();
            if (act == null)
            {
                socketAsync.Completed += SocketAsync_Completed;
            }
            else
            {
                socketAsync.Completed += new EventHandler<SocketAsyncEventArgs>((o,s)=> act(s));
            }
            Socket.AcceptAsync(socketAsync);
        }
        /// <summary>
        /// 监听连接
        /// </summary>
        /// <returns></returns>
        public Socket Accept()
        {
            return Socket.Accept();
        }
        /// <summary>
        /// 异步监听连接成功
        /// </summary>
        public event Action<SocketAsyncEventArgs> AcceptCompleted;
        private void SocketAsync_Completed(object sender, SocketAsyncEventArgs e)
        {
            AcceptCompleted(e);
        }
    }
}
