using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Messaging;
using Help.Model;
using static Help.Model.Structs;

namespace Help.WinFormsHelp.WinApi.Win32Api
{
    public static class User32Api
    {
        #region User32.dll 函数



        /// <summary>
        /// 该函数检索一指定窗口的客户区域或整个屏幕的显示设备上下文环境的句柄，以后可以在GDI函数中使用该句柄来在设备上下文环境中绘图。hWnd：设备上下文环境被检索的窗口的句柄
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDC(IntPtr hWnd);
        /// <summary>
        /// 截屏
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="hdcBlt"></param>
        /// <param name="nFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(
 IntPtr hwnd,                // Window to copy,Handle to the window that will be copied.
          IntPtr hdcBlt,              // HDC to print into,Handle to the device context.
          UInt32 nFlags               // Optional flags,Specifies the drawing options. It can be one of the following values.
          );
        /// <summary>
        /// 函数释放设备上下文环境（DC）供其他应用程序使用。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

       
        


        #region 剪贴板
        /// <summary>
        /// 打开剪切板
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool OpenClipboard(IntPtr hWndNewOwner);


        /// <summary>
        /// 关闭剪切板
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool CloseClipboard();
        /// <summary>
        /// 清空剪切板
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool EmptyClipboard();
        /// <summary>
        /// 将存放有数据的内存块放入剪切板的资源管理中
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr SetClipboardData(uint Format, IntPtr hData);
        #endregion
        /// <summary>
        /// 在一个矩形中装载指定菜单条目的屏幕坐标信息 
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool GetMenuItemRect(IntPtr hWnd, IntPtr hMenu, uint Item, ref Rectangle rc);

        #region 模拟按键
        /// <summary>
        /// 该函数将一虚拟键码翻译（映射）成一扫描码或一字符值，或者将一扫描码翻译成一虚拟键码
        /// </summary>
        /// <param name="Ucode"></param>
        /// <param name="uMapType"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int MapVirtualKey(uint Ucode, uint uMapType);
        /// <summary>
        /// 该函数将256个虚拟键的状态拷贝到指定的缓冲区中。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        /// <summary>
        /// 该函数将指定的虚拟键码和键盘状态翻译为相应的字符或字符串。该函数使用由给定的键盘布局句柄标识的物理键盘布局和输入语言来翻译代码。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);
        /// <summary>
        /// 该函数综合鼠标移动和按钮点击。
        /// </summary>
        /// <param name="dwFlags">标志位集，指定点击按钮和鼠标动作的多种情况</param>
        /// <param name="dx">指定鼠标沿x轴的绝对位置或者从上次鼠标事件产生以来移动的数量，依赖于MOUSEEVENTF_ABSOLUTE的设置。给出的绝对数据作为鼠标的实际X坐标；给出的相对数据作为移动的mickeys数。一个mickey表示鼠标移动的数量，表明鼠标已经移动。</param>
        /// <param name="dy">指定鼠标沿y轴的绝对位置或者从上次鼠标事件产生以来移动的数量，依赖于MOUSEEVENTF_ABSOLUTE的设置。给出的绝对数据作为鼠标的实际y坐标，给出的相对数据作为移动的mickeys数。</param>
        /// <param name="dwData">如果dwFlags为MOUSEEVENTF_WHEEL，则dwData指定鼠标轮移动的数量。正值表明鼠标轮向前转动，即远离用户的方向；负值表明鼠标轮向后转动，即朝向用户。一个轮击定义为WHEEL_DELTA，即120。如果dwFlagsS不是MOUSEEVENTF_WHEEL，则dWData应为零。</param>
        /// <param name="dwExtraInfo">指定与鼠标事件相关的附加32位值。应用程序调用函数GetMessageExtraInfo来获得此附加信息。</param>
        [DllImport("user32.dll")]
        public static extern void mouse_event(Enums.DwFlags dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        /// <summary>
        /// 设置鼠标的坐标
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int dx, int dy);

