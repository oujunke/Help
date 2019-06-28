using Help.WinFormsHelp.WinApi.Win32Api;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Help.ScreenshotHelp.WinScreenshotHelp
{
    public class WinApiSCreenshotHelp
    {
        public static Bitmap PrtWindow(IntPtr hWnd)
        {
            IntPtr hscrdc = User32Api.GetWindowDC(hWnd);
            Rectangle rect=Rectangle.Empty;
            User32Api.GetWindowRect(hWnd, ref rect);
            IntPtr hbitmap = Gdi32Help.CreateCompatibleBitmap(hscrdc, rect.Width - rect.Left, rect.Height - rect.Top);
            IntPtr hmemdc = Gdi32Help.CreateCompatibleDC(hscrdc);
            Gdi32Help.SelectObject(hmemdc, hbitmap);
            User32Api.PrintWindow(hWnd, hmemdc, 0);
            Bitmap bmp = Bitmap.FromHbitmap(hbitmap);
            Gdi32Help.DeleteDC(hscrdc);
            Gdi32Help.DeleteDC(hmemdc);
            return bmp;
        }
        public static Rectangle GetPtrRectangle(IntPtr hWnd)
        {
            Rectangle rect = Rectangle.Empty;
            User32Api.GetWindowRect(hWnd, ref rect);
            return new Rectangle(rect.Location,new Size(rect.Width - rect.Left, rect.Height - rect.Top));
        }
    }
}
