﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ExtendHelp
{
    public class Rtf
    {
        public string RTF
        {
            get
            {
                return _rtfHead + RTFData + "}";
            }
        }
        private string _rtfHead;
        public string RTFData { get; private set; }
        public string Text { get; private set; }
        private Dictionary<Color, int> colors;
        private Dictionary<string, int>fonts;
        private string colorStr;
        private string fontStr;
        public Rtf() : this(string.Empty)
        {

        }
        public string GetColorRTF(Color color)
        {
            if (colors.ContainsKey(color))
            {
                return @"\cf" + colors[color];
            }
            var index = colors.Count + 1;
            colors.Add(color, index);
            colorStr += $"\\red{color.R}\\green{color.G}\\blue{color.B};";
            return @"\cf" + index;
        }
        public string GetFontRTF(string name)
        {
            if (fonts.ContainsKey(name))
            {
                return @"\f" + fonts[name];
            }
            var index = fonts.Count + 1;
            fonts.Add(name, index);
            UpdateFont();
            return @"\f" + index;
        }
        public Rtf(string str)
        {
            colors = new Dictionary<Color, int> {
                {Color.Black,0 },
                {Color.Red,1 },
                {Color.Blue,2 },
                {Color.Yellow,3 },
            };
            colorStr = "\\red255\\green0\\blue0;\\red0\\green0\\blue255;\\red255\\green255\\blue0;";
            fonts = new Dictionary<string, int>
            {
                { "宋体",0},
                { "黑体",1},
                { "微软雅黑",2},
            };
            UpdateFont();
            UpdateHead();
            Text = str;
            RTFData = Str2RTF(str?.Replace("\r\n", @"\par"));
        }
        private void UpdateFont()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var kv in fonts)
            {
                builder.Append($"{{\\f{kv.Value}\\fnil\\fcharset134 {Str2RTF(kv.Key)};}}");
            }
            fontStr = builder.ToString();
        }
        private void UpdateHead()
        {
            _rtfHead = $"{{\\rtf1\\ansi\\deff0\\nouicompat{{\\fonttbl{fontStr}}}{{\\colortbl ;{colorStr}}}{{\\*\\generator Riched20 10.0.15063}}\\viewkind4\\uc1\\pard\\sl276\\slmult1\\f0\\fs22\\lang2052";
        }

        public string GetColorSizeRTF(string str, Color color, int fontSize = 12, string fontName = "微软雅黑")
        {
            string tempS = Str2RTF(str?.Replace("\r\n", @"\par"));
            string colorS = GetColorRTF(color);
            return $@"{GetFontRTF(fontName)}{colorS}\fs{fontSize * 2} {tempS}";
        }
        public Rtf AddColorText(string str, Color color, int fontSize = 12)
        {
            var calue = GetColorSizeRTF(str, color, fontSize);
            RTFData += calue;
            Text += str;
            return this;
        }
        private string GetLink(string str, string label,string fontHead)
        {
            return $"{{{fontHead}{{\\field{{\\*\\fldinst{{HYPERLINK \"{Str2RTF(label)}\"}}{{\\fldrslt{{\\ul\\cf2\\cf2\\ul{Str2RTF(label)}}}";
        }
        public Rtf AddLink(string str, string label)
        {
            //{\f2\fs28{\field{\*\fldinst{HYPERLINK "\\l "}}{\fldrslt{\ul\cf2\cf2\ul\'b2\'e2\'ca\'d4\'b3\'ac\'c1\'b4\'bd\'d3}}}}
            var calue = GetLink(str, label, string.Empty);

            RTFData += calue;
            Text += str;
            return this;
        }
        public Rtf AddColorText(string str)
        {
            return AddColorText(str, Color.Black);
        }
        public static Rtf GetRtf(string str, params object[] ss)
        {
            return RtfExtend.AddRtf(new Rtf(), str, ss);
        }

        public Rtf AddRtf(Rtf rh)
        {
            RTFData += rh.RTFData;
            Text += rh.Text;
            return this;
        }
        public Rtf Clert()
        {
            RTFData = string.Empty;
            Text = string.Empty;
            return this;
        }
        /// <summary>
        /// string转化为RTF类型
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        private string Str2RTF(string strs)
        {
            string tmpStr = "", tmpStr2 = "", strToRTF = "";
            int lstrLen = strs.Length;
            if (lstrLen == 0)
                return "";
            foreach (char c in strs)
            {
                tmpStr = c.ToString();
                int tmpAsc = (int)c;
                if (tmpAsc > 126)//转换非ASCII范围的文本为RTF格式
                {
                    tmpStr = CharTo16(c);
                    if (tmpStr.Length == 1)
                        tmpStr = @"\'0" + tmpStr;//转换hex值小于2位的特殊控制符号
                    else if (tmpStr.Length == 2)
                        tmpStr = @"\'" + tmpStr;//转换hex值等于2位的特殊符号
                    else
                    {
                        tmpStr2 = tmpStr.Substring(tmpStr.Length - 2, 2); //Right(tmpStr, 2);
                        tmpStr = tmpStr.Substring(0, 2); //Left(tmpStr, 2);
                        tmpStr = @"\'" + tmpStr + @"\'" + tmpStr2;// '转换hex值等于4位的非英文字符内码
                    }
                }
                strToRTF += tmpStr;
            }
            return strToRTF;
        }

        /// <summary>
        /// Char转16进制字符
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        private string CharTo16(char ch)
        {
            System.Text.Encoding chs = CodePagesEncodingProvider.Instance.GetEncoding("gb2312");
            //System.Text.Encoding chs = System.Text.Encoding.UTF8;
            byte[] bytes = chs.GetBytes(ch.ToString());
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += string.Format("{0:X2}", bytes[i]);
            }
            return str.ToLower();
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
