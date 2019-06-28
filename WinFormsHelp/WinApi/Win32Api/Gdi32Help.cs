using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Help.WinFormsHelp.WinApi.Win32Api
{
   public  class Gdi32Help
    {
        public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
        /// <summary>
        /// 对指定的源设备环境区域中的像素进行位块（bit_block）转换，以传送到目标设备环境
        /// </summary>
        /// <param name="hObject"></param>
        /// <param name="nXDest"></param>
        /// <param name="nYDest"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="hObjectSource"></param>
        /// <param name="nXSrc"></param>
        /// <param name="nYSrc"></param>
        /// <param name="dwRop"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
int nWidth, int nHeight, IntPtr hObjectSource,
int nXSrc, int nYSrc, int dwRop);
        /// <summary>
        /// 该函数创建与指定的设备环境相关的设备兼容的位图。
        /// </summary>
        /// <param name="hDC">设备环境句柄</param>
        /// <param name="nWidth">指定位图的宽度，单位为像素</param>
        /// <param name="nHeight">指定位图的高度，单位为像素</param>
        /// <returns>如果函数执行成功，那么返回值是位图的句柄；如果函数执行失败，那么返回值为NULL。若想获取更多错误信息，请调用GetLastError</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
        /// <summary>
        /// 该函数创建一个与指定设备兼容的内存设备上下文环境（DC）。通过GetDc()获取的HDC直接与相关设备沟通，而本函数创建的DC，则是与内存中的一个表面相关联
        /// </summary>
        /// <param name="hDC">现有设备上下文环境的句柄，如果该句柄为NULL，该函数创建一个与应用程序的当前显示器兼容的内存设备上下文环境。</param>
        /// <returns>如果成功，则返回内存设备上下文环境的句柄；如果失败，则返回值为NULL。</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(string driver, string device, IntPtr res1, IntPtr res2);

        /// <summary>
        /// 该函数删除指定的设备上下文环境（Dc）。
        /// </summary>
        /// <param name="hDC">设备上下文环境的句柄。</param>
        /// <returns>成功，返回非零值；失败，返回零。</returns>
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);
        /// <summary>
        /// 该函数删除一个逻辑笔、画笔、字体、位图、区域或者调色板，释放所有与该对象有关的系统资源，在对象被删除之后，指定的句柄也就失效了
        /// </summary>
        /// <param name="hObject">逻辑笔、画笔、字体、位图、区域或者调色板的句柄</param>
        /// <returns>成功，返回非零值；如果指定的句柄无效或者它已被选入设备上下文环境，则返回值为零</returns>
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        /// <summary>
        /// 该函数选择一对象到指定的设备上下文环境中，该新对象替换先前的相同类型的对象。
        /// </summary>
        /// <param name="hDC">设备上下文环境的句柄。</param>
        /// <param name="hObject">被选择的对象的句柄，该指定对象必须由如下的函数创建。</param>
        /// <returns>如果选择对象不是区域并且函数执行成功，那么返回值是被取代的对象的句柄；如果选择对象是区域并且函数执行成功，返回如下一值:</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

    }
}
