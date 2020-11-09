using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Model
{
    public class Enums
    {
        /// <summary>
        /// 光标形状
        /// </summary>
        public enum HCursor
        {
            /// <summary>
            /// 标准箭头和小沙漏光标。
            /// </summary>
            IDC_APPSTARTING,//MAKEINTRESOURCE（32650）

            /// <summary>
            /// 标准箭头光标。
            /// </summary>      
            IDC_ARROW = 65539,//MAKEINTRESOURCE（32512）
            /// <summary>
            /// 十字准线光标。
            /// </summary>        
            IDC_CROSS,//MAKEINTRESOURCE（32515）

            /// <summary>
            /// 手指光标。
            /// </summary>  
            IDC_HAND= 65567,//MAKEINTRESOURCE（32649）

            /// <summary>
            /// 箭头和问号光标。
            /// </summary>  
            IDC_HELP,//MAKEINTRESOURCE（32651）

            /// <summary>
            /// I光束光标。
            /// </summary>  
            IDC_IBEAM = 65541,//MAKEINTRESOURCE（32513）

            /// <summary>
            /// 斜线圈光标。
            /// </summary>  
            IDC_NO,//MAKEINTRESOURCE（32648）

            /// <summary>
            /// 四箭箭头指向北，南，东，西。
            /// </summary>  
            IDC_SIZEALL,//MAKEINTRESOURCE（32646）

            /// <summary>
            /// 指向东北和西南的双向箭头光标。
            /// </summary>  
            IDC_SIZENESW=65551,//MAKEINTRESOURCE（32643）

            /// <summary>
            /// 双向箭头光标指向南北。
            /// </summary>  
            IDC_SIZENS=65555,//MAKEINTRESOURCE（32645）

            /// <summary>
            /// 指向西北和东南方向的双向箭头光标。
            /// </summary>  
            IDC_SIZENWSE=65549,//MAKEINTRESOURCE（32642）

            /// <summary>
            /// 双向箭头指向西和东。
            /// </summary>  
            IDC_SIZEWE=65553,//MAKEINTRESOURCE（32644）

            /// <summary>
            /// 垂直箭头光标。
            /// </summary>  
            IDC_UPARROW,//MAKEINTRESOURCE（32516）

            /// <summary>
            /// 沙漏光标。
            /// </summary>  
            IDC_WAIT,//MAKEINTRESOURCE（32514）

            /// <summary>
            /// 应用程序图标
            /// </summary>  
            IDI_APPLICATION,//MAKEINTRESOURCE（32512）

            /// <summary>
            /// 星号图标。
            /// </summary>  
            IDI_ASTERISK,//MAKEINTRESOURCE（32516）

            /// <summary>
            /// 感叹号图标。
            /// </summary>  
            IDI_EXCLAMATION,//MAKEINTRESOURCE（32515）

            /// <summary>
            /// 停止标志图标。
            /// </summary>  
            IDI_HAND,//MAKEINTRESOURCE（32513）

            /// <summary>
            /// 问号图标。
            /// </summary>  
            IDI_QUESTION,//MAKEINTRESOURCE（32514）

            /// <summary>
            /// 应用程序图标Windows 2000：   Windows徽标图标。
            /// </summary>  
            IDI_WINLOGO,//MAKEINTRESOURCE（32517）


        }
        /// <summary>
        /// 按键消息
        /// </summary>
        public enum VKKey
        {
            // mouse movements  
            move = 0x0001,
            leftdown = 0x0002,
            leftup = 0x0004,
            rightdown = 0x0008,
            rightup = 0x0010,
            middledown = 0x0020,
            //keyboard stuff  
            VK_LBUTTON = 1,
            VK_RBUTTON = 2,
            VK_CANCEL = 3,
            VK_MBUTTON = 4,
            VK_BACK = 8,
            VK_TAB = 9,
            VK_CLEAR = 12,
            VK_RETURN = 13,
            VK_SHIFT = 16,
            VK_CONTROL = 17,
            VK_MENU = 18,
            VK_PAUSE = 19,
            VK_CAPITAL = 20,
            VK_ESCAPE = 27,
            VK_SPACE = 32,
            VK_PRIOR = 33,
            VK_NEXT = 34,
            VK_END = 35,
            VK_HOME = 36,
            VK_LEFT = 37,
            VK_UP = 38,
            VK_RIGHT = 39,
            VK_DOWN = 40,
            VK_SELECT = 41,
            VK_PRINT = 42,
            VK_EXECUTE = 43,
            VK_SNAPSHOT = 44,
            VK_INSERT = 45,
            VK_DELETE = 46,
            VK_HELP = 47,
            VK_NUM0 = 48, //0  
            VK_NUM1 = 49, //1  
            VK_NUM2 = 50, //2  
            VK_NUM3 = 51, //3  
            VK_NUM4 = 52, //4  
            VK_NUM5 = 53, //5  
            VK_NUM6 = 54, //6  
            VK_NUM7 = 55, //7  
            VK_NUM8 = 56, //8  
            VK_NUM9 = 57, //9  
            VK_A = 65, //A  
            VK_B = 66, //B  
            VK_C = 67, //C  
            VK_D = 68, //D  
            VK_E = 69, //E  
            VK_F = 70, //F  
            VK_G = 71, //G  
            VK_H = 72, //H  
            VK_I = 73, //I  
            VK_J = 74, //J  
            VK_K = 75, //K  
            VK_L = 76, //L  
            VK_M = 77, //M  
            VK_N = 78, //N  
            VK_O = 79, //O  
            VK_P = 80, //P  
            VK_Q = 81, //Q  
            VK_R = 82, //R  
            VK_S = 83, //S  
            VK_T = 84, //T  
            VK_U = 85, //U  
            VK_V = 86, //V  
            VK_W = 87, //W  
            VK_X = 88, //X  
            VK_Y = 89, //Y  
            VK_Z = 90, //Z  
            VK_NUMPAD0 = 96, //0  
            VK_NUMPAD1 = 97, //1  
            VK_NUMPAD2 = 98, //2  
            VK_NUMPAD3 = 99, //3  
            VK_NUMPAD4 = 100, //4  
            VK_NUMPAD5 = 101, //5  
            VK_NUMPAD6 = 102, //6  
            VK_NUMPAD7 = 103, //7  
            VK_NUMPAD8 = 104, //8  
            VK_NUMPAD9 = 105, //9  
            VK_NULTIPLY = 106,
            VK_ADD = 107,
            VK_SEPARATOR = 108,
            VK_SUBTRACT = 109,
            VK_DECIMAL = 110,
            VK_DIVIDE = 111,
            VK_F1 = 112,
            VK_F2 = 113,
            VK_F3 = 114,
            VK_F4 = 115,
            VK_F5 = 116,
            VK_F6 = 117,
            VK_F7 = 118,
            VK_F8 = 119,
            VK_F9 = 120,
            VK_F10 = 121,
            VK_F11 = 122,
            VK_F12 = 123,
            VK_NUMLOCK = 144,
            VK_SCROLL = 145,
            middleup = 0x0040,
            xdown = 0x0080,
            xup = 0x0100,
            wheel = 0x0800,
            virtualdesk = 0x4000,
            absolute = 0x8000
        }
        /// <summary>
        /// 命令(注意字节位数为2,16位数字)
        /// </summary>
        public enum Command
        {
            /// <summary>
            /// 确认收到
            /// </summary>
            ConfirmReceipt = 1,
            /// <summary>
            /// 发送文件头
            /// </summary>
            SendTheFileHeader = 2,
            /// <summary>
            /// 发送数据
            /// </summary>
            SendData = 3,
            /// <summary>
            /// 传输结束
            /// </summary>
            SendEnd = 4
        }
        /// <summary>
        /// 鼠标消息
        /// </summary>
        public enum DwFlags
        {
            /// <summary>
            /// dX和dY参数含有规范化的绝对坐标。如果不设置，这些参数含有相对数据：相对于上次位置的改动位置。此标志可设置，也可不设置，不管鼠标的类型或与系统相连的类似于鼠标的设备的类型如何。要得到关于相对鼠标动作的信息，参见下面备注部分
            /// </summary>
            MOUSEEVENTF_ABSOLUTE = 0x8000,//
            /// <summary>
            /// 表明发生移动
            /// </summary>
            MOUSEEVENTF_MOVE = 0x1,//。
            /// <summary>
            /// 表明接按下鼠标左键
            /// </summary>
            MOUSEEVENTF_LEFTDOWN = 0x2,//。
            /// <summary>
            /// 表明松开鼠标左键
            /// </summary>
            MOUSEEVENTF_LEFTUP = 0x4,//。
            /// <summary>
            /// 表明按下鼠标右键
            /// </summary>
            MOUSEEVENTF_RIGHTDOWN = 0x8,//：。
            /// <summary>
            ///表明松开鼠标右键
            /// </summary>
            MOUSEEVENTF_RIGHTUP = 0x10,//：。
            /// <summary>
            /// 表明按下鼠标中键
            /// </summary>
            MOUSEEVENTF_MIDDLEDOWN = 0x20,//：。
            /// <summary>
            /// 表明松开鼠标中键
            /// </summary>
            MOUSEEVENTF_MIDDLEUP = 0x40,//：。
            /// <summary>
            /// 在Windows
            /// </summary>
            MOUSEEVENTF_WHEEL//： NT中如果鼠标有一个轮，表明鼠标轮被移动。移动的数量由dwData给出。

        }
        /// <summary>
        /// 键盘钩子的类型
        /// </summary>
        public enum KeyBoardHookType
        {
            /// <summary>
            /// 全局钩子
            /// </summary>
            Global = 2,
            /// <summary>
            /// 进程钩子
            /// </summary>
            Process = 13
        }
        /// <summary>
        /// 钩子类型
        /// </summary>
        public enum KeyHookType
        {
            /// <summary>
            /// 私有钩子
            /// </summary>
            WH_KEYBOARD = 2,
            /// <summary>
            /// 全局钩子
            /// </summary>
            WH_KEYBOARD_LL = 13
        }
        /// <summary>     
        /// 设置的钩子类型
        /// </summary>
        public enum HookType
        {
            /// <summary>
            /// WH_MSGFILTER 和 WH_SYSMSGFILTER Hooks使我们可以监视菜单，滚动 
            ///条，消息框，对话框消息并且发现用户使用ALT+TAB or ALT+ESC 组合键切换窗口。 
            ///WH_MSGFILTER Hook只能监视传递到菜单，滚动条，消息框的消息，以及传递到通 
            ///过安装了Hook子过程的应用程序建立的对话框的消息。WH_SYSMSGFILTER Hook 
            ///监视所有应用程序消息。 
            /// 
            ///WH_MSGFILTER 和 WH_SYSMSGFILTER Hooks使我们可以在模式循环期间 
            ///过滤消息，这等价于在主消息循环中过滤消息。 
            ///    
            ///通过调用CallMsgFilter function可以直接的调用WH_MSGFILTER Hook。通过使用这 
            ///个函数，应用程序能够在模式循环期间使用相同的代码去过滤消息，如同在主消息循 
            ///环里一样
            /// </summary>
            WH_MSGFILTER = -1,
            /// <summary>
            /// WH_JOURNALRECORD Hook用来监视和记录输入事件。典型的，可以使用这 
            ///来回放。WH_JOURNALRECORD Hook是全局Hook，它不能象线程特定Hook一样 
            ///使用。WH_JOURNALRECORD是system-wide local hooks，它们不会被注射到任何行 
            ///程地址空间
            /// </summary>
            WH_JOURNALRECORD = 0,
            /// <summary>
            /// WH_JOURNALPLAYBACK Hook使应用程序可以插入消息到系统消息队列。可 
            ///以使用这个Hook回放通过使用WH_JOURNALRECORD Hook记录下来的连续的鼠 
            ///标和键盘事件。只要WH_JOURNALPLAYBACK Hook已经安装，正常的鼠标和键盘 
            ///事件就是无效的。WH_JOURNALPLAYBACK Hook是全局Hook，它不能象线程特定 
            ///Hook一样使用。WH_JOURNALPLAYBACK Hook返回超时值，这个值告诉系统在处 
            ///理来自回放Hook当前消息之前需要等待多长时间（毫秒）。这就使Hook可以控制实 
            ///时事件的回放。WH_JOURNALPLAYBACK是system-wide local hooks，它们不会被 
            ///注射到任何行程地址空间
            /// </summary>
            WH_JOURNALPLAYBACK = 1,
            /// <summary>
            /// 在应用程序中，WH_KEYBOARD Hook用来监视WM_KEYDOWN and  
            ///WM_KEYUP消息，这些消息通过GetMessage or PeekMessage function返回。可以使 
            ///用这个Hook来监视输入到消息队列中的键盘消息
            /// </summary>
            WH_KEYBOARD = 2,
            /// <summary>
            /// 应用程序使用WH_GETMESSAGE Hook来监视从GetMessage or PeekMessage函 
            ///数返回的消息。你可以使用WH_GETMESSAGE Hook去监视鼠标和键盘输入，以及 
            ///其它发送到消息队列中的消息
            /// </summary>
            WH_GETMESSAGE = 3,
            /// <summary>
            /// 监视发送到窗口过程的消息，系统在消息发送到接收窗口过程之前调用
            /// </summary>
            WH_CALLWNDPROC = 4,
            /// <summary>
            /// 在以下事件之前，系统都会调用WH_CBT Hook子过程，这些事件包括： 
            ///1. 激活，建立，销毁，最小化，最大化，移动，改变尺寸等窗口事件； 
            ///2. 完成系统指令； 
            ///3. 来自系统消息队列中的移动鼠标，键盘事件； 
            ///4. 设置输入焦点事件； 
            ///5. 同步系统消息队列事件。
            ///Hook子过程的返回值确定系统是否允许或者防止这些操作中的一个
            /// </summary>
            WH_CBT = 5,
            /// <summary>
            /// WH_MSGFILTER 和 WH_SYSMSGFILTER Hooks使我们可以监视菜单，滚动 
            ///条，消息框，对话框消息并且发现用户使用ALT+TAB or ALT+ESC 组合键切换窗口。 
            ///WH_MSGFILTER Hook只能监视传递到菜单，滚动条，消息框的消息，以及传递到通 
            ///过安装了Hook子过程的应用程序建立的对话框的消息。WH_SYSMSGFILTER Hook 
            ///监视所有应用程序消息。 
            /// 
            ///WH_MSGFILTER 和 WH_SYSMSGFILTER Hooks使我们可以在模式循环期间 
            ///过滤消息，这等价于在主消息循环中过滤消息。 
            ///    
            ///通过调用CallMsgFilter function可以直接的调用WH_MSGFILTER Hook。通过使用这 
            ///个函数，应用程序能够在模式循环期间使用相同的代码去过滤消息，如同在主消息循 
            ///环里一样
            /// </summary>
            WH_SYSMSGFILTER = 6,
            /// <summary>
            /// WH_MOUSE Hook监视从GetMessage 或者 PeekMessage 函数返回的鼠标消息。 
            ///使用这个Hook监视输入到消息队列中的鼠标消息
            /// </summary>
            WH_MOUSE = 7,
            /// <summary>
            /// 当调用GetMessage 或 PeekMessage 来从消息队列种查询非鼠标、键盘消息时
            /// </summary>
            WH_HARDWARE = 8,
            /// <summary>
            /// 在系统调用系统中与其它Hook关联的Hook子过程之前，系统会调用 
            ///WH_DEBUG Hook子过程。你可以使用这个Hook来决定是否允许系统调用与其它 
            ///Hook关联的Hook子过程
            /// </summary>
            WH_DEBUG = 9,
            /// <summary>
            /// 外壳应用程序可以使用WH_SHELL Hook去接收重要的通知。当外壳应用程序是 
            ///激活的并且当顶层窗口建立或者销毁时，系统调用WH_SHELL Hook子过程。 
            ///WH_SHELL 共有５钟情况： 
            ///1. 只要有个top-level、unowned 窗口被产生、起作用、或是被摧毁； 
            ///2. 当Taskbar需要重画某个按钮； 
            ///3. 当系统需要显示关于Taskbar的一个程序的最小化形式； 
            ///4. 当目前的键盘布局状态改变； 
            ///5. 当使用者按Ctrl+Esc去执行Task Manager（或相同级别的程序）。 
            ///
            ///按照惯例，外壳应用程序都不接收WH_SHELL消息。所以，在应用程序能够接 
            ///收WH_SHELL消息之前，应用程序必须调用SystemParametersInfo function注册它自 
            ///己
            /// </summary>
            WH_SHELL = 10,
            /// <summary>
            /// 当应用程序的前台线程处于空闲状态时，可以使用WH_FOREGROUNDIDLE  
            ///Hook执行低优先级的任务。当应用程序的前台线程大概要变成空闲状态时，系统就 
            ///会调用WH_FOREGROUNDIDLE Hook子过程
            /// </summary>
            WH_FOREGROUNDIDLE = 11,
            /// <summary>
            /// 监视发送到窗口过程的消息，系统在消息发送到接收窗口过程之后调用
            /// </summary>
            WH_CALLWNDPROCRET = 12,
            /// <summary>
            /// 监视输入到线程消息队列中的键盘消息
            /// </summary>
            WH_KEYBOARD_LL = 13,
            /// <summary>
            /// 监视输入到线程消息队列中的鼠标消息
            /// </summary>
            WH_MOUSE_LL = 14
        }
        /// <summary>
        /// 辅助键
        /// </summary>
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
        #region Peek Message Flags

        public enum PeekMessageFlags
        {
            PM_NOREMOVE = 0,
            PM_REMOVE = 1,
            PM_NOYIELD = 2
        }
        #endregion


        #region Windows Messages
        /// <summary>
        /// windows消息
        /// </summary>
        public enum WinMsg
        {
            WM_NULL = 0x0000,
            /// <summary>
            ///  //创建一个窗口
            /// </summary>
            WM_CREATE = 0x0001,
            /// <summary>
            /// 当一个窗口被破坏时发送
            /// </summary>
            WM_DESTROY = 0x0002,
            /// <summary>
            /// 移动一个窗口
            /// </summary>
            WM_MOVE = 0x0003,
            /// <summary>
            /// 改变一个窗口的大小
            /// </summary>
            WM_SIZE = 0x0005,
            /// <summary>
            /// 一个窗口被激活或失去激活状态
            /// </summary>
            WM_ACTIVATE = 0x0006,
            /// <summary>
            /// 一个窗口获得焦点
            /// </summary>
            WM_SETFOCUS = 0x0007,
            /// <summary>
            /// 一个窗口失去焦点
            /// </summary>
            WM_KILLFOCUS = 0x0008,
            /// <summary>
            /// 一个窗口改变成Enable状态
            /// </summary>
            WM_ENABLE = 0x000A,
            /// <summary>
            /// 设置窗口是否能重画
            /// </summary>
            WM_SETREDRAW = 0x000B,
            /// <summary>
            /// 应用程序发送此消息来设置一个窗口的文本
            /// </summary>
            WM_SETTEXT = 0x000C,
            /// <summary>
            /// 应用程序发送此消息来复制对应窗口的文本到缓冲区
            /// </summary>
            WM_GETTEXT = 0x000D,
            /// <summary>
            /// 得到与一个窗口有关的文本的长度（不包含空字符）
            /// </summary>
            WM_GETTEXTLENGTH = 0x000E,
            /// <summary>
            /// 要求一个窗口重画自己
            /// </summary>
            WM_PAINT = 0x000F,
            /// <summary>
            /// 当一个窗口或应用程序要关闭时发送一个信号
            /// </summary>
            WM_CLOSE = 0x0010,
            /// <summary>
            /// 当用户选择结束对话框或程序自己调用ExitWindows函数
            /// </summary>
            WM_QUERYENDSESSION = 0x0011,
            /// <summary>
            /// 用来结束程序运行
            /// </summary>
            WM_QUIT = 0x0012,
            /// <summary>
            /// 当用户窗口恢复以前的大小位置时，把此消息发送给某个图标
            /// </summary>
            WM_QUERYOPEN = 0x0013,
            /// <summary>
            /// 当窗口背景必须被擦除时（例在窗口改变大小时）
            /// </summary>
            WM_ERASEBKGND = 0x0014,
            /// <summary>
            /// 当系统颜色改变时，发送此消息给所有顶级窗口
            /// </summary>
            WM_SYSCOLORCHANGE = 0x0015,
            /// <summary>
            /// 当系统进程发出WM_QUERYENDSESSION消息后，此消息发送给应用程序，通知它对话是否结束
            /// </summary>
            WM_ENDSESSION = 0x0016,
            /// <summary>
            /// 当隐藏或显示窗口是发送此消息给这个窗口
            /// </summary>
            WM_SHOWWINDOW = 0x0018,
            WM_CTLCOLOR = 0x0019,
            WM_WININICHANGE = 0x001A,
            WM_SETTINGCHANGE = 0x001A,
            WM_DEVMODECHANGE = 0x001B,
            /// <summary>
            /// 发此消息给应用程序哪个窗口是激活的，哪个是非激活的
            /// </summary>
            WM_ACTIVATEAPP = 0x001C,
            /// <summary>
            /// 当系统的字体资源库变化时发送此消息给所有顶级窗口
            /// </summary>
            WM_FONTCHANGE = 0x001D,
            /// <summary>
            /// 当系统的时间变化时发送此消息给所有顶级窗口
            /// </summary>
            WM_TIMECHANGE = 0x001E,
            /// <summary>
            /// 发送此消息来取消某种正在进行的摸态（操作）
            /// </summary>
            WM_CANCELMODE = 0x001F,
            /// <summary>
            /// 如果鼠标引起光标在某个窗口中移动且鼠标输入没有被捕获时，就发消息给某个窗口
            /// </summary>
            WM_SETCURSOR = 0x0020,
            /// <summary>
            /// 当光标在某个非激活的窗口中而用户正按着鼠标的某个键发送此消息给当前窗口
            /// </summary>
            WM_MOUSEACTIVATE = 0x0021,
            /// <summary>
            /// 发送此消息给MDI子窗口当用户点击此窗口的标题栏，或当窗口被激活，移动，改变大小
            /// </summary>
            WM_CHILDACTIVATE = 0x0022,
            /// <summary>
            /// 此消息由基于计算机的训练程序发送，通过WH_JOURNALPALYBACK的hook程序分离出用户输入消息
            /// </summary>
            WM_QUEUESYNC = 0x0023,
            /// <summary>
            /// //此消息发送给窗口当它将要改变大小或位置
            /// </summary>
            WM_GETMINMAXINFO = 0x0024,
            /// <summary>
            /// 发送给最小化窗口当它图标将要被重画
            /// </summary>
            WM_PAINTICON = 0x0026,
            /// <summary>
            /// 此消息发送给某个最小化窗口，仅当它在画图标前它的背景必须被重画
            /// </summary>
            WM_ICONERASEBKGND = 0x0027,
            /// <summary>
            /// 发送此消息给一个对话框程序去更改焦点位置
            /// </summary>
            WM_NEXTDLGCTL = 0x0028,
            /// <summary>
            /// 每当打印管理列队增加或减少一条作业时发出此消息
            /// </summary>
            WM_SPOOLERSTATUS = 0x002A,
            /// <summary>
            /// 当button，combobox，listbox，menu的可视外观改变时发送
            /// </summary>
            WM_DRAWITEM = 0x002B,
            /// <summary>
            /// 当button, combo box, list box, list view control, or menu item 被创建时
            /// </summary>
            WM_MEASUREITEM = 0x002C,
            /// <summary>
            /// 
            /// </summary>
            WM_DELETEITEM = 0x002D,
            /// <summary>
            /// 此消息有一个LBS_WANTKEYBOARDINPUT风格的发出给它的所有者来响应WM_KEYDOWN消息
            /// </summary>
            WM_VKEYTOITEM = 0x002E,
            /// <summary>
            /// 此消息由一个LBS_WANTKEYBOARDINPUT风格的列表框发送给他的所有者来响应WM_CHAR消息
            /// </summary>
            WM_CHARTOITEM = 0x002F,
            /// <summary>
            /// 当绘制文本时程序发送此消息得到控件要用的颜色
            /// </summary>
            WM_SETFONT = 0x0030,
            /// <summary>
            /// 应用程序发送此消息得到当前控件绘制文本的字体
            /// </summary>
            WM_GETFONT = 0x0031,
            /// <summary>
            /// 应用程序发送此消息让一个窗口与一个热键相关连
            /// </summary>
            WM_SETHOTKEY = 0x0032,
            /// <summary>
            /// 应用程序发送此消息来判断热键与某个窗口是否有关联
            /// </summary>
            WM_GETHOTKEY = 0x0033,
            /// <summary>
            /// 此消息发送给最小化窗口，当此窗口将要被拖放而它的类中没有定义图标，应用程序能返回一个图标或光标的句柄，当用户拖放图标时系统显示这个图标或光标
            /// </summary>
            WM_QUERYDRAGICON = 0x0037,
            /// <summary>
            /// 发送此消息来判定combobox或listbox新增加的项的相对位置
            /// </summary>
            WM_COMPAREITEM = 0x0039,
            /// <summary>
            /// 
            /// </summary>
            WM_GETOBJECT = 0x003D,
            /// <summary>
            /// 显示内存已经很少了
            /// </summary>
            WM_COMPACTING = 0x0041,
            /// <summary>
            /// 
            /// </summary>
            WM_COMMNOTIFY = 0x0044,
            /// <summary>
            /// 发送此消息给那个窗口的大小和位置将要被改变时，来调用setwindowpos函数或其它窗口管理函数
            /// </summary>
            WM_WINDOWPOSCHANGING = 0x0046,
            /// <summary>
            /// 发送此消息给那个窗口的大小和位置已经被改变时，来调用setwindowpos函数或其它窗口管理函数
            /// </summary>
            WM_WINDOWPOSCHANGED = 0x0047,
            /// <summary>
            /// 
            /// </summary>
            WM_POWER = 0x0048,
            /// <summary>
            /// 当一个应用程序传递数据给另一个应用程序时发送此消息
            /// </summary>
            WM_COPYDATA = 0x004A,
            /// <summary>
            /// 当某个用户取消程序日志激活状态，提交此消息给程序
            /// </summary>
            WM_CANCELJOURNAL = 0x004B,
            /// <summary>
            /// 当某个控件的某个事件已经发生或这个控件需要得到一些信息时，发送此消息给它的父窗口
            /// </summary>
            WM_NOTIFY = 0x004E,
            /// <summary>
            /// 当用户选择某种输入语言，或输入语言的热键改变
            /// </summary>
            WM_INPUTLANGCHANGEREQUEST = 0x0050,
            /// <summary>
            /// 当平台现场已经被改变后发送此消息给受影响的最顶级窗口
            /// </summary>
            WM_INPUTLANGCHANGE = 0x0051,
            /// <summary>
            /// 当程序已经初始化windows帮助例程时发送此消息给应用程序
            /// </summary>
            WM_TCARD = 0x0052,
            /// <summary>
            /// 此消息显示用户按下了F1，如果某个菜单是激活的，就发送此消息个此窗口关联的菜单，否则就发送给有焦点的窗口，如果当前都没有焦点，就把此消息发送给当前激活的窗口
            /// </summary>
            WM_HELP = 0x0053,
            /// <summary>
            /// 当用户已经登入或退出后发送此消息给所有的窗口，当用户登入或退出时系统更新用户的具体设置信息，在用户更新设置时系统马上发送此消息
            /// </summary>
            WM_USERCHANGED = 0x0054,
            /// <summary>
            /// 公用控件，自定义控件和他们的父窗口通过此消息来判断控件是使用ANSI还是UNICODE结构
            /// </summary>
            WM_NOTIFYFORMAT = 0x0055,
            /// <summary>
            /// 当用户某个窗口中点击了一下右键就发送此消息给这个窗口
            /// </summary>
            WM_CONTEXTMENU = 0x007B,
            /// <summary>
            /// 当调用SETWINDOWLONG函数将要改变一个或多个 窗口的风格时发送此消息给那个窗口
            /// </summary>
            WM_STYLECHANGING = 0x007C,
            /// <summary>
            /// 当调用SETWINDOWLONG函数一个或多个 窗口的风格后发送此消息给那个窗口
            /// </summary>
            WM_STYLECHANGED = 0x007D,
            /// <summary>
            /// 当显示器的分辨率改变后发送此消息给所有的窗口
            /// </summary>
            WM_DISPLAYCHANGE = 0x007E,
            /// <summary>
            /// 此消息发送给某个窗口来返回与某个窗口有关连的大图标或小图标的句柄
            /// </summary>
            WM_GETICON = 0x007F,
            /// <summary>
            /// 程序发送此消息让一个新的大图标或小图标与某个窗口关联
            /// </summary>
            WM_SETICON = 0x0080,
            /// <summary>
            /// 当某个窗口第一次被创建时，此消息在WM_CREATE消息发送前发送
            /// </summary>
            WM_NCCREATE = 0x0081,
            /// <summary>
            /// 此消息通知某个窗口，非客户区正在销毁
            /// </summary>
            WM_NCDESTROY = 0x0082,
            /// <summary>
            /// 当某个窗口的客户区域必须被核算时发送此消息
            /// </summary>
            WM_NCCALCSIZE = 0x0083,
            /// <summary>
            /// 移动鼠标，按住或释放鼠标时发生
            /// </summary>
            WM_NCHITTEST = 0x0084,
            /// <summary>
            /// 程序发送此消息给某个窗口当它（窗口）的框架必须被绘制时
            /// </summary>
            WM_NCPAINT = 0x0085,
            /// <summary>
            /// 此消息发送给某个窗口仅当它的非客户区需要被改变来显示是激活还是非激活状态
            /// </summary>
            WM_NCACTIVATE = 0x0086,
            /// <summary>
            /// 发送此消息给某个与对话框程序关联的控件，widdows控制方位键和TAB键使输入进入此控件通过应
            /// </summary>
            WM_GETDLGCODE = 0x0087,
            /// <summary>
            /// 
            /// </summary>
            WM_SYNCPAINT = 0x0088,
            /// <summary>
            /// 当光标在一个窗口的非客户区内移动时发送此消息给这个窗口 非客户区为：窗体的标题栏及窗 的边框体
            /// </summary>
            WM_NCMOUSEMOVE = 0x00A0,
            /// <summary>
            /// 当光标在一个窗口的非客户区同时按下鼠标左键时提交此消息
            /// </summary>
            WM_NCLBUTTONDOWN = 0x00A1,
            /// <summary>
            /// 当用户释放鼠标左键同时光标某个窗口在非客户区时发送此消息
            /// </summary>
            WM_NCLBUTTONUP = 0x00A2,
            /// <summary>
            /// 当用户双击鼠标左键同时光标某个窗口在非客户区时发送此消息
            /// </summary>
            WM_NCLBUTTONDBLCLK = 0x00A3,
            /// <summary>
            /// 当用户按下鼠标右键同时光标又在窗口的非客户区时发送此消息
            /// </summary>
            WM_NCRBUTTONDOWN = 0x00A4,
            /// <summary>
            /// 当用户释放鼠标右键同时光标又在窗口的非客户区时发送此消息
            /// </summary>
            WM_NCRBUTTONUP = 0x00A5,
            /// <summary>
            /// 当用户双击鼠标右键同时光标某个窗口在非客户区时发送此消息
            /// </summary>
            WM_NCRBUTTONDBLCLK = 0x00A6,
            /// <summary>
            /// 当用户按下鼠标中键同时光标又在窗口的非客户区时发送此消息
            /// </summary>
            WM_NCMBUTTONDOWN = 0x00A7,
            /// <summary>
            /// 当用户释放鼠标中键同时光标又在窗口的非客户区时发送此消息
            /// </summary>
            WM_NCMBUTTONUP = 0x00A8,
            /// <summary>
            /// 当用户双击鼠标中键同时光标又在窗口的非客户区时发送此消息
            /// </summary>
            WM_NCMBUTTONDBLCLK = 0x00A9,
            BM_GETCHECK = 0x00f0,
            BM_SETCHECK = 0x00f1,
            BM_GETSTATE = 0x00f2,
            BM_SETSTATE = 0x00f3,
            BM_SETSTYLE = 0x00f4,
            BM_CLICK = 0x00f5,
            BM_GETIMAGE = 0x00f6,
            BM_SETIMAGE = 0x00f7,

            /// <summary>
            /// 按下一个键
            /// </summary>
            WM_KEYDOWN = 0x0100,
            /// <summary>
            /// 释放一个键
            /// </summary>
            WM_KEYUP = 0x0101,
            /// <summary>
            /// 按下某键，并已发出WM_KEYDOWN， WM_KEYUP消息
            /// </summary>
            WM_CHAR = 0x0102,
            /// <summary>
            /// 当用translatemessage函数翻译WM_KEYUP消息时发送此消息给拥有焦点的窗口
            /// </summary>
            WM_DEADCHAR = 0x0103,
            /// <summary>
            /// 当用户按住ALT键同时按下其它键时提交此消息给拥有焦点的窗口
            /// </summary>
            WM_SYSKEYDOWN = 0x0104,
            /// <summary>
            /// 当用户释放一个键同时ALT 键还按着时提交此消息给拥有焦点的窗口
            /// </summary>
            WM_SYSKEYUP = 0x0105,
            /// <summary>
            /// 当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后提交此消息给拥有焦点的窗口
            /// </summary>
            WM_SYSCHAR = 0x0106,
            /// <summary>
            /// 当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后发送此消息给拥有焦点的窗口
            /// </summary>
            WM_SYSDEADCHAR = 0x0107,
            /// <summary>
            /// 
            /// </summary>
            WM_KEYLAST = 0x0108,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_STARTCOMPOSITION = 0x010D,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_ENDCOMPOSITION = 0x010E,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_COMPOSITION = 0x010F,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_KEYLAST = 0x010F,
            /// <summary>
            /// 在一个对话框程序被显示前发送此消息给它，通常用此消息初始化控件和执行其它任务
            /// </summary>
            WM_INITDIALOG = 0x0110,
            /// <summary>
            /// 当用户选择一条菜单命令项或当某个控件发送一条消息给它的父窗口，一个快捷键被翻译
            /// </summary>
            WM_COMMAND = 0x0111,
            /// <summary>
            /// 当用户选择窗口菜单的一条命令或当用户选择最大化或最小化时那个窗口会收到此消息
            /// </summary>
            WM_SYSCOMMAND = 0x0112,
            /// <summary>
            /// 发生了定时器事件
            /// </summary>
            WM_TIMER = 0x0113,
            /// <summary>
            /// 当一个窗口标准水平滚动条产生一个滚动事件时发送此消息给那个窗口，也发送给拥有它的控件
            /// </summary>
            WM_HSCROLL = 0x0114,
            /// <summary>
            /// 当一个窗口标准垂直滚动条产生一个滚动事件时发送此消息给那个窗口也，发送给拥有它的控件
            /// </summary>
            WM_VSCROLL = 0x0115,
            /// <summary>
            /// 当一个菜单将要被激活时发送此消息，它发生在用户菜单条中的某项或按下某个菜单键，它允许程序在显示前更改菜单
            /// </summary>
            WM_INITMENU = 0x0116,
            /// <summary>
            /// 当一个下拉菜单或子菜单将要被激活时发送此消息，它允许程序在它显示前更改菜单，而不要改变全部
            /// </summary>
            WM_INITMENUPOPUP = 0x0117,
            /// <summary>
            /// 当用户选择一条菜单项时发送此消息给菜单的所有者（一般是窗口）
            /// </summary>
            WM_MENUSELECT = 0x011F,
            /// <summary>
            /// 当菜单已被激活用户按下了某个键（不同于加速键），发送此消息给菜单的所有者
            /// </summary>
            WM_MENUCHAR = 0x0120,
            /// <summary>
            /// 当一个模态对话框或菜单进入空载状态时发送此消息给它的所有者，一个模态对话框或菜单进入空载状态就是在处理完一条或几条先前的消息后没有消息它的列队中等待
            /// </summary>
            WM_ENTERIDLE = 0x0121,
            /// <summary>
            /// 
            /// </summary>
            WM_MENURBUTTONUP = 0x0122,
            /// <summary>
            /// 
            /// </summary>
            WM_MENUDRAG = 0x0123,
            /// <summary>
            /// 
            /// </summary>
            WM_MENUGETOBJECT = 0x0124,
            /// <summary>
            /// 
            /// </summary>
            WM_UNINITMENUPOPUP = 0x0125,
            /// <summary>
            /// 
            /// </summary>
            WM_MENUCOMMAND = 0x0126,
            /// <summary>
            /// 在windows绘制消息框前发送此消息给消息框的所有者窗口，通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置消息框的文本和背景颜色
            /// </summary>
            WM_CTLCOLORWinMsgBOX = 0x0132,
            /// <summary>
            /// 当一个编辑型控件将要被绘制时发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色
            /// </summary>
            WM_CTLCOLOREDIT = 0x0133,
            /// <summary>
            /// 当一个列表框控件将要被绘制前发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置列表框的文本和背景颜色
            /// </summary>
            WM_CTLCOLORLISTBOX = 0x0134,
            /// <summary>
            /// //当一个按钮控件将要被绘制时发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置按纽的文本和背景颜色
            /// </summary>
            WM_CTLCOLORBTN = 0x0135,
            /// <summary>
            /// 当一个对话框控件将要被绘制前发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置对话框的文本背景颜色
            /// </summary>
            WM_CTLCOLORDLG = 0x0136,
            /// <summary>
            /// 当一个滚动条控件将要被绘制时发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置滚动条的背景颜色
            /// </summary>
            WM_CTLCOLORSCROLLBAR = 0x0137,
            /// <summary>
            /// 当一个静态控件将要被绘制时发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以 通过使用给定的相关显示设备的句柄来设置静态控件的文本和背景颜色
            /// </summary>
            WM_CTLCOLORSTATIC = 0x0138,
            /// <summary>
            /// 移动鼠标时发生WM_MOUSEFIRST
            /// </summary>
            WM_MOUSEMOVE = 0x0200,
            /// <summary>
            /// 按下鼠标左键
            /// </summary>
            WM_LBUTTONDOWN = 0x0201,
            /// <summary>
            /// 释放鼠标左键
            /// </summary>
            WM_LBUTTONUP = 0x0202,
            /// <summary>
            /// 双击鼠标左键
            /// </summary>
            WM_LBUTTONDBLCLK = 0x0203,
            /// <summary>
            /// 按下鼠标右键
            /// </summary>
            WM_RBUTTONDOWN = 0x0204,
            /// <summary>
            /// 释放鼠标右键
            /// </summary>
            WM_RBUTTONUP = 0x0205,
            /// <summary>
            /// 双击鼠标右键
            /// </summary>
            WM_RBUTTONDBLCLK = 0x0206,
            /// <summary>
            /// 按下鼠标中键
            /// </summary>
            WM_MBUTTONDOWN = 0x0207,
            /// <summary>
            /// 释放鼠标中键
            /// </summary>
            WM_MBUTTONUP = 0x0208,
            /// <summary>
            /// 双击鼠标中键
            /// </summary>
            WM_MBUTTONDBLCLK = 0x0209,
            /// <summary>
            /// 当鼠标轮子转动时发送此消息个当前有焦点的控件 Buttons
            /// </summary>
            WM_MOUSEWHEEL = 0x020A,
            /// <summary>
            /// 
            /// </summary>
            WM_PARENTNOTIFY = 0x0210,
            /// <summary>
            /// 
            /// </summary>
            WM_ENTERMENULOOP = 0x0211,
            /// <summary>
            /// 
            /// </summary>
            WM_EXITMENULOOP = 0x0212,
            /// <summary>
            /// 
            /// </summary>
            WM_NEXTMENU = 0x0213,
            /// <summary>
            /// 
            /// </summary>
            WM_SIZING = 0x0214,
            /// <summary>
            /// 
            /// </summary>
            WM_CAPTURECHANGED = 0x0215,
            /// <summary>
            /// 
            /// </summary>
            WM_MOVING = 0x0216,
            /// <summary>
            /// 
            /// </summary>
            WM_DEVICECHANGE = 0x0219,
            /// <summary>
            /// 
            /// </summary>
            WM_MDICREATE = 0x0220,
            /// <summary>
            /// 
            /// </summary>
            WM_MDIDESTROY = 0x0221,
            /// <summary>
            /// 
            /// </summary>
            WM_MDIACTIVATE = 0x0222,
            /// <summary>
            /// 
            /// </summary>
            WM_MDIRESTORE = 0x0223,
            /// <summary>
            /// 
            /// </summary>
            WM_MDINEXT = 0x0224,
            /// <summary>
            /// 
            /// </summary>
            WM_MDIMAXIMIZE = 0x0225,
            /// <summary>
            /// 
            /// </summary>
            WM_MDITILE = 0x0226,
            /// <summary>
            /// 
            /// </summary>
            WM_MDICASCADE = 0x0227,
            /// <summary>
            /// 
            /// </summary>
            WM_MDIICONARRANGE = 0x0228,
            /// <summary>
            /// 
            /// </summary>
            WM_MDIGETACTIVE = 0x0229,
            /// <summary>
            /// 
            /// </summary>
            WM_MDISETMENU = 0x0230,
            /// <summary>
            /// 
            /// </summary>
            WM_ENTERSIZEMOVE = 0x0231,
            /// <summary>
            /// 
            /// </summary>
            WM_EXITSIZEMOVE = 0x0232,
            /// <summary>
            /// 
            /// </summary>
            WM_DROPFILES = 0x0233,
            /// <summary>
            /// 
            /// </summary>
            WM_MDIREFRESHMENU = 0x0234,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_SETCONTEXT = 0x0281,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_NOTIFY = 0x0282,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_CONTROL = 0x0283,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_COMPOSITIONFULL = 0x0284,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_SELECT = 0x0285,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_CHAR = 0x0286,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_REQUEST = 0x0288,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_KEYDOWN = 0x0290,
            /// <summary>
            /// 
            /// </summary>
            WM_IME_KEYUP = 0x0291,
            /// <summary>
            /// 
            /// </summary>
            WM_MOUSEHOVER = 0x02A1,
            /// <summary>
            /// 
            /// </summary>
            WM_MOUSELEAVE = 0x02A3,
            /// <summary>
            /// 
            /// </summary>
            WM_CUT = 0x0300,
            /// <summary>
            /// 
            /// </summary>
            WM_COPY = 0x0301,
            /// <summary>
            /// 
            /// </summary>
            WM_PASTE = 0x0302,
            /// <summary>
            /// 
            /// </summary>
            WM_CLEAR = 0x0303,
            /// <summary>
            /// 
            /// </summary>
            WM_UNDO = 0x0304,
            /// <summary>
            /// 
            /// </summary>
            WM_RENDERFORMAT = 0x0305,
            /// <summary>
            /// 
            /// </summary>
            WM_RENDERALLFORMATS = 0x0306,
            /// <summary>
            /// 
            /// </summary>
            WM_DESTROYCLIPBOARD = 0x0307,
            /// <summary>
            /// 
            /// </summary>
            WM_DRAWCLIPBOARD = 0x0308,
            /// <summary>
            /// 
            /// </summary>
            WM_PAINTCLIPBOARD = 0x0309,
            /// <summary>
            /// 
            /// </summary>
            WM_VSCROLLCLIPBOARD = 0x030A,
            /// <summary>
            /// 
            /// </summary>
            WM_SIZECLIPBOARD = 0x030B,
            /// <summary>
            /// 
            /// </summary>
            WM_ASKCBFORMATNAME = 0x030C,
            /// <summary>
            /// 
            /// </summary>
            WM_CHANGECBCHAIN = 0x030D,
            /// <summary>
            /// 
            /// </summary>
            WM_HSCROLLCLIPBOARD = 0x030E,
            /// <summary>
            /// 
            /// </summary>
            WM_QUERYNEWPALETTE = 0x030F,
            /// <summary>
            /// 
            /// </summary>
            WM_PALETTEISCHANGING = 0x0310,
            /// <summary>
            /// 
            /// </summary>
            WM_PALETTECHANGED = 0x0311,
            /// <summary>
            /// 
            /// </summary>
            WM_HOTKEY = 0x0312,
            /// <summary>
            /// 
            /// </summary>
            WM_PRINT = 0x0317,
            /// <summary>
            /// 
            /// </summary>
            WM_PRINTCLIENT = 0x0318,
            /// <summary>
            /// 
            /// </summary>
            WM_HANDHELDFIRST = 0x0358,
            /// <summary>
            /// 
            /// </summary>
            WM_HANDHELDLAST = 0x035F,
            /// <summary>
            /// 
            /// </summary>
            WM_AFXFIRST = 0x0360,
            /// <summary>
            /// 
            /// </summary>
            WM_AFXLAST = 0x037F,
            /// <summary>
            /// 
            /// </summary>
            WM_PENWINFIRST = 0x0380,
            /// <summary>
            /// 
            /// </summary>
            WM_PENWINLAST = 0x038F,
            /// <summary>
            /// 
            /// </summary>
            WM_APP = 0x8000,
            /// <summary>
            /// 
            /// </summary>
            WM_USER = 0x0400,
            /// <summary>
            /// 
            /// </summary>
            WM_REFLECT = WM_USER + 0x1c00
        }
        #endregion


        #region Window Styles

        public enum WindowStyles : uint
        {
            WS_OVERLAPPED = 0x00000000,
            WS_POPUP = 0x80000000,
            WS_CHILD = 0x40000000,
            WS_MINIMIZE = 0x20000000,
            WS_VISIBLE = 0x10000000,
            WS_DISABLED = 0x08000000,
            WS_CLIPSIBLINGS = 0x04000000,
            WS_CLIPCHILDREN = 0x02000000,
            WS_MAXIMIZE = 0x01000000,
            WS_CAPTION = 0x00C00000,
            WS_BORDER = 0x00800000,
            WS_DLGFRAME = 0x00400000,
            WS_VSCROLL = 0x00200000,
            WS_HSCROLL = 0x00100000,
            WS_SYSMENU = 0x00080000,
            WS_THICKFRAME = 0x00040000,
            WS_GROUP = 0x00020000,
            WS_TABSTOP = 0x00010000,
            WS_MINIMIZEBOX = 0x00020000,
            WS_MAXIMIZEBOX = 0x00010000,
            WS_TILED = 0x00000000,
            WS_ICONIC = 0x20000000,
            WS_SIZEBOX = 0x00040000,
            WS_POPUPWINDOW = 0x80880000,
            WS_OVERLAPPEDWINDOW = 0x00CF0000,
            WS_TILEDWINDOW = 0x00CF0000,
            WS_CHILDWINDOW = 0x40000000
        }
        #endregion
        /// <summary>
        /// 消息类型
        /// 作为SendMessage和PostMessage的参数
        /// </summary>
        public enum MsgType : uint
        {
            WM_KEYFIRST = 0x0100,

            //Msg参数常量值：
            /// <summary>
            /// 按下一个键
            /// </summary>
            WM_KEYDOWN = 0x0100,
            /// <summary>
            /// 释放一个键
            /// </summary>
            WM_KEYUP = 0x0101,
            /// <summary>
            /// 按下某键，并已发出WM_KEYDOWN， WM_KEYUP消息
            /// </summary>
            WM_CHAR = 0x102,
            /// <summary>
            /// 当用translatemessage函数翻译WM_KEYUP消息时发送此消息给拥有焦点的窗口
            /// </summary>
            WM_DEADCHAR = 0x103,
            /// <summary>
            /// 当用户按住ALT键同时按下其它键时提交此消息给拥有焦点的窗口
            /// </summary>
            WM_SYSKEYDOWN = 0x104,
            /// <summary>
            /// 当用户释放一个键同时ALT 键还按着时提交此消息给拥有焦点的窗口
            /// </summary>
            WM_SYSKEYUP = 0x105,
            /// <summary>
            /// 当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后提交此消息给拥有焦点的窗口
            /// </summary>
            WM_SYSCHAR = 0x106,
            /// <summary>
            /// 当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后发送此消息给拥有焦点的窗口
            /// </summary>
            WM_SYSDEADCHAR = 0x107,
            /// <summary>
            /// 在一个对话框程序被显示前发送此消息给它，通常用此消息初始化控件和执行其它任务
            /// </summary>
            WM_INITDIALOG = 0x110,
            /// <summary>
            /// 当用户选择一条菜单命令项或当某个控件发送一条消息给它的父窗口，一个快捷键被翻译
            /// </summary>
            WM_COMMAND = 0x111,
            /// <summary>
            /// 当用户选择窗口菜单的一条命令或//当用户选择最大化或最小化时那个窗口会收到此消息
            /// </summary>
            WM_SYSCOMMAND = 0x112,
            /// <summary>
            /// 发生了定时器事件
            /// </summary>
            WM_TIMER = 0x113,
            /// <summary>
            /// 当一个窗口标准水平滚动条产生一个滚动事件时发送此消息给那个窗口，也发送给拥有它的控件
            /// </summary>
            WM_HSCROLL = 0x114,
            /// <summary>
            /// 当一个窗口标准垂直滚动条产生一个滚动事件时发送此消息给那个窗口也，发送给拥有它的控件
            /// </summary>
            WM_VSCROLL = 0x115,
            /// <summary>
            /// 当一个菜单将要被激活时发送此消息，它发生在用户菜单条中的某项或按下某个菜单键，它允许程序在显示前更改菜单
            /// </summary>
            WM_INITMENU = 0x116,
            /// <summary>
            /// 当一个下拉菜单或子菜单将要被激活时发送此消息，它允许程序在它显示前更改菜单，而不要改变全部
            /// </summary>
            WM_INITMENUPOPUP = 0x117,
            /// <summary>
            /// 当用户选择一条菜单项时发送此消息给菜单的所有者（一般是窗口）
            /// </summary>
            WM_MENUSELECT = 0x11F,
            /// <summary>
            /// 当菜单已被激活用户按下了某个键（不同于加速键），发送此消息给菜单的所有者
            /// </summary>
            WM_MENUCHAR = 0x120,
            /// <summary>
            /// 当一个模态对话框或菜单进入空载状态时发送此消息给它的所有者，一个模态对话框或菜单进入空载状态就是在处理完一条或几条先前的消息后没有消息它的列队中等待
            /// </summary>
            WM_ENTERIDLE = 0x121,
            /// 在windows绘制消息框前发送此消息给消息框的所有者窗口，通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置消息框的文本和背景颜色
            /// </summary>
            WM_CTLCOLORMSGBOX = 0x132,
            /// <summary>
            /// 当一个编辑型控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色
            /// </summary>
            WM_CTLCOLOREDIT = 0x133,

            /// <summary>
            /// 当一个列表框控件将要被绘制前发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置列表框的文本和背景颜色
            /// </summary>
            WM_CTLCOLORLISTBOX = 0x134,
            /// <summary>
            /// 当一个按钮控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置按纽的文本和背景颜色
            /// </summary>
            WM_CTLCOLORBTN = 0x135,
            /// <summary>
            /// 当一个对话框控件将要被绘制前发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置对话框的文本背景颜色
            /// </summary>
            WM_CTLCOLORDLG = 0x136,
            /// <summary>
            /// 当一个滚动条控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置滚动条的背景颜色
            /// </summary>
            WM_CTLCOLORSCROLLBAR = 0x137,
            /// <summary>
            /// 当一个静态控件将要被绘制时发送此消息给它的父窗口通过响应这条消息，所有者窗口可以 通过使用给定的相关显示设备的句柄来设置静态控件的文本和背景颜色
            /// </summary>
            WM_CTLCOLORSTATIC = 0x138,
            /// <summary>
            /// 当鼠标轮子转动时发送此消息个当前有焦点的控件
            /// </summary>
            WM_MOUSEWHEEL = 0x20A,
            /// <summary>
            /// 双击鼠标中键
            /// </summary>
            WM_MBUTTONDBLCLK = 0x209,
            /// <summary>
            /// 释放鼠标中键
            /// </summary>
            WM_MBUTTONUP = 0x208,
            /// <summary>
            /// 移动鼠标时发生，同WM_MOUSEFIRST
            /// </summary>
            WM_MOUSEMOVE = 0x200,
            /// <summary>
            /// 按下鼠标左键
            /// </summary>
            WM_LBUTTONDOWN = 0x201,
            /// <summary>
            /// 释放鼠标左键
            /// </summary>
            WM_LBUTTONUP = 0x202,
            /// <summary>
            /// 双击鼠标左键
            /// </summary>
            WM_LBUTTONDBLCLK = 0x203,
            /// <summary>
            /// 按下鼠标右键
            /// </summary>
            WM_RBUTTONDOWN = 0x204,
            /// <summary>
            /// 释放鼠标右键
            /// </summary>
            WM_RBUTTONUP = 0x205,
            /// <summary>
            /// 双击鼠标右键
            /// </summary>
            WM_RBUTTONDBLCLK = 0x206,
            /// <summary>
            /// 按下鼠标中键
            /// </summary>
            WM_MBUTTONDOWN = 0x207,

            //WM_USER = 0x0400;
            //public static int MK_LBUTTON = 0x0001;
            //public static int MK_RBUTTON = 0x0002;
            //public static int MK_SHIFT = 0x0004;
            //public static int MK_CONTROL = 0x0008;
            //public static int MK_MBUTTON = 0x0010;
            //public static int MK_XBUTTON1 = 0x0020;
            //public static int MK_XBUTTON2 = 0x0040;
            /// <summary>
            /// 创建一个窗口
            /// </summary>
            WM_CREATE = 0x01,
            /// <summary>
            /// 当一个窗口被破坏时发送
            /// </summary>
            WM_DESTROY = 0x02,
            /// <summary>
            /// 移动一个窗口
            /// </summary>
            WM_MOVE = 0x03,
            /// <summary>
            /// 改变一个窗口的大小
            /// </summary>
            WM_SIZE = 0x05,
            /// <summary>
            /// 一个窗口被激活或失去激活状态
            /// </summary>
            WM_ACTIVATE = 0x06,
            /// <summary>
            /// 一个窗口获得焦点
            /// </summary>
            WM_SETFOCUS = 0x07,
            /// <summary>
            /// 一个窗口失去焦点
            /// </summary>
            WM_KILLFOCUS = 0x08,
            /// <summary>
            /// 一个窗口改变成Enable状态
            /// </summary>
            WM_ENABLE = 0x0A,
            /// <summary>
            /// 设置窗口是否能重画
            /// </summary>
            WM_SETREDRAW = 0x0B,
            /// <summary>
            /// 应用程序发送此消息来设置一个窗口的文本
            /// </summary>
            WM_SETTEXT = 0x0C,
            /// <summary>
            /// 应用程序发送此消息来复制对应窗口的文本到缓冲区
            /// </summary>
            WM_GETTEXT = 0x0D,
            /// <summary>
            /// 得到与一个窗口有关的文本的长度（不包含空字符）
            /// </summary>
            WM_GETTEXTLENGTH = 0x0E,
            /// <summary>
            /// 要求一个窗口重画自己
            /// </summary>
            WM_PAINT = 0x0F,
            /// <summary>
            /// 当一个窗口或应用程序要关闭时发送一个信号
            /// </summary>
            WM_CLOSE = 0x10,
            /// <summary>
            /// 当用户选择结束对话框或程序自己调用ExitWindows函数
            /// </summary>
            WM_QUERYENDSESSION = 0x11,
            /// <summary>
            /// 用来结束程序运行
            /// </summary>
            WM_QUIT = 0x12,
            /// <summary>
            /// 当用户窗口恢复以前的大小位置时，把此消息发送给某个图标
            /// </summary>
            WM_QUERYOPEN = 0x13,
            /// <summary>
            /// 当窗口背景必须被擦除时（例在窗口改变大小时）
            /// </summary>
            WM_ERASEBKGND = 0x14,
            /// <summary>
            /// 当系统颜色改变时，发送此消息给所有顶级窗口
            /// </summary>
            WM_SYSCOLORCHANGE = 0x15,
            /// <summary>
            /// 当系统进程发出WM_QUERYENDSESSION消息后，此消息发送给应用程序，通知它对话是否结束
            /// </summary>
            WM_ENDSESSION = 0x16,
            /// <summary>
            /// 当隐藏或显示窗口是发送此消息给这个窗口
            /// </summary>
            WM_SHOWWINDOW = 0x18,
            /// <summary>
            /// 发此消息给应用程序哪个窗口是激活的，哪个是非激活的
            /// </summary>
            WM_ACTIVATEAPP = 0x1C,
            /// <summary>
            /// 当系统的字体资源库变化时发送此消息给所有顶级窗口
            /// </summary>
            WM_FONTCHANGE = 0x1D,
            /// <summary>
            /// 当系统的时间变化时发送此消息给所有顶级窗口
            /// </summary>
            WM_TIMECHANGE = 0x1E,
            /// <summary>
            /// 发送此消息来取消某种正在进行的摸态（操作）
            /// </summary>
            WM_CANCELMODE = 0x1F,
            /// <summary>
            /// 如果鼠标引起光标在某个窗口中移动且鼠标输入没有被捕获时，就发消息给某个窗口
            /// </summary>
            WM_SETCURSOR = 0x20,
            /// <summary>
            /// 当光标在某个非激活的窗口中而用户正按着鼠标的某个键发送此消息给//当前窗口
            /// </summary>
            WM_MOUSEACTIVATE = 0x21,
            /// <summary>
            /// 发送此消息给MDI子窗口//当用户点击此窗口的标题栏，或//当窗口被激活，移动，改变大小
            /// </summary>
            WM_CHILDACTIVATE = 0x22,
            /// <summary>
            /// 此消息由基于计算机的训练程序发送，通过WH_JOURNALPALYBACK的hook程序分离出用户输入消息
            /// </summary>
            WM_QUEUESYNC = 0x23,
            /// <summary>
            /// 此消息发送给窗口当它将要改变大小或位置
            /// </summary>
            WM_GETMINMAXINFO = 0x24,
            /// <summary>
            /// 发送给最小化窗口当它图标将要被重画
            /// </summary>
            WM_PAINTICON = 0x26,
            /// <summary>
            /// 此消息发送给某个最小化窗口，仅//当它在画图标前它的背景必须被重画
            /// </summary>
            WM_ICONERASEBKGND = 0x27,
            /// <summary>
            /// 发送此消息给一个对话框程序去更改焦点位置
            /// </summary>
            WM_NEXTDLGCTL = 0x28,
            /// <summary>
            /// 每当打印管理列队增加或减少一条作业时发出此消息 
            /// </summary>
            WM_SPOOLERSTATUS = 0x2A,
            /// <summary>
            /// 当button，combobox，listbox，menu的可视外观改变时发送
            /// </summary>
            WM_DRAWITEM = 0x2B,
            /// <summary>
            /// 当button, combo box, list box, list view control, or menu item 被创建时
            /// </summary>
            WM_MEASUREITEM = 0x2C,
            /// <summary>
            /// 此消息有一个LBS_WANTKEYBOARDINPUT风格的发出给它的所有者来响应WM_KEYDOWN消息 
            /// </summary>
            WM_VKEYTOITEM = 0x2E,
            /// <summary>
            /// 此消息由一个LBS_WANTKEYBOARDINPUT风格的列表框发送给他的所有者来响应WM_CHAR消息 
            /// </summary>
            WM_CHARTOITEM = 0x2F,
            /// <summary>
            /// 当绘制文本时程序发送此消息得到控件要用的颜色
            /// </summary>
            WM_SETFONT = 0x30,
            /// <summary>
            /// 应用程序发送此消息得到当前控件绘制文本的字体
            /// </summary>
            WM_GETFONT = 0x31,
            /// <summary>
            /// 应用程序发送此消息让一个窗口与一个热键相关连 
            /// </summary>
            WM_SETHOTKEY = 0x32,
            /// <summary>
            /// 应用程序发送此消息来判断热键与某个窗口是否有关联
            /// </summary>
            WM_GETHOTKEY = 0x33,
            /// <summary>
            /// 此消息发送给最小化窗口，当此窗口将要被拖放而它的类中没有定义图标，应用程序能返回一个图标或光标的句柄，当用户拖放图标时系统显示这个图标或光标
            /// </summary>
            WM_QUERYDRAGICON = 0x37,
            /// <summary>
            /// 发送此消息来判定combobox或listbox新增加的项的相对位置
            /// </summary>
            WM_COMPAREITEM = 0x39,
            /// <summary>
            /// 显示内存已经很少了
            /// </summary>
            WM_COMPACTING = 0x41,
            /// <summary>
            /// 发送此消息给那个窗口的大小和位置将要被改变时，来调用setwindowpos函数或其它窗口管理函数
            /// </summary>
            WM_WINDOWPOSCHANGING = 0x46,
            /// <summary>
            /// 发送此消息给那个窗口的大小和位置已经被改变时，来调用setwindowpos函数或其它窗口管理函数
            /// </summary>
            WM_WINDOWPOSCHANGED = 0x47,
            /// <summary>
            /// 当系统将要进入暂停状态时发送此消息
            /// </summary>
            WM_POWER = 0x48,
            /// <summary>
            /// 当一个应用程序传递数据给另一个应用程序时发送此消息
            /// </summary>
            WM_COPYDATA = 0x4A,
            /// <summary>
            /// 当某个用户取消程序日志激活状态，提交此消息给程序
            /// </summary>
            WM_CANCELJOURNA = 0x4B,
            /// <summary>
            /// 当某个控件的某个事件已经发生或这个控件需要得到一些信息时，发送此消息给它的父窗口 
            /// </summary>
            WM_NOTIFY = 0x4E,
            /// <summary>
            /// 当用户选择某种输入语言，或输入语言的热键改变
            /// </summary>
            WM_INPUTLANGCHANGEREQUEST = 0x50,
            /// <summary>
            /// 当平台现场已经被改变后发送此消息给受影响的最顶级窗口
            /// </summary>
            WM_INPUTLANGCHANGE = 0x51,
            /// <summary>
            /// 当程序已经初始化windows帮助例程时发送此消息给应用程序
            /// </summary>
            WM_TCARD = 0x52,
            /// <summary>
            /// 此消息显示用户按下了F1，如果某个菜单是激活的，就发送此消息个此窗口关联的菜单，否则就发送给有焦点的窗口，如果//当前都没有焦点，就把此消息发送给//当前激活的窗口
            /// </summary>
            WM_HELP = 0x53,
            /// <summary>
            /// 当用户已经登入或退出后发送此消息给所有的窗口，//当用户登入或退出时系统更新用户的具体设置信息，在用户更新设置时系统马上发送此消息
            /// </summary>
            WM_USERCHANGED = 0x54,
            /// <summary>
            /// 公用控件，自定义控件和他们的父窗口通过此消息来判断控件是使用ANSI还是UNICODE结构
            /// </summary>
            WM_NOTIFYFORMAT = 0x55,
            /// <summary>
            /// 当用户某个窗口中点击了一下右键就发送此消息给这个窗口
            /// </summary>
            WM_CONTEXTMENU = 0x7B,
            /// <summary>
            /// 当调用SETWINDOWLONG函数将要改变一个或多个 窗口的风格时发送此消息给那个窗口
            /// </summary>
            WM_STYLECHANGING = 0x7C,
            /// <summary>
            /// 当调用SETWINDOWLONG函数一个或多个 窗口的风格后发送此消息给那个窗口
            /// </summary>
            WM_STYLECHANGED = 0x7D,
            /// <summary>
            /// 当显示器的分辨率改变后发送此消息给所有的窗口
            /// </summary>
            WM_DISPLAYCHANGE = 0x7E,
            /// <summary>
            /// 此消息发送给某个窗口来返回与某个窗口有关连的大图标或小图标的句柄
            /// </summary>
            WM_GETICON = 0x7F,
            /// <summary>
            /// 程序发送此消息让一个新的大图标或小图标与某个窗口关联
            /// </summary>
            WM_SETICON = 0x80,
            /// <summary>
            /// 当某个窗口第一次被创建时，此消息在WM_CREATE消息发送前发送
            /// </summary>
            WM_NCCREATE = 0x81,
            /// <summary>
            /// 此消息通知某个窗口，非客户区正在销毁 
            /// </summary>
            WM_NCDESTROY = 0x82,
            /// <summary>
            /// 当某个窗口的客户区域必须被核算时发送此消息
            /// </summary>
            WM_NCCALCSIZE = 0x83,
            /// <summary>
            /// 移动鼠标，按住或释放鼠标时发生
            /// </summary>
            WM_NCHITTEST = 0x84,
            /// <summary>
            /// 程序发送此消息给某个窗口当它（窗口）的框架必须被绘制时
            /// </summary>
            WM_NCPAINT = 0x85,
            /// <summary>
            /// 此消息发送给某个窗口仅当它的非客户区需要被改变来显示是激活还是非激活状态
            /// </summary>
            WM_NCACTIVATE = 0x86,
            /// <summary>
            /// 发送此消息给某个与对话框程序关联的控件，widdows控制方位键和TAB键使输入进入此控件通过应
            /// </summary>
            WM_GETDLGCODE = 0x87,
            /// <summary>
            /// 当光标在一个窗口的非客户区内移动时发送此消息给这个窗口 非客户区为：窗体的标题栏及窗 的边框体
            /// </summary>
            WM_NCMOUSEMOVE = 0xA0,
            /// <summary>
            /// 当光标在一个窗口的非客户区同时按下鼠标左键时提交此消息
            /// </summary>
            WM_NCLBUTTONDOWN = 0xA1,
            /// <summary>
            /// 当用户释放鼠标左键同时光标某个窗口在非客户区十发送此消息
            /// </summary>       
            WM_NCLBUTTONUP = 0xA2,
            /// <summary>
            /// 当用户双击鼠标左键同时光标某个窗口在非客户区十发送此消息
            /// </summary>
            WM_NCLBUTTONDBLCLK = 0xA3,
            /// <summary>
            /// 当用户按下鼠标右键同时光标又在窗口的非客户区时发送此消息
            /// </summary>
            WM_NCRBUTTONDOWN = 0xA4,
            /// <summary>
            /// 当用户释放鼠标右键同时光标又在窗口的非客户区时发送此消息
            /// </summary>
            WM_NCRBUTTONUP = 0xA5,
            /// <summary>
            /// 当用户双击鼠标右键同时光标某个窗口在非客户区十发送此消息
            /// </summary>
            WM_NCRBUTTONDBLCLK = 0xA6,
            /// <summary>
            /// 当用户按下鼠标中键同时光标又在窗口的非客户区时发送此消息
            /// </summary>
            WM_NCMBUTTONDOWN = 0xA7,
            /// <summary>
            /// 当用户释放鼠标中键同时光标又在窗口的非客户区时发送此消息
            /// </summary>
            WM_NCMBUTTONUP = 0xA8,
            /// <summary>
            /// 当用户双击鼠标中键同时光标又在窗口的非客户区时发送此消息
            /// </summary>
            WM_NCMBUTTONDBLCLK = 0xA9
        }

        #region Window Extended Styles

        public enum WindowExStyles
        {
            WS_EX_DLGMODALFRAME = 0x00000001,
            WS_EX_NOPARENTNOTIFY = 0x00000004,
            WS_EX_TOPMOST = 0x00000008,
            WS_EX_ACCEPTFILES = 0x00000010,
            WS_EX_TRANSPARENT = 0x00000020,
            WS_EX_MDICHILD = 0x00000040,
            WS_EX_TOOLWINDOW = 0x00000080,
            WS_EX_WINDOWEDGE = 0x00000100,
            WS_EX_CLIENTEDGE = 0x00000200,
            WS_EX_CONTEXTHELP = 0x00000400,
            WS_EX_RIGHT = 0x00001000,
            WS_EX_LEFT = 0x00000000,
            WS_EX_RTLREADING = 0x00002000,
            WS_EX_LTRREADING = 0x00000000,
            WS_EX_LEFTSCROLLBAR = 0x00004000,
            WS_EX_RIGHTSCROLLBAR = 0x00000000,
            WS_EX_CONTROLPARENT = 0x00010000,
            WS_EX_STATICEDGE = 0x00020000,
            WS_EX_APPWINDOW = 0x00040000,
            WS_EX_OVERLAPPEDWINDOW = 0x00000300,
            WS_EX_PALETTEWINDOW = 0x00000188,
            WS_EX_LAYERED = 0x00080000
        }
        #endregion


        #region ShowWindow Styles

        public enum ShowWindowStyles : short
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11
        }

        #endregion


        #region SetWindowPos Z Order

        public enum SetWindowPosZOrder
        {
            HWND_TOP = 0,
            HWND_BOTTOM = 1,
            HWND_TOPMOST = -1,
            HWND_NOTOPMOST = -2
        }
        #endregion


        #region SetWindowPosFlags

        public enum SetWindowPosFlags : uint
        {
            SWP_NOSIZE = 0x0001,
            SWP_NOMOVE = 0x0002,
            SWP_NOZORDER = 0x0004,
            SWP_NOREDRAW = 0x0008,
            SWP_NOACTIVATE = 0x0010,
            SWP_FRAMECHANGED = 0x0020,
            SWP_SHOWWINDOW = 0x0040,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,
            SWP_DRAWFRAME = 0x0020,
            SWP_NOREPOSITION = 0x0200,
            SWP_DEFERERASE = 0x2000,
            SWP_ASYNCWINDOWPOS = 0x4000
        }
        #endregion


        #region Virtual Keys

        public enum VirtualKeys
        {
            VK_LBUTTON = 0x01,
            VK_CANCEL = 0x03,
            VK_BACK = 0x08,
            VK_TAB = 0x09,
            VK_CLEAR = 0x0C,
            VK_RETURN = 0x0D,
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11,
            VK_MENU = 0x12,
            VK_CAPITAL = 0x14,
            VK_ESCAPE = 0x1B,
            VK_SPACE = 0x20,
            VK_PRIOR = 0x21,
            VK_NEXT = 0x22,
            VK_END = 0x23,
            VK_HOME = 0x24,
            VK_LEFT = 0x25,
            VK_UP = 0x26,
            VK_RIGHT = 0x27,
            VK_DOWN = 0x28,
            VK_SELECT = 0x29,
            VK_EXECUTE = 0x2B,
            VK_SNAPSHOT = 0x2C,
            VK_HELP = 0x2F,
            VK_0 = 0x30,
            VK_1 = 0x31,
            VK_2 = 0x32,
            VK_3 = 0x33,
            VK_4 = 0x34,
            VK_5 = 0x35,
            VK_6 = 0x36,
            VK_7 = 0x37,
            VK_8 = 0x38,
            VK_9 = 0x39,
            VK_A = 0x41,
            VK_B = 0x42,
            VK_C = 0x43,
            VK_D = 0x44,
            VK_E = 0x45,
            VK_F = 0x46,
            VK_G = 0x47,
            VK_H = 0x48,
            VK_I = 0x49,
            VK_J = 0x4A,
            VK_K = 0x4B,
            VK_L = 0x4C,
            VK_M = 0x4D,
            VK_N = 0x4E,
            VK_O = 0x4F,
            VK_P = 0x50,
            VK_Q = 0x51,
            VK_R = 0x52,
            VK_S = 0x53,
            VK_T = 0x54,
            VK_U = 0x55,
            VK_V = 0x56,
            VK_W = 0x57,
            VK_X = 0x58,
            VK_Y = 0x59,
            VK_Z = 0x5A,
            VK_NUMPAD0 = 0x60,
            VK_NUMPAD1 = 0x61,
            VK_NUMPAD2 = 0x62,
            VK_NUMPAD3 = 0x63,
            VK_NUMPAD4 = 0x64,
            VK_NUMPAD5 = 0x65,
            VK_NUMPAD6 = 0x66,
            VK_NUMPAD7 = 0x67,
            VK_NUMPAD8 = 0x68,
            VK_NUMPAD9 = 0x69,
            VK_MULTIPLY = 0x6A,
            VK_ADD = 0x6B,
            VK_SEPARATOR = 0x6C,
            VK_SUBTRACT = 0x6D,
            VK_DECIMAL = 0x6E,
            VK_DIVIDE = 0x6F,
            VK_ATTN = 0xF6,
            VK_CRSEL = 0xF7,
            VK_EXSEL = 0xF8,
            VK_EREOF = 0xF9,
            VK_PLAY = 0xFA,
            VK_ZOOM = 0xFB,
            VK_NONAME = 0xFC,
            VK_PA1 = 0xFD,
            VK_OEM_CLEAR = 0xFE,
            VK_LWIN = 0x5B,
            VK_RWIN = 0x5C,
            VK_APPS = 0x5D,
            VK_LSHIFT = 0xA0,
            VK_RSHIFT = 0xA1,
            VK_LCONTROL = 0xA2,
            VK_RCONTROL = 0xA3,
            VK_LMENU = 0xA4,
            VK_RMENU = 0xA5
        }
        #endregion


        #region PatBlt Types

        public enum PatBltTypes
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062
        }
        #endregion


        #region Clipboard Formats

        public enum ClipboardFormats : uint
        {
            CF_TEXT = 1,
            CF_BITMAP = 2,
            CF_METAFILEPICT = 3,
            CF_SYLK = 4,
            CF_DIF = 5,
            CF_TIFF = 6,
            CF_OEMTEXT = 7,
            CF_DIB = 8,
            CF_PALETTE = 9,
            CF_PENDATA = 10,
            CF_RIFF = 11,
            CF_WAVE = 12,
            CF_UNICODETEXT = 13,
            CF_ENHMETAFILE = 14,
            CF_HDROP = 15,
            CF_LOCALE = 16,
            CF_MAX = 17,
            CF_OWNERDISPLAY = 0x0080,
            CF_DSPTEXT = 0x0081,
            CF_DSPBITMAP = 0x0082,
            CF_DSPMETAFILEPICT = 0x0083,
            CF_DSPENHMETAFILE = 0x008E,
            CF_PRIVATEFIRST = 0x0200,
            CF_PRIVATELAST = 0x02FF,
            CF_GDIOBJFIRST = 0x0300,
            CF_GDIOBJLAST = 0x03FF
        }
        #endregion


        #region Common Controls Initialization flags

        public enum CommonControlInitFlags
        {
            ICC_LISTVIEW_CLASSES = 0x00000001,
            ICC_TREEVIEW_CLASSES = 0x00000002,
            ICC_BAR_CLASSES = 0x00000004,
            ICC_TAB_CLASSES = 0x00000008,
            ICC_UPDOWN_CLASS = 0x00000010,
            ICC_PROGRESS_CLASS = 0x00000020,
            ICC_HOTKEY_CLASS = 0x00000040,
            ICC_ANIMATE_CLASS = 0x00000080,
            ICC_WIN95_CLASSES = 0x000000FF,
            ICC_DATE_CLASSES = 0x00000100,
            ICC_USEREX_CLASSES = 0x00000200,
            ICC_COOL_CLASSES = 0x00000400,
            ICC_INTERNET_CLASSES = 0x00000800,
            ICC_PAGESCROLLER_CLASS = 0x00001000,
            ICC_NATIVEFNTCTL_CLASS = 0x00002000
        }
        #endregion


        #region Common Controls Styles

        public enum CommonControlStyles
        {
            CCS_TOP = 0x00000001,
            CCS_NOMOVEY = 0x00000002,
            CCS_BOTTOM = 0x00000003,
            CCS_NORESIZE = 0x00000004,
            CCS_NOPARENTALIGN = 0x00000008,
            CCS_ADJUSTABLE = 0x00000020,
            CCS_NODIVIDER = 0x00000040,
            CCS_VERT = 0x00000080,
            CCS_LEFT = (CCS_VERT | CCS_TOP),
            CCS_RIGHT = (CCS_VERT | CCS_BOTTOM),
            CCS_NOMOVEX = (CCS_VERT | CCS_NOMOVEY)
        }
        #endregion


        #region ToolBar Styles

        public enum ToolBarStyles
        {
            TBSTYLE_BUTTON = 0x0000,
            TBSTYLE_SEP = 0x0001,
            TBSTYLE_CHECK = 0x0002,
            TBSTYLE_GROUP = 0x0004,
            TBSTYLE_CHECKGROUP = (TBSTYLE_GROUP | TBSTYLE_CHECK),
            TBSTYLE_DROPDOWN = 0x0008,
            TBSTYLE_AUTOSIZE = 0x0010,
            TBSTYLE_NOPREFIX = 0x0020,
            TBSTYLE_TOOLTIPS = 0x0100,
            TBSTYLE_WRAPABLE = 0x0200,
            TBSTYLE_ALTDRAG = 0x0400,
            TBSTYLE_FLAT = 0x0800,
            TBSTYLE_LIST = 0x1000,
            TBSTYLE_CUSTOMERASE = 0x2000,
            TBSTYLE_REGISTERDROP = 0x4000,
            TBSTYLE_TRANSPARENT = 0x8000,
            TBSTYLE_EX_DRAWDDARROWS = 0x00000001
        }
        #endregion


        #region ToolBar Ex Styles

        public enum ToolBarExStyles
        {
            TBSTYLE_EX_DRAWDDARROWS = 0x1,
            TBSTYLE_EX_HIDECLIPPEDBUTTONS = 0x10,
            TBSTYLE_EX_DOUBLEBUFFER = 0x80
        }
        #endregion


        #region ToolBar Messages

        public enum ToolBarMessages
        {
            WM_USER = 0x0400,
            TB_ENABLEBUTTON = (WM_USER + 1),
            TB_CHECKBUTTON = (WM_USER + 2),
            TB_PRESSBUTTON = (WM_USER + 3),
            TB_HIDEBUTTON = (WM_USER + 4),
            TB_INDETERMINATE = (WM_USER + 5),
            TB_MARKBUTTON = (WM_USER + 6),
            TB_ISBUTTONENABLED = (WM_USER + 9),
            TB_ISBUTTONCHECKED = (WM_USER + 10),
            TB_ISBUTTONPRESSED = (WM_USER + 11),
            TB_ISBUTTONHIDDEN = (WM_USER + 12),
            TB_ISBUTTONINDETERMINATE = (WM_USER + 13),
            TB_ISBUTTONHIGHLIGHTED = (WM_USER + 14),
            TB_SETSTATE = (WM_USER + 17),
            TB_GETSTATE = (WM_USER + 18),
            TB_ADDBITMAP = (WM_USER + 19),
            TB_ADDBUTTONSA = (WM_USER + 20),
            TB_INSERTBUTTONA = (WM_USER + 21),
            TB_ADDBUTTONS = (WM_USER + 20),
            TB_INSERTBUTTON = (WM_USER + 21),
            TB_DELETEBUTTON = (WM_USER + 22),
            TB_GETBUTTON = (WM_USER + 23),
            TB_BUTTONCOUNT = (WM_USER + 24),
            TB_COMMANDTOINDEX = (WM_USER + 25),
            TB_SAVERESTOREA = (WM_USER + 26),
            TB_CUSTOMIZE = (WM_USER + 27),
            TB_ADDSTRINGA = (WM_USER + 28),
            TB_GETITEMRECT = (WM_USER + 29),
            TB_BUTTONSTRUCTSIZE = (WM_USER + 30),
            TB_SETBUTTONSIZE = (WM_USER + 31),
            TB_SETBITMAPSIZE = (WM_USER + 32),
            TB_AUTOSIZE = (WM_USER + 33),
            TB_GETTOOLTIPS = (WM_USER + 35),
            TB_SETTOOLTIPS = (WM_USER + 36),
            TB_SETPARENT = (WM_USER + 37),
            TB_SETROWS = (WM_USER + 39),
            TB_GETROWS = (WM_USER + 40),
            TB_GETBITMAPFLAGS = (WM_USER + 41),
            TB_SETCMDID = (WM_USER + 42),
            TB_CHANGEBITMAP = (WM_USER + 43),
            TB_GETBITMAP = (WM_USER + 44),
            TB_GETBUTTONTEXTA = (WM_USER + 45),
            TB_GETBUTTONTEXTW = (WM_USER + 75),
            TB_REPLACEBITMAP = (WM_USER + 46),
            TB_SETINDENT = (WM_USER + 47),
            TB_SETIMAGELIST = (WM_USER + 48),
            TB_GETIMAGELIST = (WM_USER + 49),
            TB_LOADIMAGES = (WM_USER + 50),
            TB_GETRECT = (WM_USER + 51),
            TB_SETHOTIMAGELIST = (WM_USER + 52),
            TB_GETHOTIMAGELIST = (WM_USER + 53),
            TB_SETDISABLEDIMAGELIST = (WM_USER + 54),
            TB_GETDISABLEDIMAGELIST = (WM_USER + 55),
            TB_SETSTYLE = (WM_USER + 56),
            TB_GETSTYLE = (WM_USER + 57),
            TB_GETBUTTONSIZE = (WM_USER + 58),
            TB_SETBUTTONWIDTH = (WM_USER + 59),
            TB_SETMAXTEXTROWS = (WM_USER + 60),
            TB_GETTEXTROWS = (WM_USER + 61),
            TB_GETOBJECT = (WM_USER + 62),
            TB_GETBUTTONINFOW = (WM_USER + 63),
            TB_SETBUTTONINFOW = (WM_USER + 64),
            TB_GETBUTTONINFOA = (WM_USER + 65),
            TB_SETBUTTONINFOA = (WM_USER + 66),
            TB_INSERTBUTTONW = (WM_USER + 67),
            TB_ADDBUTTONSW = (WM_USER + 68),
            TB_HITTEST = (WM_USER + 69),
            TB_SETDRAWTEXTFLAGS = (WM_USER + 70),
            TB_GETHOTITEM = (WM_USER + 71),
            TB_SETHOTITEM = (WM_USER + 72),
            TB_SETANCHORHIGHLIGHT = (WM_USER + 73),
            TB_GETANCHORHIGHLIGHT = (WM_USER + 74),
            TB_SAVERESTOREW = (WM_USER + 76),
            TB_ADDSTRINGW = (WM_USER + 77),
            TB_MAPACCELERATORA = (WM_USER + 78),
            TB_GETINSERTMARK = (WM_USER + 79),
            TB_SETINSERTMARK = (WM_USER + 80),
            TB_INSERTMARKHITTEST = (WM_USER + 81),
            TB_MOVEBUTTON = (WM_USER + 82),
            TB_GETMAXSIZE = (WM_USER + 83),
            TB_SETEXTENDEDSTYLE = (WM_USER + 84),
            TB_GETEXTENDEDSTYLE = (WM_USER + 85),
            TB_GETPADDING = (WM_USER + 86),
            TB_SETPADDING = (WM_USER + 87),
            TB_SETINSERTMARKCOLOR = (WM_USER + 88),
            TB_GETINSERTMARKCOLOR = (WM_USER + 89)
        }
        #endregion


        #region ToolBar Notifications

        public enum ToolBarNotifications
        {
            TTN_NEEDTEXTA = ((0 - 520) - 0),
            TTN_NEEDTEXTW = ((0 - 520) - 10),
            TBN_QUERYINSERT = ((0 - 700) - 6),
            TBN_DROPDOWN = ((0 - 700) - 10),
            TBN_HOTITEMCHANGE = ((0 - 700) - 13)
        }
        #endregion


        #region Reflected Messages

        public enum ReflectedMessages
        {
            OCM__BASE = (WinMsg.WM_USER + 0x1c00),
            OCM_COMMAND = (OCM__BASE + WinMsg.WM_COMMAND),
            OCM_CTLCOLORBTN = (OCM__BASE + WinMsg.WM_CTLCOLORBTN),
            OCM_CTLCOLOREDIT = (OCM__BASE + WinMsg.WM_CTLCOLOREDIT),
            OCM_CTLCOLORDLG = (OCM__BASE + WinMsg.WM_CTLCOLORDLG),
            OCM_CTLCOLORLISTBOX = (OCM__BASE + WinMsg.WM_CTLCOLORLISTBOX),
            OCM_CTLCOLORWinMsgBOX = (OCM__BASE + WinMsg.WM_CTLCOLORWinMsgBOX),
            OCM_CTLCOLORSCROLLBAR = (OCM__BASE + WinMsg.WM_CTLCOLORSCROLLBAR),
            OCM_CTLCOLORSTATIC = (OCM__BASE + WinMsg.WM_CTLCOLORSTATIC),
            OCM_CTLCOLOR = (OCM__BASE + WinMsg.WM_CTLCOLOR),
            OCM_DRAWITEM = (OCM__BASE + WinMsg.WM_DRAWITEM),
            OCM_MEASUREITEM = (OCM__BASE + WinMsg.WM_MEASUREITEM),
            OCM_DELETEITEM = (OCM__BASE + WinMsg.WM_DELETEITEM),
            OCM_VKEYTOITEM = (OCM__BASE + WinMsg.WM_VKEYTOITEM),
            OCM_CHARTOITEM = (OCM__BASE + WinMsg.WM_CHARTOITEM),
            OCM_COMPAREITEM = (OCM__BASE + WinMsg.WM_COMPAREITEM),
            OCM_HSCROLL = (OCM__BASE + WinMsg.WM_HSCROLL),
            OCM_VSCROLL = (OCM__BASE + WinMsg.WM_VSCROLL),
            OCM_PARENTNOTIFY = (OCM__BASE + WinMsg.WM_PARENTNOTIFY),
            OCM_NOTIFY = (OCM__BASE + WinMsg.WM_NOTIFY)
        }
        #endregion


        #region Notification Messages

        public enum NotificationMessages
        {
            NM_FIRST = (0 - 0),
            NM_CUSTOMDRAW = (NM_FIRST - 12),
            NM_NCHITTEST = (NM_FIRST - 14)
        }
        #endregion


        #region ToolTip Flags

        public enum ToolTipFlags
        {
            TTF_CENTERTIP = 0x0002,
            TTF_RTLREADING = 0x0004,
            TTF_SUBCLASS = 0x0010,
            TTF_TRACK = 0x0020,
            TTF_ABSOLUTE = 0x0080,
            TTF_TRANSPARENT = 0x0100,
            TTF_DI_SETITEM = 0x8000
        }
        #endregion


        #region Custom Draw Return Flags

        public enum CustomDrawReturnFlags
        {
            CDRF_DODEFAULT = 0x00000000,
            CDRF_NEWFONT = 0x00000002,
            CDRF_SKIPDEFAULT = 0x00000004,
            CDRF_NOTIFYPOSTPAINT = 0x00000010,
            CDRF_NOTIFYITEMDRAW = 0x00000020,
            CDRF_NOTIFYSUBITEMDRAW = 0x00000020,
            CDRF_NOTIFYPOSTERASE = 0x00000040
        }
        #endregion


        #region Custom Draw Item State Flags

        public enum CustomDrawItemStateFlags
        {
            CDIS_SELECTED = 0x0001,
            CDIS_GRAYED = 0x0002,
            CDIS_DISABLED = 0x0004,
            CDIS_CHECKED = 0x0008,
            CDIS_FOCUS = 0x0010,
            CDIS_DEFAULT = 0x0020,
            CDIS_HOT = 0x0040,
            CDIS_MARKED = 0x0080,
            CDIS_INDETERMINATE = 0x0100
        }
        #endregion


        #region Custom Draw Draw State Flags

        public enum CustomDrawDrawStateFlags
        {
            CDDS_PREPAINT = 0x00000001,
            CDDS_POSTPAINT = 0x00000002,
            CDDS_PREERASE = 0x00000003,
            CDDS_POSTERASE = 0x00000004,
            CDDS_ITEM = 0x00010000,
            CDDS_ITEMPREPAINT = (CDDS_ITEM | CDDS_PREPAINT),
            CDDS_ITEMPOSTPAINT = (CDDS_ITEM | CDDS_POSTPAINT),
            CDDS_ITEMPREERASE = (CDDS_ITEM | CDDS_PREERASE),
            CDDS_ITEMPOSTERASE = (CDDS_ITEM | CDDS_POSTERASE),
            CDDS_SUBITEM = 0x00020000
        }
        #endregion


        #region Toolbar button info flags

        public enum ToolBarButtonInfoFlags
        {
            TBIF_IMAGE = 0x00000001,
            TBIF_TEXT = 0x00000002,
            TBIF_STATE = 0x00000004,
            TBIF_STYLE = 0x00000008,
            TBIF_LPARAM = 0x00000010,
            TBIF_COMMAND = 0x00000020,
            TBIF_SIZE = 0x00000040,
            I_IMAGECALLBACK = -1,
            I_IMAGENONE = -2
        }
        #endregion


        #region Toolbar button styles

        public enum ToolBarButtonStyles
        {
            TBSTYLE_BUTTON = 0x0000,
            TBSTYLE_SEP = 0x0001,
            TBSTYLE_CHECK = 0x0002,
            TBSTYLE_GROUP = 0x0004,
            TBSTYLE_CHECKGROUP = (TBSTYLE_GROUP | TBSTYLE_CHECK),
            TBSTYLE_DROPDOWN = 0x0008,
            TBSTYLE_AUTOSIZE = 0x0010,
            TBSTYLE_NOPREFIX = 0x0020,
            TBSTYLE_TOOLTIPS = 0x0100,
            TBSTYLE_WRAPABLE = 0x0200,
            TBSTYLE_ALTDRAG = 0x0400,
            TBSTYLE_FLAT = 0x0800,
            TBSTYLE_LIST = 0x1000,
            TBSTYLE_CUSTOMERASE = 0x2000,
            TBSTYLE_REGISTERDROP = 0x4000,
            TBSTYLE_TRANSPARENT = 0x8000,
            TBSTYLE_EX_DRAWDDARROWS = 0x00000001
        }
        #endregion


        #region Toolbar button state

        public enum ToolBarButtonStates
        {
            TBSTATE_CHECKED = 0x01,
            TBSTATE_PRESSED = 0x02,
            TBSTATE_ENABLED = 0x04,
            TBSTATE_HIDDEN = 0x08,
            TBSTATE_INDETERMINATE = 0x10,
            TBSTATE_WRAP = 0x20,
            TBSTATE_ELLIPSES = 0x40,
            TBSTATE_MARKED = 0x80
        }
        #endregion


        #region Windows Hook Codes

        public enum WindowsHookCodes
        {
            WH_MSGFILTER = (-1),
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        #endregion


        #region Mouse Hook Filters

        public enum MouseHookFilters
        {
            MSGF_DIALOGBOX = 0,
            MSGF_MESSAGEBOX = 1,
            MSGF_MENU = 2,
            MSGF_SCROLLBAR = 5,
            MSGF_NEXTWINDOW = 6
        }

        #endregion


        #region Draw Text format flags

        public enum DrawTextFormatFlags
        {
            DT_TOP = 0x00000000,
            DT_LEFT = 0x00000000,
            DT_CENTER = 0x00000001,
            DT_RIGHT = 0x00000002,
            DT_VCENTER = 0x00000004,
            DT_BOTTOM = 0x00000008,
            DT_WORDBREAK = 0x00000010,
            DT_SINGLELINE = 0x00000020,
            DT_EXPANDTABS = 0x00000040,
            DT_TABSTOP = 0x00000080,
            DT_NOCLIP = 0x00000100,
            DT_EXTERNALLEADING = 0x00000200,
            DT_CALCRECT = 0x00000400,
            DT_NOPREFIX = 0x00000800,
            DT_INTERNAL = 0x00001000,
            DT_EDITCONTROL = 0x00002000,
            DT_PATH_ELLIPSIS = 0x00004000,
            DT_END_ELLIPSIS = 0x00008000,
            DT_MODIFYSTRING = 0x00010000,
            DT_RTLREADING = 0x00020000,
            DT_WORD_ELLIPSIS = 0x00040000
        }

        #endregion


        #region Rebar Styles

        public enum RebarStyles
        {
            RBS_TOOLTIPS = 0x0100,
            RBS_VARHEIGHT = 0x0200,
            RBS_BANDBORDERS = 0x0400,
            RBS_FIXEDORDER = 0x0800,
            RBS_REGISTERDROP = 0x1000,
            RBS_AUTOSIZE = 0x2000,
            RBS_VERTICALGRIPPER = 0x4000,
            RBS_DBLCLKTOGGLE = 0x8000,
        }
        #endregion


        #region Rebar Notifications

        public enum RebarNotifications
        {
            RBN_FIRST = (0 - 831),
            RBN_HEIGHTCHANGE = (RBN_FIRST - 0),
            RBN_GETOBJECT = (RBN_FIRST - 1),
            RBN_LAYOUTCHANGED = (RBN_FIRST - 2),
            RBN_AUTOSIZE = (RBN_FIRST - 3),
            RBN_BEGINDRAG = (RBN_FIRST - 4),
            RBN_ENDDRAG = (RBN_FIRST - 5),
            RBN_DELETINGBAND = (RBN_FIRST - 6),
            RBN_DELETEDBAND = (RBN_FIRST - 7),
            RBN_CHILDSIZE = (RBN_FIRST - 8),
            RBN_CHEVRONPUSHED = (RBN_FIRST - 10)
        }
        #endregion


        #region Rebar Messages

        public enum RebarMessages
        {
            CCM_FIRST = 0x2000,
            WM_USER = 0x0400,
            RB_INSERTBANDA = (WM_USER + 1),
            RB_DELETEBAND = (WM_USER + 2),
            RB_GETBARINFO = (WM_USER + 3),
            RB_SETBARINFO = (WM_USER + 4),
            RB_GETBANDINFO = (WM_USER + 5),
            RB_SETBANDINFOA = (WM_USER + 6),
            RB_SETPARENT = (WM_USER + 7),
            RB_HITTEST = (WM_USER + 8),
            RB_GETRECT = (WM_USER + 9),
            RB_INSERTBANDW = (WM_USER + 10),
            RB_SETBANDINFOW = (WM_USER + 11),
            RB_GETBANDCOUNT = (WM_USER + 12),
            RB_GETROWCOUNT = (WM_USER + 13),
            RB_GETROWHEIGHT = (WM_USER + 14),
            RB_IDTOINDEX = (WM_USER + 16),
            RB_GETTOOLTIPS = (WM_USER + 17),
            RB_SETTOOLTIPS = (WM_USER + 18),
            RB_SETBKCOLOR = (WM_USER + 19),
            RB_GETBKCOLOR = (WM_USER + 20),
            RB_SETTEXTCOLOR = (WM_USER + 21),
            RB_GETTEXTCOLOR = (WM_USER + 22),
            RB_SIZETORECT = (WM_USER + 23),
            RB_SETCOLORSCHEME = (CCM_FIRST + 2),
            RB_GETCOLORSCHEME = (CCM_FIRST + 3),
            RB_BEGINDRAG = (WM_USER + 24),
            RB_ENDDRAG = (WM_USER + 25),
            RB_DRAGMOVE = (WM_USER + 26),
            RB_GETBARHEIGHT = (WM_USER + 27),
            RB_GETBANDINFOW = (WM_USER + 28),
            RB_GETBANDINFOA = (WM_USER + 29),
            RB_MINIMIZEBAND = (WM_USER + 30),
            RB_MAXIMIZEBAND = (WM_USER + 31),
            RB_GETDROPTARGET = (CCM_FIRST + 4),
            RB_GETBANDBORDERS = (WM_USER + 34),
            RB_SHOWBAND = (WM_USER + 35),
            RB_SETPALETTE = (WM_USER + 37),
            RB_GETPALETTE = (WM_USER + 38),
            RB_MOVEBAND = (WM_USER + 39),
            RB_SETUNICODEFORMAT = (CCM_FIRST + 5),
            RB_GETUNICODEFORMAT = (CCM_FIRST + 6)
        }
        #endregion


        #region Rebar Info Mask

        public enum RebarInfoMask
        {
            RBBIM_STYLE = 0x00000001,
            RBBIM_COLORS = 0x00000002,
            RBBIM_TEXT = 0x00000004,
            RBBIM_IMAGE = 0x00000008,
            RBBIM_CHILD = 0x00000010,
            RBBIM_CHILDSIZE = 0x00000020,
            RBBIM_SIZE = 0x00000040,
            RBBIM_BACKGROUND = 0x00000080,
            RBBIM_ID = 0x00000100,
            RBBIM_IDEALSIZE = 0x00000200,
            RBBIM_LPARAM = 0x00000400,
            BBIM_HEADERSIZE = 0x00000800
        }
        #endregion


        #region Rebar Styles

        public enum RebarStylesEx
        {
            RBBS_BREAK = 0x1,
            RBBS_CHILDEDGE = 0x4,
            RBBS_FIXEDBMP = 0x20,
            RBBS_GRIPPERALWAYS = 0x80,
            RBBS_USECHEVRON = 0x200
        }
        #endregion


        #region Object types

        public enum ObjectTypes
        {
            OBJ_PEN = 1,
            OBJ_BRUSH = 2,
            OBJ_DC = 3,
            OBJ_METADC = 4,
            OBJ_PAL = 5,
            OBJ_FONT = 6,
            OBJ_BITMAP = 7,
            OBJ_REGION = 8,
            OBJ_METAFILE = 9,
            OBJ_MEMDC = 10,
            OBJ_EXTPEN = 11,
            OBJ_ENHMETADC = 12,
            OBJ_ENHMETAFILE = 13
        }
        #endregion


        #region WM_MENUCHAR return values

        public enum MenuCharReturnValues
        {
            MNC_IGNORE = 0,
            MNC_CLOSE = 1,
            MNC_EXECUTE = 2,
            MNC_SELECT = 3
        }
        #endregion


        #region Background Mode

        public enum BackgroundMode
        {
            TRANSPARENT = 1,
            OPAQUE = 2
        }
        #endregion


        #region ListView Messages

        public enum ListViewMessages
        {
            LVM_FIRST = 0x1000,
            LVM_GETSUBITEMRECT = (LVM_FIRST + 56),
            LVM_GETITEMSTATE = (LVM_FIRST + 44),
            LVM_GETITEMTEXTW = (LVM_FIRST + 115)
        }
        #endregion


        #region Header Control Messages

        public enum HeaderControlMessages : int
        {
            HDM_FIRST = 0x1200,
            HDM_GETITEMRECT = (HDM_FIRST + 7),
            HDM_HITTEST = (HDM_FIRST + 6),
            HDM_SETIMAGELIST = (HDM_FIRST + 8),
            HDM_GETITEMW = (HDM_FIRST + 11),
            HDM_ORDERTOINDEX = (HDM_FIRST + 15)
        }
        #endregion


        #region Header Control Notifications

        public enum HeaderControlNotifications
        {
            HDN_FIRST = (0 - 300),
            HDN_BEGINTRACKW = (HDN_FIRST - 26),
            HDN_ENDTRACKW = (HDN_FIRST - 27),
            HDN_ITEMCLICKW = (HDN_FIRST - 22),
        }
        #endregion


        #region Header Control HitTest Flags

        public enum HeaderControlHitTestFlags : uint
        {
            HHT_NOWHERE = 0x0001,
            HHT_ONHEADER = 0x0002,
            HHT_ONDIVIDER = 0x0004,
            HHT_ONDIVOPEN = 0x0008,
            HHT_ABOVE = 0x0100,
            HHT_BELOW = 0x0200,
            HHT_TORIGHT = 0x0400,
            HHT_TOLEFT = 0x0800
        }
        #endregion


        #region List View sub item portion

        public enum SubItemPortion
        {
            LVIR_BOUNDS = 0,
            LVIR_ICON = 1,
            LVIR_LABEL = 2
        }
        #endregion


        #region Cursor Type

        public enum CursorType : uint
        {
            IDC_ARROW = 32512U,
            IDC_IBEAM = 32513U,
            IDC_WAIT = 32514U,
            IDC_CROSS = 32515U,
            IDC_UPARROW = 32516U,
            IDC_SIZE = 32640U,
            IDC_ICON = 32641U,
            IDC_SIZENWSE = 32642U,
            IDC_SIZENESW = 32643U,
            IDC_SIZEWE = 32644U,
            IDC_SIZENS = 32645U,
            IDC_SIZEALL = 32646U,
            IDC_NO = 32648U,
            IDC_HAND = 32649U,
            IDC_APPSTARTING = 32650U,
            IDC_HELP = 32651U
        }
        #endregion


        #region Tracker Event Flags

        public enum TrackerEventFlags : uint
        {
            TME_HOVER = 0x00000001,
            TME_LEAVE = 0x00000002,
            TME_QUERY = 0x40000000,
            TME_CANCEL = 0x80000000
        }
        #endregion


        #region Mouse Activate Flags

        public enum MouseActivateFlags
        {
            MA_ACTIVATE = 1,
            MA_ACTIVATEANDEAT = 2,
            MA_NOACTIVATE = 3,
            MA_NOACTIVATEANDEAT = 4
        }
        #endregion


        #region Dialog Codes

        public enum DialogCodes
        {
            DLGC_WANTARROWS = 0x0001,
            DLGC_WANTTAB = 0x0002,
            DLGC_WANTALLKEYS = 0x0004,
            DLGC_WANTMESSAGE = 0x0004,
            DLGC_HASSETSEL = 0x0008,
            DLGC_DEFPUSHBUTTON = 0x0010,
            DLGC_UNDEFPUSHBUTTON = 0x0020,
            DLGC_RADIOBUTTON = 0x0040,
            DLGC_WANTCHARS = 0x0080,
            DLGC_STATIC = 0x0100,
            DLGC_BUTTON = 0x2000
        }
        #endregion


        #region Update Layered Windows Flags

        public enum UpdateLayeredWindowsFlags
        {
            ULW_COLORKEY = 0x00000001,
            ULW_ALPHA = 0x00000002,
            ULW_OPAQUE = 0x00000004
        }
        #endregion


        #region Alpha Flags

        public enum AlphaFlags : byte
        {
            AC_SRC_OVER = 0x00,
            AC_SRC_ALPHA = 0x01
        }
        #endregion


        #region ComboBox messages

        public enum ComboBoxMessages
        {
            CB_GETDROPPEDSTATE = 0x0157
        }
        #endregion


        #region SetWindowLong indexes

        public enum SetWindowLongOffsets
        {
            GWL_WNDPROC = (-4),
            GWL_HINSTANCE = (-6),
            GWL_HWNDPARENT = (-8),
            GWL_STYLE = (-16),
            GWL_EXSTYLE = (-20),
            GWL_USERDATA = (-21),
            GWL_ID = (-12)
        }
        #endregion


        #region TreeView Messages

        public enum TreeViewMessages
        {
            TV_FIRST = 0x1100,
            TVM_GETITEMRECT = (TV_FIRST + 4),
            TVM_GETITEMW = (TV_FIRST + 62)
        }
        #endregion


        #region TreeViewItem Flags

        public enum TreeViewItemFlags
        {
            TVIF_TEXT = 0x0001,
            TVIF_IMAGE = 0x0002,
            TVIF_PARAM = 0x0004,
            TVIF_STATE = 0x0008,
            TVIF_HANDLE = 0x0010,
            TVIF_SELECTEDIMAGE = 0x0020,
            TVIF_CHILDREN = 0x0040,
            TVIF_INTEGRAL = 0x0080
        }
        #endregion


        #region ListViewItem flags

        public enum ListViewItemFlags
        {
            LVIF_TEXT = 0x0001,
            LVIF_IMAGE = 0x0002,
            LVIF_PARAM = 0x0004,
            LVIF_STATE = 0x0008,
            LVIF_INDENT = 0x0010,
            LVIF_NORECOMPUTE = 0x0800
        }
        #endregion


        #region HeaderItem flags

        public enum HeaderItemFlags
        {
            HDI_WIDTH = 0x0001,
            HDI_HEIGHT = HDI_WIDTH,
            HDI_TEXT = 0x0002,
            HDI_FORMAT = 0x0004,
            HDI_LPARAM = 0x0008,
            HDI_BITMAP = 0x0010,
            HDI_IMAGE = 0x0020,
            HDI_DI_SETITEM = 0x0040,
            HDI_ORDER = 0x0080
        }
        #endregion


        #region GetDCExFlags

        public enum GetDCExFlags
        {
            DCX_WINDOW = 0x00000001,
            DCX_CACHE = 0x00000002,
            DCX_NORESETATTRS = 0x00000004,
            DCX_CLIPCHILDREN = 0x00000008,
            DCX_CLIPSIBLINGS = 0x00000010,
            DCX_PARENTCLIP = 0x00000020,
            DCX_EXCLUDERGN = 0x00000040,
            DCX_INTERSECTRGN = 0x00000080,
            DCX_EXCLUDEUPDATE = 0x00000100,
            DCX_INTERSECTUPDATE = 0x00000200,
            DCX_LOCKWINDOWUPDATE = 0x00000400,
            DCX_VALIDATE = 0x00200000
        }
        #endregion


        #region HitTest

        public enum HitTest
        {
            HTERROR = (-2),
            HTTRANSPARENT = (-1),
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTSIZE = HTGROWBOX,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTREDUCE = HTMINBUTTON,
            HTZOOM = HTMAXBUTTON,
            HTSIZEFIRST = HTLEFT,
            HTSIZELAST = HTBOTTOMRIGHT,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21
        }
        #endregion


        #region ActivateFlags

        public enum ActivateState
        {
            WA_INACTIVE = 0,
            WA_ACTIVE = 1,
            WA_CLICKACTIVE = 2
        }
        #endregion


        #region StrechModeFlags

        public enum StrechModeFlags
        {
            BLACKONWHITE = 1,
            WHITEONBLACK = 2,
            COLORONCOLOR = 3,
            HALFTONE = 4,
            MAXSTRETCHBLTMODE = 4
        }
        #endregion


        #region ScrollBarFlags

        public enum ScrollBarFlags
        {
            SBS_HORZ = 0x0000,
            SBS_VERT = 0x0001,
            SBS_TOPALIGN = 0x0002,
            SBS_LEFTALIGN = 0x0002,
            SBS_BOTTOMALIGN = 0x0004,
            SBS_RIGHTALIGN = 0x0004,
            SBS_SIZEBOXTOPLEFTALIGN = 0x0002,
            SBS_SIZEBOXBOTTOMRIGHTALIGN = 0x0004,
            SBS_SIZEBOX = 0x0008,
            SBS_SIZEGRIP = 0x0010
        }
        #endregion


        #region System Metrics Codes

        public enum SystemMetricsCodes
        {
            SM_CXSCREEN = 0,
            SM_CYSCREEN = 1,
            SM_CXVSCROLL = 2,
            SM_CYHSCROLL = 3,
            SM_CYCAPTION = 4,
            SM_CXBORDER = 5,
            SM_CYBORDER = 6,
            SM_CXDLGFRAME = 7,
            SM_CYDLGFRAME = 8,
            SM_CYVTHUMB = 9,
            SM_CXHTHUMB = 10,
            SM_CXICON = 11,
            SM_CYICON = 12,
            SM_CXCURSOR = 13,
            SM_CYCURSOR = 14,
            SM_CYMENU = 15,
            SM_CXFULLSCREEN = 16,
            SM_CYFULLSCREEN = 17,
            SM_CYKANJIWINDOW = 18,
            SM_MOUSEPRESENT = 19,
            SM_CYVSCROLL = 20,
            SM_CXHSCROLL = 21,
            SM_DEBUG = 22,
            SM_SWAPBUTTON = 23,
            SM_RESERVED1 = 24,
            SM_RESERVED2 = 25,
            SM_RESERVED3 = 26,
            SM_RESERVED4 = 27,
            SM_CXMIN = 28,
            SM_CYMIN = 29,
            SM_CXSIZE = 30,
            SM_CYSIZE = 31,
            SM_CXFRAME = 32,
            SM_CYFRAME = 33,
            SM_CXMINTRACK = 34,
            SM_CYMINTRACK = 35,
            SM_CXDOUBLECLK = 36,
            SM_CYDOUBLECLK = 37,
            SM_CXICONSPACING = 38,
            SM_CYICONSPACING = 39,
            SM_MENUDROPALIGNMENT = 40,
            SM_PENWINDOWS = 41,
            SM_DBCSENABLED = 42,
            SM_CMOUSEBUTTONS = 43,
            SM_CXFIXEDFRAME = SM_CXDLGFRAME,
            SM_CYFIXEDFRAME = SM_CYDLGFRAME,
            SM_CXSIZEFRAME = SM_CXFRAME,
            SM_CYSIZEFRAME = SM_CYFRAME,
            SM_SECURE = 44,
            SM_CXEDGE = 45,
            SM_CYEDGE = 46,
            SM_CXMINSPACING = 47,
            SM_CYMINSPACING = 48,
            SM_CXSMICON = 49,
            SM_CYSMICON = 50,
            SM_CYSMCAPTION = 51,
            SM_CXSMSIZE = 52,
            SM_CYSMSIZE = 53,
            SM_CXMENUSIZE = 54,
            SM_CYMENUSIZE = 55,
            SM_ARRANGE = 56,
            SM_CXMINIMIZED = 57,
            SM_CYMINIMIZED = 58,
            SM_CXMAXTRACK = 59,
            SM_CYMAXTRACK = 60,
            SM_CXMAXIMIZED = 61,
            SM_CYMAXIMIZED = 62,
            SM_NETWORK = 63,
            SM_CLEANBOOT = 67,
            SM_CXDRAG = 68,
            SM_CYDRAG = 69,
            SM_SHOWSOUNDS = 70,
            SM_CXMENUCHECK = 71,
            SM_CYMENUCHECK = 72,
            SM_SLOWMACHINE = 73,
            SM_MIDEASTENABLED = 74,
            SM_MOUSEWHEELPRESENT = 75,
            SM_XVIRTUALSCREEN = 76,
            SM_YVIRTUALSCREEN = 77,
            SM_CXVIRTUALSCREEN = 78,
            SM_CYVIRTUALSCREEN = 79,
            SM_CMONITORS = 80,
            SM_SAMEDISPLAYFORMAT = 81,
            SM_CMETRICS = 83
        }
        #endregion


        #region ScrollBarTypes

        public enum ScrollBarTypes
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }
        #endregion


        #region SrollBarInfoFlags

        public enum ScrollBarInfoFlags
        {
            SIF_RANGE = 0x0001,
            SIF_PAGE = 0x0002,
            SIF_POS = 0x0004,
            SIF_DISABLENOSCROLL = 0x0008,
            SIF_TRACKPOS = 0x0010,
            SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS)
        }
        #endregion


        #region Enable ScrollBar flags

        public enum EnableScrollBarFlags
        {
            ESB_ENABLE_BOTH = 0x0000,
            ESB_DISABLE_BOTH = 0x0003,
            ESB_DISABLE_LEFT = 0x0001,
            ESB_DISABLE_RIGHT = 0x0002,
            ESB_DISABLE_UP = 0x0001,
            ESB_DISABLE_DOWN = 0x0002,
            ESB_DISABLE_LTUP = ESB_DISABLE_LEFT,
            ESB_DISABLE_RTDN = ESB_DISABLE_RIGHT
        }
        #endregion


        #region Scroll Requests

        public enum ScrollBarRequests
        {
            SB_LINEUP = 0,
            SB_LINELEFT = 0,
            SB_LINEDOWN = 1,
            SB_LINERIGHT = 1,
            SB_PAGEUP = 2,
            SB_PAGELEFT = 2,
            SB_PAGEDOWN = 3,
            SB_PAGERIGHT = 3,
            SB_THUMBPOSITION = 4,
            SB_THUMBTRACK = 5,
            SB_TOP = 6,
            SB_LEFT = 6,
            SB_BOTTOM = 7,
            SB_RIGHT = 7,
            SB_ENDSCROLL = 8
        }
        #endregion


        #region SrollWindowEx flags

        public enum ScrollWindowExFlags
        {
            SW_SCROLLCHILDREN = 0x0001,
            SW_INVALIDATE = 0x0002,
            SW_ERASE = 0x0004,
            SW_SMOOTHSCROLL = 0x0010
        }
        #endregion


        #region ImageListFlags

        public enum ImageListFlags
        {
            ILC_MASK = 0x0001,
            ILC_COLOR = 0x0000,
            ILC_COLORDDB = 0x00FE,
            ILC_COLOR4 = 0x0004,
            ILC_COLOR8 = 0x0008,
            ILC_COLOR16 = 0x0010,
            ILC_COLOR24 = 0x0018,
            ILC_COLOR32 = 0x0020,
            ILC_PALETTE = 0x0800
        }
        #endregion


        #region List View Notifications

        public enum ListViewNotifications
        {
            LVN_FIRST = (0 - 100),
            LVN_GETDISPINFOW = (LVN_FIRST - 77),
            LVN_SETDISPINFOA = (LVN_FIRST - 51)
        }
        #endregion
    }
}
