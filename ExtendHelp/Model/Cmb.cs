using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExtendHelp.Model
{
    public class Cmb : IDisposable
    {
        /// <summary>
        /// 默认cmb执行器
        /// </summary>
        public static Cmb DefaultCmb;
        private Process process;
        /// <summary>
        /// 上一次输出的数据
        /// </summary>
        public string LastOutString;
        private ConcurrentQueue<string> waitData = new ConcurrentQueue<string>();
        private object lockObj = new object();
        /// <summary>
        /// 该cmd的输出
        /// </summary>
        public event Action<string> OutputDataReceived;
        public Cmb()
        {
            process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            process.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            process.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            process.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            process.StartInfo.CreateNoWindow = true;//不显示程序窗口
            process.OutputDataReceived += OutputHandler;
            process.ErrorDataReceived += OutputHandler; ;
            process.Start();//启动程序
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        static Cmb()
        {
            DefaultCmb = new Cmb();
        }
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmd"></param>
        public void Run(string cmd)
        {
            lock (lockObj)
            {
                process.StandardInput.WriteLine(cmd + "\r\n");
            }
        }
        /// <summary>
        /// 执行命令组
        /// </summary>
        /// <param name="cmds"></param>
        /// <returns></returns>
        public List<string> RunWaitReturn(params string[] cmds)
        {
            return RunWaitReturn((IEnumerable<string>)cmds);
        }
        /// <summary>
        /// 执行命令组
        /// </summary>
        /// <param name="cmds"></param>
        /// <returns></returns>
        public List<string> RunWaitReturn(IEnumerable<string> cmds)
        {
            List<string> result = new List<string>();
            lock (lockObj)
            {
                foreach (var cmd in cmds)
                {
                    result.Add(RunWaitReturn(cmd));
                }
            }
            return result;
        }
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="waitTime">等待多少秒超时(waitTime<=0时不超时)</param>
        /// <returns></returns>
        public string RunWaitReturn(string cmd, int waitTime = 10)
        {
            lock (lockObj)
            {
                process.StandardInput.WriteLine(cmd + "\r\n");
                var inputText = ">" + cmd;
                for (int i = 0; ; i++)
                {
                    if (waitTime > 0 && i > waitTime * 10)
                    {
                        break;
                    }
                    if (waitData.Count>0)
                    {
                        return GetAllMessage();
                    }
                    Thread.Sleep(100);
                }
                throw new Exception("执行超时");
            }
        }
        public string GetAllMessage()
        {
            StringBuilder builder = new StringBuilder();
            while(waitData.TryDequeue(out string str))
            {
                builder.AppendLine(str);
            }
            return builder.ToString();
            //Console.WriteLine(process.StandardError.ReadLine());
        }
        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                LastOutString = outLine.Data;
                waitData?.Enqueue(outLine.Data);
                OutputDataReceived?.Invoke(outLine.Data);

            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }
                if (process != null)
                {
                    process.Close();
                }
                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                waitData = null;
                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        ~Cmb()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(false);
        }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