        /// <summary>
        /// 获取鼠标的坐标
        /// </summary>
        /// <param name="lpPoint"></param>
        [DllImport("user32.dll")]
        public static extern void GetCursorPos(ref Point lpPoint);
        /// <summary>
        /// 使用该函数可以相应的屏蔽键盘的动作。Keybd_event（）函数能触发一个按键事件，也就是说会产生一个WM_KEYDOWN或WM_KEYUP消息
        /// </summary>
        /// <param name="bVk">按键的虚拟键值，如回车键为vk_return, tab键为vk_tab（其他具体的参见附录：常用模拟键的键值对照表）；</param>
        /// <param name="bScan">扫描码，一般不用设置，用0代替就行</param>
        /// <param name="dwFlags">选项标志，如果为keydown则置0即可，如果为keyup则设成"KEYEVENTF_KEYUP"；</param>
        /// <param name="dwExtraInfo">一般也是置0即可</param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(System.Windows.Forms.Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        /// <summary>
        /// 该函数将虚拟键消息转换为字符消息。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool TranslateMessage(ref Message msg);
        /// <summary>
        /// 该函数检取指定虚拟键的状态。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern ushort GetKeyState(int virtKey);
        #endregion
        #region 发送消息
        /// <summary>
        /// 该函数产生对其他线程的控制，如果一个线程没有其他消息在其消息队列里。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool WaitMessage();
        /// <summary>
        /// 该函数为一个消息检查线程消息队列，并将该消息（如果存在）放于指定的结构。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool PeekMessage(ref Message msg, int hWnd, uint wFilterMin, uint wFilterMax, uint wFlag);
        /// <summary>
        /// 该函数从调用线程的消息队列里取得一个消息并将其放于指定的结构。此函数可取得与指定窗口联系的消息和由PostThreadMesssge寄送的线程消息。此函数接收一定范围的消息值。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GetMessage(ref Message msg, int hWnd, uint wFilterMin, uint wFilterMax);
        /// <summary>
        /// 该函数调度一个消息给窗口程序。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool DispatchMessage(ref Message msg);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, uint lParam);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref Rectangle lParam);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Point lParam);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTON lParam);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref TBBUTTONINFO lParam);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Help.Model.Structs.REBARBANDINFO lParam);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref Help.Model.Structs.TVITEM lParam);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref Help.Model.Structs.LVITEM lParam);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref Help.Model.Structs.HDITEM lParam);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, ref Help.Model.Structs.HD_HITTESTINFO hti);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回。　
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄</param>
        /// <param name="msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息指定信息</param>
        /// <param name="lParam">指定附加的消息指定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int msg, int wParam, StringBuilder sb);
        /// <summary>
        /// 该函数将一个消息放入（寄送）到与指定窗口创建的线程相联系消息队列里
        /// </summary>
        /// <param name="hWnd">其窗口程序接收消息的窗口的句柄</param>
        /// <param name="msg">指定被寄送的消息</param>
        /// <param name="wParam">指定附加的消息特定的信息</param>
        /// <param name="lParam">指定附加的消息特定的信息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        #endregion
        #region 钩子
        /// <summary>
        /// 钩子的回调函数
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        /// <summary>
        /// 设置系统钩子
        /// </summary>
        /// <param name="hookid"></param>
        /// <param name="pfnhook"></param>
        /// <param name="hinst"></param>
        /// <param name="threadid"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(Help.Model.Enums.HookType idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        /// <summary>
        /// 释放系统钩子
        /// </summary>
        /// <param name="hhook"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhook);
        /// <summary>
        /// 下一个系统钩子
        /// </summary>
        /// <param name="hhook"></param>
        /// <param name="code"></param>
        /// <param name="wparam"></param>
        /// <param name="lparam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhook, int code, IntPtr wparam, IntPtr lparam);
        /// <summary>
        /// 设置钩子
        /// </summary>
        /// <param name="idHook">钩子id</param>
        /// <param name="lpfn">钩子处理方法</param>
        /// <param name="hInstance">句柄</param>
        /// <param name="threadId">线程id</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, Delegates.HookProc lpfn, IntPtr hInstance, int threadId);

