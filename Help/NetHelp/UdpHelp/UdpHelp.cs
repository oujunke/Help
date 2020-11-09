using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Help.NetHelp.UdpAndTcpHelp
{
    public class UdpHelp
    {
        /// <summary>
        /// 文件传输
        /// </summary>
        public class FileTransfer
        {
            /// <summary>
            /// 当前文件大小
            /// </summary>
            public FileInfo File { set; get; }
            /// <summary>
            /// 目标地址
            /// </summary>
            public IPEndPoint IPPoint { set; get; }
            /// <summary>
            /// 本地地址
            /// </summary>
            public IPEndPoint LoadIpPoint { set; get; }
            /// <summary>
            /// 常用命令缓存
            /// </summary>
            public Dictionary<Model.Enums.Command, byte[]> CacheCommand = new Dictionary<Model.Enums.Command, byte[]>();
            /// <summary>
            /// 获取缓存中常用的命令的字节集
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public byte[] GetCacheCommand(Model.Enums.Command c)
            {
                if (CacheCommand.ContainsKey(c))
                    return CacheCommand[c];
                else
                {
                    byte[] temp = new byte[10];
                    Array.Copy(BitConverter.GetBytes((Int16)c), 0, temp, 8, 2);
                    CacheCommand.Add(c, temp);
                    return temp;
                }
            }
            /// <summary>
            /// 推荐局域网数据字节长度小于1472，Internet数据字节长度小于548
            /// </summary>
            public int DateLength { set; get; }
            /// <summary>
            /// 是否需要确认收到
            /// </summary>
            public bool IsConfirmReceipt { set; get; }
            /// <summary>
            /// 数据
            /// </summary>
            public DataPack[] Data { set; get; }
            /// <summary>
            /// 本地的udp套接字
            /// </summary>
            public UdpClient LoadUdpClient { set; get; }
            /// <summary>
            /// 数据加载下标
            /// </summary>
            public long LoadIndex { set; get; }
            public FileTransfer(int point = 7885)
            {
                DateLength = 548;
                IsConfirmReceipt = true;
                LoadIpPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), point);
                LoadUdpClient = new UdpClient(LoadIpPoint);
            }
            /// <summary>
            /// 传入文件名，创建类
            /// </summary>
            /// <param name="FileName"></param>
            public FileTransfer(string FileName)
                : this()
            {
                File = new FileInfo(FileName);
            }
            /// <summary>
            /// 发送文件
            /// </summary>
            /// <returns></returns>
            public bool SendFile()
            {
                new Thread(Load).Start();
                new Thread(Send).Start();
                //new Thread(ConfirmReceipt).Start();
                return true;
            }
            string path = @"Z:\123.txt";
            FileStream fs = null;
            /// <summary>
            /// 接收文件
            /// </summary>
            public void ReceiveFile()
            {
                new Thread(() =>
                {
                    IPEndPoint temp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 888);
                    byte[] tempB = null;
                    while (true)
                    {
                        tempB = LoadUdpClient.Receive(ref temp);
                        byte[] temp1 = new byte[2];
                        Array.Copy(tempB, 0, temp1, 0, 2);
                        short Command = BitConverter.ToInt16(temp1, 0);
                        long index = 0;
                        switch (Command)
                        {
                            case (Int16)Model.Enums.Command.SendTheFileHeader:
                                temp1 = new byte[8];
                                Array.Copy(tempB, 2, temp1, 0, 8);
                                long size = BitConverter.ToInt64(temp1, 0);//文件大小
                                File = new FileInfo(path);
                                fs = File.OpenWrite();
                                fs.SetLength(size);
                                Data = new DataPack[size / (DateLength - 10)];
                                break;
                            case (Int16)Model.Enums.Command.SendData:
                                if (Data != null)
                                {
                                    temp1 = new byte[8];
                                    Array.Copy(tempB, 2, temp1, 0, 8);
                                    index = BitConverter.ToInt64(temp1, 0);
                                    Data[index] = new DataPack() { Date = tempB };
                                    temp1 = new byte[10];
                                    Array.Copy(tempB, temp1, 8);
                                    temp1[8] = (byte)Model.Enums.Command.ConfirmReceipt;
                                    LoadUdpClient.Send(temp1, temp1.Length, temp);
                                }
                                break;
                            case (Int16)Model.Enums.Command.SendEnd:
                                bool b = true;
                                temp1 = new byte[8];
                                Array.Copy(tempB, 2, temp1, 0, 8);
                                index = BitConverter.ToInt64(temp1, 0);
                                foreach (DataPack dp in Data)
                                {
                                    if (dp == null) b = false;
                                }
                                if (Data.LongLength > 0 && b)
                                {
                                    if (fs != null)
                                    {
                                        fs.Position = index * (DateLength - 10);
                                        fs.Write(tempB, 10, tempB.Length - 10);
                                        fs.Close();
                                    }
                                }
                                break;

                        }
                    }
                }).Start();
            }
            /// <summary>
            /// 发送
            /// </summary>
            /// <returns></returns>
            public void Load()
            {
                int dataLength = DateLength - 10;//前8个为序号位
                long dateCount = File.Length / dataLength;
                byte[] type = BitConverter.GetBytes((Int16)Model.Enums.Command.SendData);
                Data = new DataPack[dateCount];
                byte[] temp = new byte[dataLength];
                byte[] temp1 = null;
                using (FileStream fs = File.OpenRead())
                {
                    fs.Position = LoadIndex * dataLength;
                    for (; LoadIndex < dateCount; LoadIndex++)
                    {
                        temp1 = new byte[DateLength];
                        fs.Read(temp, 0, dataLength);
                        Array.Copy(type, 0, temp1, 0, 2);
                        Array.Copy(BitConverter.GetBytes(LoadIndex), 0, temp1, 2, 8);
                        temp.CopyTo(temp1, 10);
                        Data[LoadIndex] = new DataPack() { Date = temp1 };
                    }
                    if (dateCount * dataLength < File.Length)
                    {
                        long legth = File.Length - (dateCount * dataLength);
                        temp1 = new byte[legth];
                        fs.Read(temp, 0, (int)legth);
                        Array.Copy(type, 0, temp1, 0, 2);
                        Array.Copy(BitConverter.GetBytes(LoadIndex), 0, temp1, 2, 8);
                        Array.Copy(temp, 0, temp1, 0, temp1.Length);
                        Data[LoadIndex] = new DataPack() { Date = temp1 };
                    }
                }
            }
            /// <summary>
            /// 发送数据
            /// </summary>
            public void Send()
            {
                byte[] temp = new byte[10];
                Array.Copy(BitConverter.GetBytes((Int16)Model.Enums.Command.SendTheFileHeader), 0, temp, 0, 2);
                Array.Copy(BitConverter.GetBytes(File.Length), 0, temp, 2, 8);
                LoadUdpClient.Send(temp, temp.Length, IPPoint);
                while (true)
                {
                    bool b = true;
                    for (int i = 0; i < LoadIndex; i++)
                    {
                        b = true;
                        if (Data[i] != null)
                        {
                            LoadUdpClient.Send(Data[i].Date, DateLength, IPPoint);
                            b = false;
                        }
                    }
                    if (Data != null && (LoadIndex == Data.LongLength && b))
                        break;
                }
                temp = new byte[2];
                Array.Copy(BitConverter.GetBytes((Int16)Model.Enums.Command.SendEnd), 0, temp, 0, 2);
                LoadUdpClient.Send(temp, temp.Length, IPPoint);
            }
            /// <summary>
            /// 接收确认
            /// </summary>
            public void ConfirmReceipt()
            {
                IPEndPoint temp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 888);
                byte[] tempB = null;
                while (true)
                {
                    tempB = LoadUdpClient.Receive(ref temp);
                    byte[] temp1 = null;
                    if (tempB.Length == 10)//前两位是操作位，后八位是序号位
                    {
                        temp1 = new byte[8];
                        Array.Copy(tempB, 2, temp1, 0, 8);
                        long index = BitConverter.ToInt64(temp1, 0);
                        temp1 = new byte[2];
                        Array.Copy(tempB, 0, temp1, 0, 2);
                        short Command = BitConverter.ToInt16(temp1, 0);
                        switch (Command)
                        {
                            case (Int16)Model.Enums.Command.ConfirmReceipt:
                                Data[index] = null;
                                break;
                        }
                    }
                }
            }
            public void SplitDate()
            {

            }
            public class DataPack
            {
                /// <summary>
                /// 数据
                /// </summary>
                public byte[] Date;
            }
        }
    }
}
