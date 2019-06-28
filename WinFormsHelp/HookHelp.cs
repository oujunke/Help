using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Help.Model;
using System.Diagnostics;

namespace Help.WinFormsHelp
{
    public class HookHelp
    {
        /// <summary>
        /// 键盘钩子
        /// </summary>
        public abstract class KeyBoardHook
        {
            #region 字段
            /// <summary>
            /// 当前钩子的id
            /// </summary>
            protected int hHookId = 0;
            /// <summary>
            /// 外部调用的键盘处理事件
            /// </summary>
            protected Delegates.ProcessKeyHandle clientMethod = null;
            /// <summary>
            /// 当前模块的句柄
            /// </summary>
            protected IntPtr hookWindowPtr = IntPtr.Zero;
            /// <summary>
            /// 勾子程序处理事件
            /// </summary>
            protected Delegates.HookProc keyBoardHookProcedure;
            protected int hookKey;
            #endregion

            #region 属性
            /// <summary>
            /// 获取或设置钩子的唯一标志
            /// </summary>
            public int HookKey
            {
                get { return this.hookKey; }
                set { this.hookKey = value; }
            }
            #endregion

            /// <summary>
            /// 安装钩子
            /// </summary>
            /// <param name="clientMethod"></param>
            /// <returns></returns>
            public abstract bool Install(Delegates.ProcessKeyHandle clientMethod);
            /// <summary>
            /// 钩子处理函数
            /// </summary>
            /// <param name="nCode"></param>
            /// <param name="wParam"></param>
            /// <param name="lParam"></param>
            /// <returns></returns>
            protected abstract int GetHookProc(int nCode, int wParam, IntPtr lParam);

            /// <summary>
            /// 卸载钩子
            /// </summary>
            public virtual void UnInstall()
            {
                bool retKeyboard = true;
                if (hHookId != 0)
                {
                    retKeyboard = WinApi.Win32Api.User32Api.UnhookWindowsHookEx(hHookId);
                    hHookId = 0;

                }
                //if (hookWindowPtr != IntPtr.Zero)
                //{
                //    Marshal.FreeHGlobal(hookWindowPtr);
                //}
                if (!retKeyboard)
                {
                    throw new Exception("UnhookWindowsHookEx failed.");
                }
            }
        }
        /// <summary>
        /// 全局钩子，慎用，获取所有进程的按键信息，耗费系统资源
        /// </summary>
        public class GlobalHook : KeyBoardHook
        {
            public override bool Install(Delegates.ProcessKeyHandle clientMethod)
            {
                try
                {
                    //客户端传入的委托，即截获消息之后，对消息的过滤和处理的方法
                    this.clientMethod = clientMethod;

                    // 安装键盘钩子
                    if (hHookId == 0)
                    {
                        keyBoardHookProcedure = GetHookProc;

                        hookWindowPtr = WinApi.Win32Api.Kernel32Api.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
                        
                        hHookId = WinApi.Win32Api.User32Api.SetWindowsHookEx(
                           (int)Model.Enums.KeyHookType.WH_KEYBOARD_LL,//调用系统方法安装钩子，第一个参数标识钩子的类型13为全局钩子
                            keyBoardHookProcedure,
                            hookWindowPtr,
                            0);

                        //如果设置钩子失败.
                        if (hHookId == 0)

                            UnInstall();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            protected override int GetHookProc(int nCode, int wParam, IntPtr lParam)
            {
                ////参数 nCode 的可选值:
                //HC_ACTION      = 0;     {}
                //HC_GETNEXT     = 1;     {}
                //HC_SKIP        = 2;     {}
                //HC_NOREMOVE    = 3;     {}
                //HC_NOREM = HC_NOREMOVE; {}
                //HC_SYSMODALON  = 4;     {}
                //HC_SYSMODALOFF = 5;     {}

                if (nCode >= 0 && nCode != 3)
                {
                    //wParam = = 0x101 // 键盘抬起
                    // 键盘按下
                    if (wParam == 0x100)
                    {
                        //触发事件把安装信息通知客户端
                        if (clientMethod != null)
                        {

                            Help.Model.Structs.KeyBoardHookStruct kbh = (Help.Model.Structs.KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(Help.Model.Structs.KeyBoardHookStruct));
                            Keys key = (Keys)kbh.VkCode;
                            bool handle;
                            clientMethod(this.hookKey, key, out handle);
                            if (handle)//如果处理了就直接停止 1:
                            {
                                WinApi.Win32Api.User32Api.CallNextHookEx(hHookId, nCode, wParam, lParam);
                                return 1;
                            }
                        }
                    }

                }
                return WinApi.Win32Api.User32Api.CallNextHookEx(hHookId, nCode, wParam, lParam);
            }
        }
        
       

        /// <summary>
        /// 进程钩子，只能捕捉本进程的按键信息
        /// </summary>
        public class ProcessHook : KeyBoardHook
        {
            public override bool Install(Delegates.ProcessKeyHandle clientMethod)
            {
                try
                {
                    this.clientMethod = clientMethod;

                    // 安装键盘钩子
                    if (hHookId == 0)
                    {
                        keyBoardHookProcedure = GetHookProc;

                        hookWindowPtr = WinApi.Win32Api.Kernel32Api.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);

                        hHookId = WinApi.Win32Api.User32Api.SetWindowsHookEx(
                         (int)Help.Model.Enums.KeyHookType.WH_KEYBOARD,
                         keyBoardHookProcedure,
                         IntPtr.Zero,
                        WinApi.Win32Api.Kernel32Api.GetCurrentThreadId()
                         );

                        //如果设置钩子失败.
                        if (hHookId == 0)

                            UnInstall();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            protected override int GetHookProc(int nCode, int wParam, IntPtr lParam)
            {
                if (nCode == 0 && nCode != 3)
                {
                    bool isKeyDown = false;
                    if (IntPtr.Size == 4)
                    {
                        isKeyDown = (((lParam.ToInt32() & 0x80000000) == 0));
                    }
                    if (IntPtr.Size == 8)
                    {
                        isKeyDown = (((lParam.ToInt64() & 0x80000000) == 0));
                    }
                    // 键盘按下
                    if (isKeyDown)
                    {
                        //Debug.WriteLine("key down_________________________");
                        //触发事件把安装信息通知客户端
                        if (clientMethod != null)
                        {
                            //进程钩子，按键值在这里
                            Keys keyData = (Keys)wParam;
                            bool handle;
                            clientMethod(this.hookKey, keyData, out handle);
                            if (handle)//如果处理了就直接停止 1:
                            {
                                WinApi.Win32Api.User32Api.CallNextHookEx(hHookId, nCode, wParam, lParam);
                                return 1;
                            }
                        }
                    }

                }
                return WinApi.Win32Api.User32Api.CallNextHookEx(hHookId, nCode, wParam, lParam);
            }
        }
    }
}