        /// <summary>
        /// 取消钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        /// <summary>
        /// 调用下一个钩子
        /// </summary>
        /// <param name="idHook">本钩子id</param>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);
        #endregion
        #region 窗体
        #region 窗体查找
        /// <summary>
        /// 枚举所有子窗体
        /// </summary>
        /// <param name="window"></param>
        /// <param name="callback"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        //IMPORTANT : LPARAM  must be a pointer (InterPtr) in VS2005, otherwise an exception will be thrown
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
        /// <summary>
        /// 枚举所有子窗体
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        //the callback function for the EnumChildWindows
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
        /// <summary>
        /// 获取一个前台窗口的句柄（窗口与用户当前的工作）。该系统分配给其他线程比它的前台窗口的线程创建一个稍微更高的优先级
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        /// <summary>
        /// 该函数确定给定的窗口句柄是否识别一个已存在的窗口。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int IsWindow(IntPtr hWnd);
        /// <summary>
        /// 确定当前焦点位于哪个控件上。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetFocus();
        /// <summary>
        /// 该函数返回桌面窗口的句柄。桌面窗口覆盖整个屏幕。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern IntPtr GetDesktopWindow();
        /// <summary>
        /// 该函数获得一个指定子窗口的父窗口句柄。
        /// </summary>
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        /// <summary>
        /// 这个函数检索处理顶级窗口的类名和窗口名称匹配指定的字符串。这个函数不搜索子窗口。
        /// </summary>
        /// <param name="lpClassName">lpClassName参数指向类名。</param>
        /// <param name="lpWindowName">lpWindowName指向窗口名，如果有指定的类名和窗口的名字则表示成功</param>
        /// <returns>返回一个窗口的句柄。否则返回零</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 在窗口列表中寻找与指定条件相符的第一个子窗口 。
        /// </summary>
        /// <param name="hwndParent">要查找的子窗口所在的父窗口的句柄（如果设置了hwndParent，则表示从这个hwndParent指向的父窗口中搜索子窗口）。如果hwndParent为 0 ，则函数以桌面窗口为父窗口，查找桌面窗口的所有子窗口。</param>
        /// <param name="hwndChildAfter">子窗口句柄。查找从在Z序中的下一个子窗口开始。子窗口必须为hwndParent窗口的直接子窗口而非后代窗口。如果HwndChildAfter为NULL，查找从hwndParent的第一个子窗口开始。如果hwndParent 和 hwndChildAfter同时为NULL，则函数查找所有的顶层窗口及消息窗口。</param>
        /// <param name="lpClassName">指向一个指定了类名的空结束字符串，或一个标识类名字符串的成员的指针。如果该参数为一个成员，则它必须为前次调用theGlobaIAddAtom函数产生的全局成员。该成员为16位，必须位于lpClassName的低16位，高位必须为0</param>
        /// <param name="lpWindowName">指向一个指定了窗口名（窗口标题）的空结束字符串。如果该参数为 NULL，则为所有窗口全匹配。</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        /// <summary>
        /// 获取对话框中子窗口控件的句柄
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public extern static IntPtr GetDlgItem(IntPtr hDlg, int nControlID);
        #endregion
        #region 获取窗体坐标
        /// <summary>
        /// 该函数返回指定窗口的边框矩形的尺寸。该尺寸以相对于屏幕坐标左上角的屏幕坐标给出。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle rect);
        /// <summary>
        /// 该函数将指定点的用户坐标转换成屏幕坐标。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point pt);
        /// <summary>
        /// 该函数获取窗口客户区的坐标。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public extern static int GetClientRect(IntPtr hWnd, ref Rectangle rc);
        #endregion
        #region 获取窗体属性
        /// <summary>
        /// 获取窗体是否可见
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="ID">进程id</param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int IsWindowVisible(IntPtr hwnd);
        /// <summary>
        /// 获取窗体线程ID
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <param name="ID">进程id</param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd,ref int processId);
        /// <summary>
        /// 该函数将指定窗口的标题条文本（如果存在）拷贝到一个缓存区内。如果指定的窗口是一个控制，则拷贝控制的文本。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, out Structs.STRINGBUFFER text, int maxCount);
        ///<summary>
        /// 用于得到被定义的系统数据或者系统配置信息.
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        static public extern int GetSystemMetrics(int nIndex);
        /// <summary>
        /// 该函数设置滚动条参数，包括滚动位置的最大值和最小值，页面大小，滚动按钮的位置。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        static public extern int SetScrollInfo(IntPtr hwnd, int bar, ref Structs.SCROLLINFO si, int fRedraw);
        /// <summary>
        /// 获取整个窗口（包括边框、滚动条、标题栏、菜单等）的设备场景 返回值 Long。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        /// <summary>
        /// 该函数返回指定窗口的显示状态以及被恢复的、最大化的和最小化的窗口位置。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetWindowPlacement(IntPtr hWnd, ref Structs.WINDOWPLACEMENT wp);
        /// <summary>
        /// 该函数获得指定窗口所属的类的类名。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, out Structs.STRINGBUFFER ClassName, int nMaxCount);
        #endregion
        #region 设置窗体属性
        /// <summary>
        /// 该函数改变指定窗口的标题栏的文本内容
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowText(IntPtr hWnd, string text);

        /// <summary>
        /// 该函数显示或隐藏所指定的滚动条。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);
        /// <summary>
        /// 该函数可以激活一个或两个滚动条箭头或是使其失效。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int EnableScrollBar(IntPtr hWnd, uint flags, uint arrows);
        /// <summary>
        /// 该函数将指定的窗口设置到Z序的顶部。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int BringWindowToTop(IntPtr hWnd);
        /// <summary>
        /// 该函数滚动指定窗体客户区域的目录。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        static public extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy, ref Rectangle rcScroll, ref Rectangle rcClip, IntPtr UpdateRegion, ref Rectangle rcInvalidated, uint flags);
        /// <summary>
        /// 半透明窗体
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref Help.Model.Structs.BLENDFUNCTION pblend, Int32 dwFlags);
        /// <summary>
        /// 该函数改变指定窗口的位置和尺寸。对于顶层窗口，位置和尺寸是相对于屏幕的左上角的：对于子窗口，位置和尺寸是相对于父窗口客户区的左上角坐标的。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

        /// <summary>
        /// 该函数改变指定窗口的属性
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        /// <summary>
        /// 该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。系统给创建前台窗口的线程分配的权限稍高于其他线程。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool SetForegroundWindow(IntPtr hWnd);
        /// <summary>
        /// 该函数激活一个窗口。该窗口必须与调用线程的消息队列相关联。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);
        /// <summary>
        /// 该函数设置指定窗口的显示状态。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool ShowWindow(IntPtr hWnd, short State);
        /// <summary>
        /// 该函数改变一个子窗口，弹出式窗口式顶层窗口的尺寸，位置和Z序。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, uint flags);
        /// <summary>
        /// 该函数对指定的窗口设置键盘焦点。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetFocus(IntPtr hWnd);
        /// <summary>
        /// 该函数在指定的矩形里写入格式化文本，根据指定的方法对文本格式化（扩展的制表符，字符对齐、折行等）。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public extern static int DrawText(IntPtr hdc, string lpString, int nCount, ref Rectangle lpRect, int uFormat);
        /// <summary>
        /// 该函数改变指定子窗口的父窗口。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);
        #endregion
        #region 绘制窗体
        /// <summary>
        /// 该函数用指定的画刷填充矩形，此函数包括矩形的左上边界，但不包括矩形的右下边界。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int FillRect(IntPtr hDC, ref Rectangle rect, IntPtr hBrush);
        /// <summary>
        ///  函数是设置了一个窗口的区域.只有被包含在这个区域内的地方才会被重绘,而不包含在区域内的其他区域系统将不会显示.
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool redraw);

        /// <summary>
        /// 该函数检索指定窗口客户区域或整个屏幕的显示设备上下文环境的句柄，在随后的GDI函数中可以使用该句柄在设备上下文环境中绘图。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRegion, uint flags);
        /// <summary>
        /// 准备指定的窗口来重绘并将绘画相关的信息放到一个PAINTSTRUCT结构中。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr BeginPaint(IntPtr hWnd, ref Help.Model.Structs.PAINTSTRUCT ps);
        /// <summary>
        /// 标记指定窗口的绘画过程结束,每次调用BeginPaint函数之后被请求
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool EndPaint(IntPtr hWnd, ref Help.Model.Structs.PAINTSTRUCT ps);
        /// <summary>
        /// 通过发送重绘消息 WM_PAINT 给目标窗体来更新目标窗体客户区的无效区域。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static public extern bool UpdateWindow(IntPtr hWnd);
        /// <summary>
        /// 该函数向指定的窗体添加一个矩形，然后窗口客户区域的这一部分将被重新绘制。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public extern static int InvalidateRect(IntPtr hWnd, IntPtr rect, int bErase);

        #endregion
        #endregion




        /// <summary>
        /// 该函数从一个与应用事例相关的可执行文件（EXE文件）中载入指定的光标资源.
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, uint cursor);
        /// <summary>
        /// 该函数确定光标的形状。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(IntPtr hCursor);
        /// <summary>
        /// 获得光标形状
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetCursor();
        /// <summary>
        /// 获得光标形状
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetIconInfo(IntPtr intPtr,out IconInfo iconInfo);
        /// <summary>
        /// 获得光标形状
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorInfo(ref CursorInfo cursorInfo);

        /// <summary>
        /// 该函数从当前线程中的窗口释放鼠标捕获，并恢复通常的鼠标输入处理。捕获鼠标的窗口接收所有的鼠标输入（无论光标的位置在哪里），除非点击鼠标键时，光标热点在另一个线程的窗口中。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ReleaseCapture();
       
       

        /// <summary>
        /// 当在指定时间内鼠标指针离开或盘旋在一个窗口上时，此函数寄送消息。
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool TrackMouseEvent(ref Help.Model.Structs.TRACKMOUSEEVENTS tme);

       
       
       

        /// <summary>
        /// 注册全局热键
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //要定义热键的窗口的句柄
            int id,                     //定义热键ID（不能与其它ID重复）           
            Help.Model.Enums.KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
            System.Windows.Forms.Keys vk                     //定义热键的内容
            );
        /// <summary>
        /// 释放全局热键
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消热键的窗口的句柄
            int id                      //要取消热键的ID
            );
        #endregion

    }
}