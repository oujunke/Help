using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Help.Model.Enums;

namespace Help.WinFormsHelp.WinApi.Win32Api
{
   public class WinIo32Help
    {
        /// <summary>
        /// 安装驱动
        /// </summary>
        /// <returns></returns>
        [DllImport("WinIo32.dll")]
        public static extern bool InitializeWinIo();

        [DllImport("WinIo32.dll")]
        public static extern bool GetPortVal(IntPtr wPortAddr, out int pdwPortVal, byte bSize);

        [DllImport("WinIo32.dll")]
        public static extern bool SetPortVal(uint wPortAddr, IntPtr dwPortVal, byte bSize);

        [DllImport("WinIo32.dll")]
        public static extern byte MapPhysToLin(byte pbPhysAddr, uint dwPhysSize, IntPtr PhysicalMemoryHandle);

        [DllImport("WinIo32.dll")]
        public static extern bool UnmapPhysicalMemory(IntPtr PhysicalMemoryHandle, byte pbLinAddr);

        [DllImport("WinIo32.dll")]
        public static extern bool GetPhysLong(IntPtr pbPhysAddr, byte pdwPhysVal);

        [DllImport("WinIo32.dll")]
        public static extern bool SetPhysLong(IntPtr pbPhysAddr, byte dwPhysVal);
        /// <summary>
        /// 卸载驱动
        /// </summary>
        [DllImport("WinIo32.dll")]
        public static extern void ShutdownWinIo();

       
    }
}
