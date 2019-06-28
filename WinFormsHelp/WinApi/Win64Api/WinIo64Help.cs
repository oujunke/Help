using Help.WinFormsHelp.WinApi.Win32Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Help.Model.Enums;

namespace Help.WinFormsHelp.WinApi.Win64Api
{
   public class WinIo64Help
    {
        /// <summary>
        /// 安装驱动
        /// </summary>
        /// <returns></returns>
        [DllImport("WinIo64.dll")]
        public static extern bool InitializeWinIo();

        [DllImport("WinIo64.dll")]
        public static extern bool GetPortVal(IntPtr wPortAddr, out int pdwPortVal, byte bSize);

        [DllImport("WinIo64.dll")]
        public static extern bool SetPortVal(uint wPortAddr, IntPtr dwPortVal, byte bSize);

        [DllImport("WinIo64.dll")]
        public static extern byte MapPhysToLin(byte pbPhysAddr, uint dwPhysSize, IntPtr PhysicalMemoryHandle);

        [DllImport("WinIo64.dll")]
        public static extern bool UnmapPhysicalMemory(IntPtr PhysicalMemoryHandle, byte pbLinAddr);

        [DllImport("WinIo64.dll")]
        public static extern bool GetPhysLong(IntPtr pbPhysAddr, byte pdwPhysVal);

        [DllImport("WinIo64.dll")]
        public static extern bool SetPhysLong(IntPtr pbPhysAddr, byte dwPhysVal);
        /// <summary>
        /// 卸载驱动
        /// </summary>
        [DllImport("WinIo64.dll")]
        public static extern void ShutdownWinIo();
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        
    }
}
