using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Help.NetHelp.SocketHelp
{
    /// <summary>
    /// Socket基类
    /// </summary>
    public abstract class SocketBase
    {
        public Socket Socket;
        public IPEndPoint IPEndPoint;
        /// <summary>
        /// 以utf-8编码发送数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool Send(Socket socket,string data)
        {
            try
            {
                var bs = Encoding.UTF8.GetBytes(data);
                byte[] ls, d;
                int length, tl = 0;
                if (bs.LongLength > 1550)
                {
                    for (int i = 0; i < bs.LongLength;)
                    {
                        tl = 0;
                        length = i + 1550 > bs.Length ? bs.Length - i : 1550;
                        ls = GetLengthBytes(length);
                        d = ls.Concat(bs.Skip(i).Take(length)).ToArray();
                        d[0] += 128;//标识位为1代表还有数据
                        while (tl < d.Length)
                        {
                            tl += socket.Send(d.Skip(tl).ToArray());
                        }
                        i += length;
                    }
                }
                else
                {
                    ls = GetLengthBytes(bs.Length);
                    d = ls.Concat(bs).ToArray();
                    return d.Length == socket.Send(d);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static byte[] GetLengthBytes(int length)
        {
            var ls = BitConverter.GetBytes((ushort)length);
            Array.Reverse(ls);
            return ls;
        }
        private static ushort GetBytesLength(byte[] ls)
        {
            byte[] tls = new byte[2];
            Array.Copy(ls, tls, 2);
            Array.Reverse(tls);
            return BitConverter.ToUInt16(tls, 0);
        }
        public static T[] SubArray<T>(T[] sou,int startIndex,int length=-1)
        {
            if (length == -1)
            {
                length = sou.Length - startIndex;
            }
            T[] ts = new T[length];
            Array.Copy(sou,startIndex,ts,0,length);
            return ts;
        }
        public static T[] Concat<T>(T[] t1,T[] t2)
        {
            T[] n = new T[t1.Length+t2.Length];
            Array.Copy(t1,n,t1.Length);
            Array.Copy(t2,0,n, t1.Length, t2.Length);
            return n;
        }
        public static string Receive(Socket socket)
        {
            var bs = new byte[1552];
            string str = "";
            byte[] data;
            int dataLength = 0;
            try
            {
                do
                {
                    var length = socket.Receive(bs);
                    dataLength = GetBytesLength(bs);
                    var dsl = dataLength > 32768 ? dataLength - 32768 : dataLength;
                    if (length - 2 < dsl)
                    {
                        var bs1 = new byte[1552];
                        var length1 = socket.Receive(bs1);
                        data = SubArray(Concat(bs,bs1),2);
                    }
                    else
                    {
                        data = SubArray(bs, 2);
                    }
                    str += Encoding.UTF8.GetString(data);
                }
                while (dataLength > 32768);
            }
            catch
            {
            }
            return str;
        }
    }
}
