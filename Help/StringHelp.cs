using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Help.StringHelp
{
    public static class StringHelp
    {
        #region 把传过来的字符串按指定的格式分割
        /// <summary>
        ///把传过来的字符串按指定的格式分割，str为原字符串，RowDivisionStr为行分割符，ListDivisionStr为列分割符
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="RowDivisionStr">行分割符</param>
        /// <param name="ListDivisionStr">列分割符</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetSaveData(this String str, string RowDivisionStr, string ListDivisionStr)
        {
            Dictionary<string, string> di = new Dictionary<string, string>();
            string s = string.Empty;
            int last = -1, next = 0, num = 0;
            for (int i = 0; i < str.Length; i++)
            {
                next = str.IndexOf(ListDivisionStr, last + 1);
                if (next <= 0) return di;
                int j = last <= 0 ? 0 : last + ListDivisionStr.Length;
                s = str.Substring(j, next - j);
                num = s.IndexOf(RowDivisionStr);
                if (num <= 0) continue;
                di.Add(s.Substring(0, num), s.Substring(num + RowDivisionStr.Length));
                last = next;
            }
            return di;
        }
        /// <summary>
        /// 截取指定分割符后的数据，不返回之前的数据
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ListDivisionStr"></param>
        /// <returns></returns>
        public static string GetSaveData(this String str, string ListDivisionStr)
        {
            return str.Substring(str.IndexOf(ListDivisionStr));
        }
        /// <summary>
        /// 截取指定分割符后的数据，是否返回所有数据
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ListDivisionStr"></param>
        /// <param name="IfAgo"></param>
        /// <returns></returns>
        public static string[] GetSaveData(this String str, string ListDivisionStr, bool IfAgo)
        {
            string[] strs = null;
            if (IfAgo)
                strs = new string[] { str.Substring(0, str.IndexOf(ListDivisionStr)), str.Substring(str.IndexOf(ListDivisionStr)) };
            else
                strs = new string[] { str.Substring(0, str.IndexOf(ListDivisionStr)) };
            return strs;
        }
        #endregion
        #region 把传过来的数据按指定的格式组装
        /// <summary>
        /// 把传过来的数据按指定的格式组装，di为原数据，RowDivisionStr为行分割符，ListDivisionStr为列分割符
        /// </summary>
        /// <param name="di">原数据</param>
        /// <param name="RowDivisionStr">行分割符</param>
        /// <param name="ListDivisionStr">列分割符</param>
        /// <returns></returns>
        public static string GetSaveString(this Dictionary<string, string> di, string RowDivisionStr, string ListDivisionStr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kvp in di)
            {
                sb.Append(kvp.Key + ListDivisionStr + kvp.Value + RowDivisionStr);
            }
            return sb.ToString();
        }
        #endregion
        #region 替换掉指定的字符串
        /// <summary>
        /// 替换掉指定的字符串,oddStr为需要替换的字符串，newStr是替换成的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="oddStr"></param>
        /// <param name="newStr"></param>
        /// <returns></returns>
        public static string ReplaceString(this string str, string oddStr, string newStr)
        {
            return str.Replace(oddStr, newStr);
        }
        /// <summary>
        /// oddStrAndNewStr为Dictionary集合，key值为需要替换的字符串，value是替换成的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="oddStrAndNewStr"></param>
        /// <returns></returns>
        public static string ReplaceString(this string str, Dictionary<string, string> oddStrAndNewStr)
        {
            string s = str;
            foreach (KeyValuePair<string, string> k in oddStrAndNewStr)
            {
                s = s.Replace(k.Key, k.Value);
            }
            return s;
        }
        #endregion
        #region 分割字符串
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str">需要分割的字符串</param>
        /// <param name="separator">分割字符串</param>
        /// <param name="b">是否返回空字符串，默认为不返回</param>
        /// <returns></returns>
        public static string[] Split(this string str, string separator, bool b = false)
        {
            string[] strs = { separator };
            if (b)
                return str.Split(strs, StringSplitOptions.None);
            else
                return str.Split(strs, StringSplitOptions.RemoveEmptyEntries);

        }
        #endregion
        #region 加密字符串
        public delegate string Operation(Double num1, Double num2);
        public static string SplitStr = "%<%;%>%";
        /// <summary>
        /// 通过把字符串转成小数，再与密码进行一定的运算(默认为（+—*）)加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Password"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        public static string SimplenessEncryptionCharNumSwapReplace(this string str, int Password, Operation op = null)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (char ch in str)
            {
                if (op == null)
                {
                    switch (i)
                    {
                        case 0:
                            sb.Append(((int)ch + Password) + SplitStr);
                            break;
                        case 1:
                            sb.Append(((int)ch - Password) + SplitStr);
                            break;
                        case 2:
                            sb.Append((int)ch * Password + SplitStr);
                            break;
                    }
                    i++;
                    if (i >= 3)
                        i = 0;
                }
                else
                {

                    sb = new StringBuilder(op((int)ch, Password));
                }

            }
            return sb.ToString();
        }
        /// <summary>
        /// 通过把字符串转成小数，再与密码进行一定的运算(默认为（+—/）)解密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Password"></param>
        /// <param name="op"></param>
        /// <returns></returns>
        public static string SimplenessRemoveCharNumSwapReplace(this string str, int Password, Operation op = null)
        {
            StringBuilder sb = new StringBuilder();
            string[] ss = str.Split(SplitStr);
            int i = 0;
            foreach (string ch in ss)
            {
                if (ch == "") continue;
                if (op == null)
                {
                    switch (i)
                    {
                        case 0:
                            sb.Append((char)(Convert.ToInt32(ch) - Password));
                            break;
                        case 1:
                            sb.Append(Convert.ToChar(Convert.ToInt32(ch) + Password));
                            break;
                        case 2:
                            sb.Append(Convert.ToChar(Convert.ToInt32(ch) / Password));
                            break;

                    }
                    i++;
                    if (i >= 3)
                        i = 0;
                }
                else
                {
                    sb = new StringBuilder(op(Convert.ToInt64(ch), Password));
                }
            }
            return sb.ToString();
        }
        #endregion
        #region 字符串扩展
        #region 个人习惯扩展
        /// <summary>
        /// 删除字符串中指定的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="RemoveString"></param>
        /// <returns></returns>
        public static string Remove(this string str, string RemoveString)
        {
            return str.Replace(RemoveString, string.Empty);
        }
        #endregion
        #region 字符串扩展对文件的操作
        /// <summary>
        /// 从文件中读取字符串
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="e">编码</param>
        /// <returns></returns>
        public static string FileReadText(this string FilePath, Encoding e = null)
        {
            using (StreamReader sr = e == null ? new StreamReader(FilePath) : new StreamReader(FilePath, e))
            {
                return sr.ReadToEnd();
            }
        }
        /// 从文件中读取字符串
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="e">编码</param>
        /// <returns></returns>
        public static void FileWriterText(this string FilePath, string str, bool isAppend = true, Encoding e = null)
        {
            using (StreamWriter sr = e == null ? new StreamWriter(FilePath, isAppend) : new StreamWriter(FilePath, isAppend, e))
            {
                sr.Write(str);
            }
        }
        /// <summary>
        /// 文件复制
        /// </summary>
        /// <param name="SourceFilePath"></param>
        /// <param name="NewFilePath"></param>
        public static void FileCopy(this string SourceFilePath, string NewFilePath)
        {
            File.Copy(SourceFilePath, NewFilePath, true);
        }
        /// <summary>
        /// 目录复制
        /// </summary>
        /// <param name="SourceDirectoryPath"></param>
        /// <param name="NewDirectoryPath"></param>
        public static void DirectoryCopy(this string SourceDirectoryPath, string NewDirectoryPath)
        {
            string temp = string.Empty;
            if (!Directory.Exists(NewDirectoryPath)) Directory.CreateDirectory(NewDirectoryPath);
            foreach (string di in Directory.GetDirectories(SourceDirectoryPath))
            {
                temp = di.Remove(SourceDirectoryPath);
                di.DirectoryCopy(NewDirectoryPath + temp);
            }
            foreach (string di in Directory.GetFiles(SourceDirectoryPath))
            {
                temp = di.Remove(SourceDirectoryPath);
                di.FileCopy(NewDirectoryPath + temp);
            }
        }
        #endregion
        #endregion
    }
}
