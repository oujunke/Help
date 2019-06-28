using Help.Model;
using Help.WinFormsHelp.WinApi.Win32Api;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using static Help.Model.Enums;
using static Help.Model.Structs;

namespace Help.WinFormsHelp.WinApi.WinApiHelp
{
    public class WindowHelp
    {
        /// <summary>
        /// 进程句柄
        /// </summary>
        public static IntPtr ProcessId;

        static WindowHelp()
        {
            ProcessId = new IntPtr(System.Diagnostics.Process.GetCurrentProcess().Id);

        }
        public static int GetLParamByPoint(int x, int y)
        {
            return (y << 16) | x;
        }
        public static Point GetPointByLParam(int lParam)
        {
            return new Point(lParam << 16 >> 16, lParam >> 16);
        }
        /// <summary>
        /// 设置鼠标位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="intPtr"></param>
        public static int SetCursorPos(IntPtr intPtr, int x, int y, VKKey key = 0)
        {
            //SendMessage(intPtr, (int)WinMsg.WM_SETCURSOR, intPtr.ToInt32(), 0x02000001);
            return SendMessage(intPtr, (int)WinMsg.WM_MOUSEMOVE, (int)key, (uint)GetLParamByPoint(x, y));
        }
        public static int MouseHandle(IntPtr intPtr, WinMsg wm, int x, int y)
        {
            return SendMessage(intPtr, (int)wm, 0, (uint)GetLParamByPoint(x, y));
        }
        /// <summary>
        /// 向窗口模拟按键
        /// </summary>
        /// <param name="intPtr"></param>
        /// <param name="key"></param>
        /// <param name="c"></param>
        public static void InputKey(IntPtr intPtr, VKKey key, char c)
        {
            SendMessage(intPtr, (int)Enums.WinMsg.WM_KEYDOWN, (int)key, 0x00200001);
            SendMessage(intPtr, (int)Enums.WinMsg.WM_CHAR, c, 0x00380001);
            SendMessage(intPtr, (int)Enums.WinMsg.WM_IME_KEYUP, (int)key, 0xC0200001);
        }
        /// <summary>
        /// 模拟按键
        /// </summary>
        /// <param name="key">按键</param>
        /// <param name="intPtr">发送的句柄</param>
        public static void InputKey(VKKey key, IntPtr intPtr = default(IntPtr))
        {
            if (intPtr != default(IntPtr))
            {
                User32Api.SetFocus(intPtr);
            }
            WinIoHelp.MykeyDown(key);
            WinIoHelp.MykeyUp(key);
        }
        /// <summary>
        /// post消息到窗口
        /// </summary>
        /// <param name="intPtr"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        public static void PostMessage(IntPtr intPtr, WinMsg msg, int wParam = 1, int lParam = 0)
        {
            PostMessage(intPtr, (int)msg, wParam, lParam);
        }
        /// <summary>
        /// post消息到窗口
        /// </summary>
        /// <param name="intPtr"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        public static void PostMessage(IntPtr intPtr, int msg, int wParam = 1, int lParam = 0)
        {
            User32Api.PostMessage(intPtr, msg, wParam, lParam);
        }
        /// <summary>
        /// 发送消息到窗口
        /// </summary>
        /// <param name="intPtr"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static int SendMessage(IntPtr intPtr, int msg, int wParam = 1, uint lParam = 0)
        {
            return User32Api.SendMessage(intPtr, msg, wParam, lParam);
        }
        /// <summary>
        /// 获得鼠标形状
        /// </summary>
        /// <returns></returns>
        public static int GetCursorStyle()
        {
            CursorInfo cursorInfo = new CursorInfo();
            cursorInfo.cbSize = Marshal.SizeOf(cursorInfo);
            User32Api.GetCursorInfo(ref cursorInfo);

            return cursorInfo.hCursor.ToInt32();
        }
        /// <summary>
        /// 点击
        /// </summary>
        public static void Click()
        {
            User32Api.mouse_event(DwFlags.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            Thread.Sleep(100);
            User32Api.mouse_event(DwFlags.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        /// <summary>
        /// 设置鼠标位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetCursorPos(Point po)
        {
            SetCursorPos(po.X, po.Y);
        }
        /// <summary>
        /// 设置鼠标位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetCursorPos(int x, int y)
        {
            User32Api.SetCursorPos(x, y);
        }
        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="ProcessId"></param>
        public static void CloseProcess(IntPtr ProcessId, int exitCode = 0)
        {
            IntPtr ip = Kernel32Api.OpenProcess(1, false, ProcessId.ToInt32());
            Kernel32Api.TerminateProcess(ip, exitCode);
        }
        public static void CloseWindows(IntPtr winIntPtr)
        {
            User32Api.SendMessage(winIntPtr, (int)WinMsg.WM_CLOSE, 0, 0);
        }
        /// <summary>
        /// 找到指定指针样式的伪控件(绘画上去的，不支持某些操作)
        /// </summary>
        /// <param name="windowModel">以该控件为基点</param>
        /// <param name="direction">1右，2下，3左，4上</param>
        /// <returns></returns>
        public static Point FindCursorStyle(WindowModel windowModel, int hCursor, int direction)
        {
            int bottom = 0;
            int right = 0;
            int span = 10;
            switch (direction)
            {
                case 1:
                    bottom = windowModel.WindowRectangle.Bottom;
                    right = windowModel.Parent.WindowRectangle.Right;
                    for (int x = windowModel.WindowRectangle.Right + span; x < right; x = x + span)
                    {
                        for (int y = windowModel.WindowRectangle.Top + span; y < bottom; y = y + span)
                        {
                            User32Api.SetCursorPos(x, y);
                            int c = GetCursorStyle();
                            Console.WriteLine(c);
                            if (c == hCursor)
                            {
                                return new Point(x, y);
                            }
                        }
                    }
                    break;
                case 2:
                    bottom = windowModel.Parent.WindowRectangle.Bottom;
                    right = windowModel.WindowRectangle.Right;
                    for (int y = windowModel.WindowRectangle.Bottom + span; y < bottom; y = y + span)
                    {
                        for (int x = windowModel.WindowRectangle.Left + span; x < right; x = x + span)
                        {
                            User32Api.SetCursorPos(x, y);
                            int c = GetCursorStyle();
                            Console.WriteLine(c);
                            if (c == hCursor)
                            {
                                return new Point(x, y);
                            }
                        }
                    }
                    break;
                case 3:
                    bottom = windowModel.WindowRectangle.Bottom;
                    int left = windowModel.Parent.WindowRectangle.Left;
                    for (int x = windowModel.WindowRectangle.Left - span; x > left; x = x - span)
                    {
                        for (int y = windowModel.WindowRectangle.Top + span; y < bottom; y = y + span)
                        {
                            User32Api.SetCursorPos(x, y);
                            int c = GetCursorStyle();
                            Console.WriteLine(c);
                            if (c == hCursor)
                            {
                                return new Point(x, y);
                            }
                        }
                    }
                    break;
                case 4:
                    var top = windowModel.Parent.WindowRectangle.Top;
                    right = windowModel.WindowRectangle.Right;
                    for (int y = windowModel.WindowRectangle.Top - span; y > top; y = y - span)
                    {
                        for (int x = windowModel.WindowRectangle.Left + span; x < right; x = x + span)
                        {
                            User32Api.SetCursorPos(x, y);
                            int c = GetCursorStyle();
                            Console.WriteLine(c);
                            if (c == hCursor)
                            {
                                return new Point(x, y);
                            }
                        }
                    }
                    break;
            }
            return Point.Empty;
        }
        /// <summary>
        /// 找到指定指针样式的伪控件(绘画上去的，不支持某些操作)（不完善）
        /// </summary>
        /// <param name="rectangle">查找的范围</param>
        /// <param name="bCursor">背景光标</param>
        /// <param name="direction">1右，2下，3左，4上</param>
        /// <returns></returns>
        public static Point FindCursorStyleChange(RECT rectangle, int direction, params int[] excludes)
        {
            int span = 10;
            int cursor;
            User32Api.SetCursorPos(rectangle.left, rectangle.top);
            cursor = GetCursorStyle();
            List<int> excludelist = new List<int>(excludes);
            excludelist.Add(cursor);
            switch (direction)
            {
                case 1:
                    for (int x = rectangle.left + span; x < rectangle.right; x = x + span)
                    {
                        for (int y = rectangle.top + span; y < rectangle.bottom; y = y + span)
                        {
                            User32Api.SetCursorPos(x, y);
                            int c = GetCursorStyle();
                            Console.WriteLine(c);
                            if (!excludelist.Contains(c))
                            {
                                return new Point(x, y);
                            }
                        }
                    }
                    break;
                case 2:
                    for (int y = rectangle.top + span; y < rectangle.bottom; y = y + span)
                    {
                        for (int x = rectangle.left + span; x < rectangle.right; x = x + span)
                        {
                            User32Api.SetCursorPos(x, y);
                            int c = GetCursorStyle();
                            Console.WriteLine(c);
                            if (!excludelist.Contains(c))
                            {
                                return new Point(x, y);
                            }
                        }
                    }
                    break;
                case 3:
                    for (int x = rectangle.right - span; x > rectangle.left; x = x - span)
                    {
                        for (int y = rectangle.top + span; y < rectangle.bottom; y = y + span)
                        {
                            User32Api.SetCursorPos(x, y);
                            int c = GetCursorStyle();
                            Console.WriteLine(c);
                            if (!excludelist.Contains(c))
                            {
                                return new Point(x, y);
                            }
                        }
                    }
                    break;
                case 4:
                    for (int y = rectangle.bottom - span; y > rectangle.top; y = y - span)
                    {
                        for (int x = rectangle.left + span; x < rectangle.right; x = x + span)
                        {
                            User32Api.SetCursorPos(x, y);
                            int c = GetCursorStyle();
                            Console.WriteLine(c);
                            if (!excludelist.Contains(c))
                            {
                                return new Point(x, y);
                            }
                        }
                    }
                    break;
            }
            return Point.Empty;
        }
        /// <summary>
        /// 从所有子窗体中查找指定的类名
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="lpClassName"></param>
        /// <returns></returns>
        public static WindowModel FindChildWindow(WindowModel parent, string lpClassName, string title = null)
        {
            WindowModel res = WindowModel.Empty;
            FindChildWindow(parent, lpClassName, ref res, title);
            return res;
        }
        internal static void FindChildWindow(WindowModel parent, string lpClassName, ref WindowModel res, string title = null)
        {
            foreach (var p in parent.Child)
            {
                if (p.ClassName == lpClassName && (title == null || title == p.Title))
                {
                    res = p;
                    return;
                }
                if (res)
                {
                    return;
                }
                FindChildWindow(p, lpClassName, ref res, title);
            }
        }
        /// <summary>
        /// 截屏1
        /// </summary>
        /// <param name="windowModel"></param>
        /// <returns></returns>
        public static Bitmap PrintWindow(WindowModel windowModel)
        {
            IntPtr hscrdc = User32Api.GetWindowDC(windowModel.IntPtr); //返回hWnd参数所指定的窗口的设备环境。
            int width = windowModel.WindowRectangle.Width;
            int height = windowModel.WindowRectangle.Height;
            IntPtr hbitmap = Gdi32Help.CreateCompatibleBitmap(hscrdc, width, height);//该函数创建与指定的设备环境相关的设备兼容的位图
            IntPtr hmemdc = Gdi32Help.CreateCompatibleDC(hscrdc);//该函数创建一个与指定设备兼容的内存设备上下文环境（DC）
            Gdi32Help.SelectObject(hmemdc, hbitmap);//该函数选择一对象到指定的设备上下文环境中，该新对象替换先前的相同类型的对象
            User32Api.PrintWindow(windowModel.IntPtr, hmemdc, 0);
            Bitmap bmp = Bitmap.FromHbitmap(hbitmap);
            //Clipboard.SetImage(bmp);
            Gdi32Help.DeleteDC(hscrdc);//删除用过的对象  
            Gdi32Help.DeleteDC(hmemdc);//删除用过的对象  
            return bmp;
        }
        /// <summary>
        /// 截屏2
        /// </summary>
        /// <param name="windowModel"></param>
        /// <returns></returns>
        public static Bitmap BitBlt(WindowModel windowModel)
        {
            windowModel.SetAction();
            IntPtr dcTmp = Gdi32Help.CreateDC("DISPLAY", "DISPLAY", (IntPtr)null, (IntPtr)null);
            Graphics gScreen = Graphics.FromHdc(dcTmp);
            Bitmap image = new Bitmap(windowModel.WindowRectangle.Width, windowModel.WindowRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics gImage = Graphics.FromImage(image);
            IntPtr dcImage = gImage.GetHdc();
            IntPtr dcScreen = gScreen.GetHdc();
            Gdi32Help.BitBlt(dcImage, 0, 0, windowModel.WindowRectangle.Width, windowModel.WindowRectangle.Height, dcScreen, windowModel.WindowRectangle.Left, windowModel.WindowRectangle.Top, 0x00CC0020);
            gScreen.ReleaseHdc(dcScreen);
            gImage.ReleaseHdc(dcImage);
            return image;
        }
        /// <summary>
        /// 查找窗口
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        public static WindowModel FindWindow(string lpClassName, string lpWindowName, bool IsSelfProcessId = true)
        {
            WindowModel wm = WindowModel.Empty;
            var ip = User32Api.FindWindow(lpClassName, lpWindowName);
            if (ip != IntPtr.Zero)
            {
                wm = new WindowModel(ip);
                if (IsSelfProcessId && wm.ProcessId != ProcessId)
                {
                    wm = WindowModel.Empty;
                }
            }
            return wm;
        }
        /// <summary>
        /// 查找指定是否可视窗口
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <param name="IsSelfProcessId"></param>
        /// <param name="IsVisible"></param>
        /// <returns></returns>
        public static WindowModel FindWindowVisible(string lpClassName, string lpWindowName=null, bool IsSelfProcessId = true,bool IsVisible=true)
        {
            WindowModel wm = WindowModel.Empty;
            var ca = IntPtr.Zero;
            while (true)
            {
                var ip = User32Api.FindWindowEx(IntPtr.Zero, ca, lpClassName, lpWindowName);
                if (ip != IntPtr.Zero)
                {
                    wm = new WindowModel(ip);
                    if (IsSelfProcessId && wm.ProcessId != ProcessId)
                    {
                        ca = ip;
                        continue;
                    }
                    if (wm.IsVisible== IsVisible)
                    {
                        return wm;
                    }
                    else
                    {
                        ca = ip;
                    }
                }
                return WindowModel.Empty;
            }

        }
        public static WindowModel FindWindowStartsWith(string lpClassName, string lpWindowName, bool IsSelfProcessId = true)
        {
            WindowModel wm = WindowModel.Empty;
            var ca = IntPtr.Zero;
            while (true)
            {
                var ip = User32Api.FindWindowEx(IntPtr.Zero, ca, lpClassName, null);
                if (ip != IntPtr.Zero)
                {
                    wm = new WindowModel(ip);
                    if (IsSelfProcessId && wm.ProcessId != ProcessId)
                    {
                        ca = ip;
                        continue;
                    }
                    if (wm.Title.StartsWith(lpWindowName))
                    {
                        return wm;
                    }
                    else
                    {
                        ca=ip;
                    }
                }
                return WindowModel.Empty;
            }

        }

        public class WindowModel
        {
            public static WindowModel Empty = new WindowModel(new IntPtr(-1));
            public IntPtr IntPtr { set; get; }
            /// <summary>
            /// 窗体标题
            /// </summary>
            public string Title
            {
                get
                {
                    if (!this) return string.Empty;
                    STRINGBUFFER text;
                    User32Api.GetWindowText(IntPtr, out text, 512);
                    return text.szText;
                }
                set
                {
                    if (this)
                        User32Api.SetWindowText(IntPtr, value);
                }
            }
            private Rectangle _rectangle;
            public Rectangle Rectangle
            {
                set
                {

                    if (!this && value == default(Rectangle))
                    {
                        _rectangle = value;
                    }
                }
                get
                {
                    SetPar(_rectangle, () =>
                    {
                        if (!this) _rectangle = Rectangle.Empty;
                        else if (Parent != null)
                        {
                            _rectangle = new Rectangle(new Point(WindowRectangle.X - Parent.WindowRectangle.X, WindowRectangle.Y - Parent.WindowRectangle.Y), WindowRectangle.Size);
                        }
                        else
                        {
                            _rectangle = WindowRectangle;
                        }
                    });
                    return _rectangle;
                }
            }
            private Rectangle _windowRectangle;
            /// <summary>
            /// 获取绝对坐标
            /// </summary>
            public Rectangle WindowRectangle
            {
                set
                {
                    if (!!this && value == default(Rectangle))
                    {
                        _windowRectangle = value;
                    }
                }
                get
                {
                    SetPar(_windowRectangle, () =>
                    {
                        if (!this) _windowRectangle = Rectangle.Empty;
                        else
                        {
                            User32Api.GetWindowRect(IntPtr, ref _windowRectangle);
                            _windowRectangle = new Rectangle(_windowRectangle.X, _windowRectangle.Y, _windowRectangle.Width - _windowRectangle.X, _windowRectangle.Height - _windowRectangle.Y);
                        }
                    });
                    return _windowRectangle;
                }
            }
            /// <summary>
            /// 是否可视
            /// </summary>
            public bool IsVisible
            {
                get
                {
                    if (!this) return false;
                    return User32Api.IsWindowVisible(IntPtr) != 0;
                }
            }
            public bool IsShow
            {
                get
                {
                    if (!this) return false;
                    return User32Api.IsWindow(IntPtr) != 0;
                }
            }
            private string _className;
            /// <summary>
            /// 窗口类名
            /// </summary>
            public string ClassName
            {
                get
                {
                    SetPar(_className, () =>
                    {
                        if (!this) _className = string.Empty;
                        else
                        {
                            Structs.STRINGBUFFER text;
                            User32Api.GetClassName(IntPtr, out text, 512);
                            _className = text.szText;
                        }
                    });
                    return _className;
                }
            }
            private IntPtr _threadId;
            /// <summary>
            /// 线程id
            /// </summary>
            public IntPtr ThreadId
            {
                get
                {
                    SetPar(_threadId, () =>
                    {
                        if (!this)
                        {
                            _threadId = IntPtr.Zero;
                            _processId = IntPtr.Zero;
                        }
                        else
                        {
                            int pid = 0;
                            int tid = User32Api.GetWindowThreadProcessId(IntPtr, ref pid);
                            _threadId = new IntPtr(tid);
                            _processId = new IntPtr(pid);
                        }
                    });
                    return _threadId;
                }
            }
            private IntPtr _processId;
            /// <summary>
            /// 进程id
            /// </summary>
            public IntPtr ProcessId
            {
                get
                {
                    SetPar(_processId, () =>
                    {
                        if (!this)
                        {
                            _threadId = IntPtr.Zero;
                            _processId = IntPtr.Zero;
                        }
                        else
                        {
                            int pid = 0;
                            int tid = User32Api.GetWindowThreadProcessId(IntPtr, ref pid);
                            _threadId = new IntPtr(tid);
                            _processId = new IntPtr(pid);
                        }
                    });
                    return _processId;
                }
            }
            private WindowModel _parent;
            /// <summary>
            /// 父窗口
            /// </summary>
            public WindowModel Parent
            {
                get
                {
                    SetPar(_parent, () =>
                    {
                        if (!this) { _parent = Empty; }
                        else
                        {
                            var res = User32Api.GetParent(IntPtr);
                            if (res != default(IntPtr))
                            {
                                _parent = new WindowModel(res);
                            }
                            else
                            {
                                _parent = new WindowModel(User32Api.GetDesktopWindow());
                            }
                        }
                    });
                    return _parent;
                }
            }
            private WindowModel _next;
            /// <summary>
            /// 下一个窗口
            /// </summary>
            public WindowModel Next
            {
                get
                {
                    SetPar(_next, () =>
                    {
                        if (!this) { _next = Empty; }
                        else
                        {
                            var res = User32Api.FindWindowEx(Parent.IntPtr, IntPtr, null, null);
                            if (res != default(IntPtr))
                            {
                                _next = new WindowModel(res);
                            }
                        }
                    });
                    return _next;
                }
            }
            private ModelList _child;
            /// <summary>
            /// 获取所有子窗口（注意  获取元素时队列中不存在也不会报错，而是返回Empty）
            /// </summary>
            public ModelList Child
            {
                get
                {
                    SetPar(_child, () =>
                    {
                        _child = new ModelList();
                        if (!this) return;
                        IntPtr ip = IntPtr.Zero;
                        IntPtr res = IntPtr.Zero;
                        do
                        {
                            res = User32Api.FindWindowEx(IntPtr, ip, null, null);
                            if (res != default(IntPtr))
                            {
                                ip = res;
                                _child.Add(new WindowModel(res));
                            }
                        } while (res != IntPtr.Zero);
                    });
                    return _child;
                }
                set
                {
                    _child = null;
                }
            }
            private void SetPar<T>(T par, Action act)
            {
                if (par == null || par.Equals(default(T)))
                {
                    act();
                }
            }
            public WindowModel(IntPtr IntPtr)
            {
                this.IntPtr = IntPtr;
            }
            /// <summary>
            /// 从所有子窗体中查找指定的类名
            /// </summary>
            /// <param name="parent"></param>
            /// <param name="lpClassName"></param>
            /// <returns></returns>
            public WindowModel FindChildWindow(string lpClassName, string title = null)
            {
                if (!this) return Empty;
                WindowModel res = Empty;
                WindowHelp.FindChildWindow(this, lpClassName, ref res, title);
                return res;
            }
            /// <summary>
            /// 点击控件
            /// </summary>
            public void Click()
            {
                if (!this) return;
                int x = WindowRectangle.Left + WindowRectangle.Width / 2;
                int y = WindowRectangle.Top + WindowRectangle.Height / 2;
                SetCursorPos(x, y);
                WindowHelp.Click();
            }
            /// <summary>
            /// 激活窗体
            /// </summary>
            /// <returns></returns>
            public bool SetAction()
            {
                if (!this) return false;
                return User32Api.SetForegroundWindow(IntPtr);
            }
            public Bitmap SaveImage()
            {
                if (!this) return null;
                return PrintWindow(this);
            }
            public Bitmap SaveImage2()
            {
                if (!this) return null;
                return BitBlt(this);
            }
            /// <summary>
            /// 设置鼠标的位置
            /// </summary>
            /// <param name="x">x坐标</param>
            /// <param name="y">y坐标</param>
            /// <param name="key">当前所按的鼠标键，默认为空</param>
            public int SetCursorPos(int x, int y, VKKey key = 0)
            {
                if (!this) return -1;
                return WindowHelp.SetCursorPos(IntPtr, x, y, key);
            }
            /// <summary>
            /// 设置鼠标的位置
            /// </summary>
            /// <param name="x">x坐标</param>
            /// <param name="y">y坐标</param>
            /// <param name="msg">操作内容</param>
            public int MouseHandle(WinMsg msg, int x, int y)
            {
                if (!this) return -1;
                return WindowHelp.MouseHandle(IntPtr, msg, x, y);
            }
            /// <summary>
            /// 输入按键
            /// </summary>
            /// <param name="key">输入的按键</param>
            public void InputKey(VKKey key)
            {
                if (!this) return;
                WindowHelp.InputKey(key, IntPtr);
            }
            public void PostMessage(WinMsg msg, int wParam = 0, int lParam = 0)
            {
                if (!this) return;
                WindowHelp.PostMessage(IntPtr, msg, wParam, lParam);
            }
            /// <summary>
            /// 关闭进程
            /// </summary>
            public void CloseProcess(int exitCode = 0)
            {
                if (!this) return;
                WindowHelp.CloseProcess(ProcessId, exitCode);
            }
            /// <summary>
            /// 关闭窗口
            /// </summary>
            public void CloseWindows()
            {
                if (!this) return;
                WindowHelp.CloseWindows(ProcessId);
            }

            public static bool operator true(WindowModel model) => model != null && model != Empty;
            public static bool operator false(WindowModel model) => model == null || model == Empty;
            public static bool operator ==(WindowModel model, bool b) => b == (model != null && model != Empty);
            public static bool operator !=(WindowModel model, bool b) => b == (model != null && model != Empty);
            public static bool operator !(WindowModel model) => !(model != null && model != Empty);
        }
        public class ModelList : List<WindowModel>
        {
            public WindowModel this[int num]
            {
                get
                {
                    if (Count <= num) return WindowModel.Empty;
                    else return base[num];
                }
            }
        }
    }

}

