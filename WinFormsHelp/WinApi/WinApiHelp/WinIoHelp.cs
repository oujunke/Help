using Help.WinFormsHelp.WinApi.Win32Api;
using Help.WinFormsHelp.WinApi.Win64Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Help.Model.Enums;

namespace Help.WinFormsHelp.WinApi.WinApiHelp
{
   public class WinIoHelp
    {

        public const int KBC_KEY_CMD = 0x64;
        public const int KBC_KEY_DATA = 0x60;
        /// <summary>
        /// 安装驱动
        /// </summary>
        /// <returns></returns>
        public static  bool InitializeWinIo()
        {
            return Is64 ? WinIo64Help.InitializeWinIo() : WinIo32Help.InitializeWinIo();
        }

        
        public static  bool GetPortVal(IntPtr wPortAddr, out int pdwPortVal, byte bSize)
        {
            return Is64 ? WinIo64Help.GetPortVal(wPortAddr,out pdwPortVal, bSize) : WinIo32Help.GetPortVal(wPortAddr, out pdwPortVal, bSize);
        }


        public static  bool SetPortVal(uint wPortAddr, IntPtr dwPortVal, byte bSize)
        {
            return Is64 ? WinIo64Help.SetPortVal( wPortAddr,  dwPortVal,  bSize) : WinIo32Help.SetPortVal( wPortAddr,  dwPortVal,  bSize);
        }


        public static  byte MapPhysToLin(byte pbPhysAddr, uint dwPhysSize, IntPtr PhysicalMemoryHandle)
        {
            return Is64 ? WinIo64Help.MapPhysToLin( pbPhysAddr,  dwPhysSize,  PhysicalMemoryHandle) : WinIo32Help.MapPhysToLin( pbPhysAddr,  dwPhysSize,  PhysicalMemoryHandle);
        }


        public static  bool UnmapPhysicalMemory(IntPtr PhysicalMemoryHandle, byte pbLinAddr)
        {
            return Is64 ? WinIo64Help.UnmapPhysicalMemory( PhysicalMemoryHandle,  pbLinAddr) : WinIo32Help.UnmapPhysicalMemory( PhysicalMemoryHandle, pbLinAddr);
        }


        public static  bool GetPhysLong(IntPtr pbPhysAddr, byte pdwPhysVal)
        {
            return Is64 ? WinIo64Help.GetPhysLong( pbPhysAddr,  pdwPhysVal) : WinIo32Help.GetPhysLong( pbPhysAddr,  pdwPhysVal);
        }


        public static  bool SetPhysLong(IntPtr pbPhysAddr, byte dwPhysVal)
        {
            return Is64 ? WinIo64Help.SetPhysLong( pbPhysAddr,  dwPhysVal) : WinIo32Help.SetPhysLong( pbPhysAddr,  dwPhysVal);
        }
        /// <summary>
        /// 卸载驱动
        /// </summary>

        public static  void ShutdownWinIo()
        {
            if (Is64) {
                WinIo64Help.ShutdownWinIo(); } else {
                WinIo32Help.ShutdownWinIo(); }
        }
        private static bool IsInitialize { get; set; }
        private static bool Is64;
        static WinIoHelp()
        {
            Is64 = Environment.Is64BitProcess;
            Initialize();
        }
        /// <summary>
        /// 注册
        /// </summary>
        private static void Initialize()
        {
            if (InitializeWinIo())
            {
                KBCWait4IBE(); IsInitialize = true;
            }
            else
                System.Windows.Forms.MessageBox.Show("failed");

        }
        /// <summary>
        /// 卸载
        /// </summary>
        public static void Shutdown()
        {
            if (IsInitialize)
                ShutdownWinIo();
            IsInitialize = false;
        }
        /// <summary>
        /// 等待键盘缓冲区为空
        /// </summary>
        private static void KBCWait4IBE()
        {
            int dwVal = 0;
            do
            {
                bool flag = GetPortVal((IntPtr)0x64, out dwVal, 1);
            }
            while ((dwVal & 0x2) > 0);
        }
        /// <summary>
        /// 按键按下
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public static void MykeyDown(VKKey vKeyCoad)
        {
            if (!IsInitialize) return;

            Thread.Sleep(100);
            int btScancode = 0;

            btScancode =User32Api.MapVirtualKey((uint)vKeyCoad, 0);

            KBCWait4IBE();

            SetPortVal(KBC_KEY_DATA, (IntPtr)0x60, 1);

            KBCWait4IBE();

            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1);

            KBCWait4IBE();

            SetPortVal(KBC_KEY_DATA, (IntPtr)btScancode, 1);
        }
        /// <summary>
        /// 按键 松开
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public static void MykeyUp(VKKey vKeyCoad)
        {
            if (!IsInitialize) return;

            int btScancode = 0;
            btScancode = User32Api.MapVirtualKey((uint)vKeyCoad, 0);
            KBCWait4IBE();
            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1);
            KBCWait4IBE();
            SetPortVal(KBC_KEY_DATA, (IntPtr)0x60, 1);
            KBCWait4IBE();
            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD2, 1);
            KBCWait4IBE();
            SetPortVal(KBC_KEY_DATA, (IntPtr)(btScancode | 0x80), 1);
        }
        public static void Move(long x, long y, long z)
        {
            KBCWait4IBE();
            SetPortVal(0x64, (IntPtr)0xd3, 1);
            KBCWait4IBE();
            Thread.Sleep(5);
            SetPortVal(0x60, (IntPtr)0x28, 1);
            KBCWait4IBE();
            Thread.Sleep(5);
            SetPortVal(0x64, (IntPtr)0xd3, 1);
            KBCWait4IBE();
            Thread.Sleep(5);
            SetPortVal(0x60, (IntPtr)x, 1);
            KBCWait4IBE();
            Thread.Sleep(5);
            SetPortVal(0x64, (IntPtr)0xd3, 1);
            KBCWait4IBE();
            Thread.Sleep(5);
            SetPortVal(0x60, (IntPtr)y, 1);
            KBCWait4IBE();
            Thread.Sleep(5);
            SetPortVal(0x64, (IntPtr)0xd3, 1);
            KBCWait4IBE();
            Thread.Sleep(5);
            SetPortVal(0x60, (IntPtr)z, 1);
        }
        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public static void MyMouseDown(VKKey vKeyCoad)
        {
            int btScancode = 0;
            btScancode = User32Api.MapVirtualKey((byte)vKeyCoad, 0);
            KBCWait4IBE(); // 'wait for buffer gets empty  
            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD3, 1);// 'send write command  
            KBCWait4IBE();
            SetPortVal(KBC_KEY_DATA, (IntPtr)(btScancode | 0x80), 1);// 'write in io  
        }
        /// <summary>
        /// 鼠标松开
        /// </summary>
        /// <param name="vKeyCoad"></param>
        public static void MyMouseUp(VKKey vKeyCoad)
        {
            int btScancode = 0;
            btScancode = User32Api.MapVirtualKey((byte)vKeyCoad, 0);
            KBCWait4IBE(); // 'wait for buffer gets empty  
            SetPortVal(KBC_KEY_CMD, (IntPtr)0xD3, 1); //'send write command  
            KBCWait4IBE();
            SetPortVal(KBC_KEY_DATA, (IntPtr)(btScancode | 0x80), 1);// 'write in io  
        }
    }
}
