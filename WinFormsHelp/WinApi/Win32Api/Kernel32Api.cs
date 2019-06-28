using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Help.WinFormsHelp.WinApi.Win32Api
{
    class Kernel32Api
    {
        #region Kernel32.dll函数
        /// <summary>
        /// 获取当前线程ID
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        /// <summary>
        /// 获取当前线程ID
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern int GetLastError();
        /// <summary>
        /// 是获取一个应用程序或动态链接库的模块句柄
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);
        /// <summary>
        /// 从指定内存中读取字节集数据
        /// </summary>
        /// <param name="handle">进程句柄</param>
        /// <param name="address">内存地址</param>
        /// <param name="data">数据存储变量</param>
        /// <param name="size">长度</param>
        /// <param name="read">读取长度</param>
        [DllImport("Kernel32.dll")]
        public static extern void ReadProcessMemory(IntPtr handle, uint address, [Out] byte[] data, int size, int read);
        [DllImportAttribute("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        /// <summary>
        /// 从指定内存中读取字节集数据
        /// </summary>
        /// <param name="hProcess">进程句柄</param>
        /// <param name="lpBaseAddress">内存地址</param>
        /// <param name="lpBuffer">数据存储变量</param>
        /// <param name="nSize">长度</param>
        /// <param name="lpNumberOfBytesRead">读取长度</param>
        public static extern bool ReadProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                IntPtr lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesRead
            );
        /// <summary>
        /// 打开进程
        /// </summary>
        /// <param name="dwDesiredAccess">渴望得到的访问权限</param>
        /// <param name="bInheritHandle">是否继承句柄</param>
        /// <param name="dwProcessId">进程标示符</param>
        /// <returns></returns>
        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
            (
                int dwDesiredAccess,
                bool bInheritHandle,
                int dwProcessId
            );
        /// <summary>
        /// 关闭自身进程
        /// </summary>
        /// <param name="ProcessId"></param>
        [DllImport("kernel32.dll")]
        public static extern void ExitProcess(int exitCode);
        /// <summary>
        /// 关闭指定进程
        /// </summary>
        /// <param name="ProcessId"></param>
        [DllImport("kernel32.dll")]
        public static extern void TerminateProcess(IntPtr ProcessId, int exitCode);
        /// <summary>
        /// 关闭句柄
        /// </summary>
        /// <param name="hObject">需要关闭的句柄</param>
        [DllImport("kernel32.dll")]
        public static extern void CloseHandle
            (
                IntPtr hObject
            );

        //写内存
        /// <summary>
        /// 从其它程序中写内存
        /// </summary>
        /// <param name="hProcess"> 进程的句柄</param>
        /// <param name="lpBaseAddress">写入进程的位置</param>
        /// <param name="lpBuffer">数据当前存放地址</param>
        /// <param name="nSize">数据的长度</param>
        /// <param name="lpNumberOfBytesWritten">实际数据的长度</param>
        /// <returns></returns>
        [DllImportAttribute("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                int[] lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesWritten
            );
        #endregion
    }
}
