using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Help.WinFormsHelp
{
    public class RtbHelp
    {
        public static RichTextBox Rtb;
        public static readonly ColorRtb Green = new ColorRtb { Color = Color.FromArgb(0x00ff00) };
        public static readonly ColorRtb Red = new ColorRtb { Color = Color.Red };
        public static readonly ColorRtb Yellow = new ColorRtb { Color = Color.Yellow };
        public class ColorRtb
        {
            public Color Color;

            public void Line(string value)
            {
                if (Rtb == null) return;
                try
                {
                    Rtb.Invoke(new MethodInvoker(delegate () //初始化
                    {
                        LineFun(value);
                    }));
                }
                catch
                {

                }
            }

            private void LineFun(string value)
            {
                if (Rtb.Lines.Length > 1000)
                {
                    Rtb.Select(0, Rtb.Lines[0].Length);
                    Rtb.SelectedText = string.Empty;
                }
                Rtb.Select(Rtb.TextLength, 0);
                Rtb.SelectionColor = Color;
                Rtb.SelectedText = value + "\r\n";
            }
        }
    }
}
