using Help.WinFormsHelp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinFrom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //HookHelp.ProcessHook ph = new HookHelp.ProcessHook();
            //ph.Install(actHook_KeyDown);
        }
        private void actHook_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private Help.WinFormsHelp.HookHelp.KeyBoardHook hook;
        /// <summary>
        /// 创建进程键盘钩子
        /// </summary>
        protected void CreateProcessHook()
        {
            if (hook != null)
            {
                hook.UnInstall();
            }
            hook = new HookHelp.ProcessHook();
            if (hook.Install(ClientProcessKeyHandle))
            {
                hook.HookKey = this.GetHashCode();
            }
        }

        //客户端传给钩子的监听方法。
        private void ClientProcessKeyHandle(int hookKey, Keys key, out bool handle)
        {
            handle = false;

            if (hookKey == hook.HookKey)
            {
                OnClientProcessKeyHandle(key, out handle);
            }
            return;
        }

        /// <summary>
        /// 子类重写键盘钩子处理方法（系统中存在多个窗体，可将该代码放入到窗体基类中，子类只需重写该方法即可。）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handle"></param>
        protected virtual void OnClientProcessKeyHandle(Keys key, out bool handle)
        {

            handle = false;
            //截获消息并进行处理。
            if ((int)key == (int)Keys.F2)//保存，
            {
                handle = true;
            }
        }
    }
}
