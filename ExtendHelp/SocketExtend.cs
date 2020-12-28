using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ExtendHelp
{
    public static class SocketExtend
    {
        /// <summary>
        /// 接受数据
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static string Receive(this Socket socket)
        {
            var bs = new byte[4];
            StringBuilder sb = new StringBuilder();
            bool isA = false;
            do
            {
                socket.Receive(bs);
                if (bs[3] == 255)
                {
                    isA = true;
                    bs[3] = 254;
                }
                else
                {
                    isA = false;
                }
                int length = BitConverter.ToInt32(bs.ToArray(), 0);
                if (length == 0) return "";
                var bs1 = new byte[length];
                var num = socket.Receive(bs1);
                while (num < length)
                {
                    num += socket.Receive(bs1, num, length - num, SocketFlags.None);
                }
                Console.WriteLine("length=" + length + "---num=" + num);
                sb.Append(Encoding.UTF8.GetString(bs1));
            } while (isA);
            return sb.ToString();
        }
        public const long NumLength = 4261412864;
        public static void Send(this Socket socket, string str)
        {
            var bs = Encoding.UTF8.GetBytes(str);
            if (bs.LongLength > NumLength)
            {
                for (int i = 0; ; i++)
                {
                    if (bs.LongLength > NumLength * (i + 1))
                    {
                        var ls = BitConverter.GetBytes(NumLength);
                        ls[3] = 255;
                        socket.Send(ls);
                        socket.Send(bs.Substring(i * NumLength, NumLength));
                    }
                    else
                    {
                        var len = bs.LongLength - NumLength * i;
                        socket.Send(BitConverter.GetBytes(len));
                        socket.Send(bs.Substring(i * NumLength, len));
                        break;
                    }
                }
            }
            else
            {
                socket.Send(BitConverter.GetBytes(bs.Length));
                socket.Send(bs);
            }
            //socket.Send(BitConverter.GetBytes(65536));


        }
    }
}
