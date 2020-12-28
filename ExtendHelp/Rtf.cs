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
        public Rtf() : this(string.Empty)
        {

        }
        public Rtf(string str)
        {
            _rtfHead = @"{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil\fcharset134 \'cb\'ce\'cc\'e5;}}{\colortbl ;\red255\green0\blue0;\red0\green0\blue255;\red255\green255\blue0;}{\*\generator Riched20 10.0.15063}\viewkind4\uc1\pard\sl276\slmult1\f0\fs22\lang2052";
            Text = str;
            RTFData = Str2RTF(str?.Replace("\r\n", @"\par"));
        }

        public string GetColorSizeRTF(string str, RtfColor color, int fontSize = 12)
        {
            string tempS = Str2RTF(str?.Replace("\r\n", @"\par"));
            string colorS = string.Empty;
            if (color == RtfColor.Red)
                colorS = @"\cf1";
            else if (color == RtfColor.Blue)
                colorS = @"\cf2";
            else if (color == RtfColor.Yellow)
                colorS = @"\cf3";
            else
                colorS = @"\cf0";
            return $@"{colorS}\fs{fontSize * 2} {tempS}";
        }
        public static string GetColorRTF(RtfColor color)
        {
            string colorS = string.Empty;
            if (color == RtfColor.Red)
                colorS = @"\cf1";
            else if (color == RtfColor.Blue)
                colorS = @"\cf2";
            else if (color == RtfColor.Yellow)
                colorS = @"\cf3";
            else
                colorS = @"\cf0";
            return $"{colorS}";
        }
        public Rtf AddColorText(string str, RtfColor color, int fontSize = 12)
        {
            var calue = GetColorSizeRTF(str, color, fontSize);
            RTFData += calue;
            Text += str;
            return this;
        }
        public Rtf AddColorText(string str)
        {
            return AddColorText(str, 0);
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
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding("gb2312");
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
        public enum RtfColor
        {
            Black,
            Red,
            Blue,
            Yellow
        }
    }
}
