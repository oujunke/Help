using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Management;
using System.Threading;
using System.Windows.Threading;
using System.Collections.Specialized;
using mgen_processes;
using Help.WinFormsHelp.WinApi.Win32Api;

namespace Help.WinFormsHelp.WinHelp
{
    public static class WGHelp
    {
        #region
        //获取窗体的进程标识ID
        /// <summary>
        /// 获取窗体的进程标识ID(窗口主题)
        /// </summary>
        /// <param name="windowTitle"></param>
        /// <returns>进程标识ID</returns>
        public static int GetPid(string windowTitle)
        {
            int rs = 0;
            Process[] arrayProcess = Process.GetProcesses();
            foreach (Process p in arrayProcess)
            {
                if (p.MainWindowTitle.IndexOf(windowTitle) != -1)
                {
                    rs = p.Id;
                    break;
                }
            }

            return rs;
        }

        //根据进程名获取PID
        /// <summary>
        /// 根据进程名获取PID
        /// </summary>
        /// <param name="processName">进程名</param>
        /// <returns>进程标识ID</returns>
        public static int GetPidByProcessName(string processName)
        {
            IEnumerable<ProcessItem> pis = GetProcesses();
            if (pis!=null)
            {
                foreach (ProcessItem pi in pis)
                {
                    if (pi.Name == processName)
                    {
                        return pi.Pid;
                    }
                }
            }
            return -1;
        }

        //根据窗体标题查找窗口句柄（支持模糊匹配）
        /// <summary>
        /// 根据窗体标题查找窗口句柄
        /// </summary>
        /// <param name="title">窗体标题</param>
        /// <returns>窗口句柄</returns>
        public static IntPtr FindWindow(string title)
        {

            Process[] ps = Process.GetProcesses();
            foreach (Process p in ps)
            {
                if (p.MainWindowTitle.IndexOf(title) != -1)
                {
                    return p.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }

        //读取内存中的值
        /// <summary>
        /// 读取内存中的值
        /// </summary>
        /// <param name="baseAddress">内存地址</param>
        /// <param name="processName">进程名</param>
        /// <returns>值</returns>
        public static int ReadMemoryValue(int baseAddress, string processName)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = Kernel32Api.OpenProcess(0x1F0FFF, false, GetPidByProcessName(processName));
                Kernel32Api.ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero); //将制定内存中的值读入缓冲区
                Kernel32Api.CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 读取内存中的值
        /// </summary>
        /// <param name="baseAddress">内存地址</param>
        /// <param name="PId">进程id</param>
        /// <returns>值</returns>
        public static int ReadMemoryValue(int baseAddress, int PId)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0); //获取缓冲区地址
                IntPtr hProcess = Kernel32Api.OpenProcess(0x1F0FFF, false, PId);
                Kernel32Api.ReadProcessMemory(hProcess, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero); //将制定内存中的值读入缓冲区
                Kernel32Api.CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }

        //将值写入指定内存地址中
        /// <summary>
        /// 将值写入指定内存地址中
        /// </summary>
        /// <param name="baseAddress">内存地址</param>
        /// <param name="processName">进程名</param>
        /// <param name="value">要写入的值</param>
        public static void WriteMemoryValue(int baseAddress, string processName, int value)
        {
            IntPtr hProcess = Kernel32Api.OpenProcess(0x1F0FFF, false, GetPidByProcessName(processName)); //0x1F0FFF 最高权限
            Kernel32Api.WriteProcessMemory(hProcess, (IntPtr)baseAddress, new int[] { value }, 4, IntPtr.Zero);
            Kernel32Api.CloseHandle(hProcess);
        }
        /// <summary>
        /// 将值写入指定内存地址中
        /// </summary>
        /// <param name="baseAddress">内存地址</param>
        /// <param name="PId">进程Id</param>
        /// <param name="value">要写入的值</param>
        public static void WriteMemoryValue(int baseAddress, int PId, int value)
        {
            IntPtr hProcess = Kernel32Api.OpenProcess(0x1F0FFF, false, PId); //0x1F0FFF 最高权限
            Kernel32Api.WriteProcessMemory(hProcess, (IntPtr)baseAddress, new int[] { value }, 4, IntPtr.Zero);
            Kernel32Api.CloseHandle(hProcess);
        }
        #endregion
        /// <summary>
        /// 获得线程
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ProcessItem> GetProcesses()
        {
            IEnumerable<ProcessItem> pis = new UsingProcess().GetProcesses();
            if (pis.Count() <= 0) pis = new UsingProcess().GetProcesses();
            if (pis.Count() <= 0) pis = new UsingWMI().GetProcesses();
            if (pis.Count() <= 0) pis = new UsingWMIEvents().GetProcesses();
            if (pis.Count() <= 0) pis = new UsingWMIPerf().GetProcesses();
            if (pis.Count() <= 0) return null;
            else return pis;
        }
    }
 }
