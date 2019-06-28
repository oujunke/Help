using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Help.Model
{
    public  class Delegates
    {
        /// <summary>
        /// 钩子的回调函数
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        /// <summary>
        /// 客户端处理钩子回调的键盘处理事件
        /// </summary>
        /// <param name="hookKey">钩子的唯一标志</param>
        /// <param name="key">按下的键</param>
        /// <param name="handle">客户端是否处理了这个值</param>
        public delegate void ProcessKeyHandle(int hookKey, Keys key, out bool handle);
    }
}
