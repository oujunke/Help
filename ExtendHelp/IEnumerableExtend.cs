using ExtendHelp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ExtendHelp
{
    public static class IEnumerableExtend
    {
        /// <summary>
        /// 执行cmb命令并返回cmb对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Cmb RunNewCmb(this IEnumerable<string> en)
        {
            var cmb = new Cmb();
            cmb.RunWaitReturn(en);
            return cmb;
        }
        /// <summary>
        /// 遍历IEnumerable集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="act"></param>
        public static void ForEach<T>(this IEnumerable en, Action<T> act)
        {
            foreach (var v in en)
            {
                act((T)v);
            }
        }
        /// <summary>
        /// 遍历IEnumerable集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="act"></param>
        public static void ForEachT<T>(this IEnumerable<T> en, Action<T> act)
        {
            foreach (var v in en)
            {
                act(v);
            }
        }
        /// <summary>
        /// 遍历IEnumerable集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="act"></param>
        public static T Aggregate2<T>(this IEnumerable<T> en, Func<T, T, T> act)
        {
            T t = default(T);
            foreach (var v in en)
            {
                t = act(t, v);
            }
            return t;
        }

        /// <summary>
        /// 遍历IEnumerable集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="act">如果返回true则退出循环</param>
        public static void ForEachBreak<T>(this IEnumerable<T> en, Func<T, bool> act)
        {
            foreach (var v in en)
            {
                if (act(v))
                {
                    return;
                }
            }
        }
        /// <summary>
        /// 判断是否绝对相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="en2"></param>
        /// <returns></returns>
        public static bool TotallyEqual<T>(this IList<T> en, IList<T> en2) where T : struct
        {
            if (en.Count != en2.Count)
            {
                return false;
            }
            int i = 0;
            foreach (T t in en)
            {
                if (!t.Equals(en2[i++]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 提取集合中一部分元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static T[] Substring<T>(this IEnumerable<T> en, long sourceIndex, long length)
        {
            T[] ts = new T[length];
            Array.Copy(en.ToArray(), sourceIndex, ts, 0, length);
            return ts;
        }
        /// <summary>
        /// 从集合中找到满足条件的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="fun"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Find<T>(this IEnumerable<T> en, Func<T, bool> fun, out T value)
        {
            foreach (T t in en)
            {
                if (fun(t))
                {
                    value = t;
                    return true;
                }
            }
            value = default(T);
            return false;
        }

        /// <summary>
        /// 打乱顺序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <returns></returns>
        public static T[] Shuffle<T>(this IList<T> en)
        {
            Random random = new Random();
            T[] newarr = new T[en.Count];
            bool[] arr = new bool[en.Count];
            int k = 0;
            int temp = 0;
            while (k < arr.Length)
            {
                temp = random.Next(0, arr.Length);
                if (!arr[temp])
                {
                    newarr[k] = en[temp];
                    k++;
                    arr[temp] = true;
                }
            }
            return newarr;
        }
        /// <summary>
        /// 判断是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="en2"></param>
        /// <returns></returns>
        public static bool Equal<T>(this IList<T> en, IList<T> en2)
        {
            int i = 0;
            foreach (T t in en)
            {
                if (en2.Count <= i)
                {
                    return true;
                }
                else if (!t.Equals(en2[i++]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 获取指定下标的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="en2"></param>
        /// <returns></returns>
        public static T GetT<T>(this IEnumerable<T> en, int index)
        {
            if (en.Count() > index)
            {
                return en.ElementAt(index);
            }
            else
            {
                return default(T);
            }
        }/// <summary>
         /// 获取指定下标的元素
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="en"></param>
         /// <param name="en2"></param>
         /// <returns></returns>
        public static int GetIndex(this IEnumerable<string> en, string s)
        {
            int i = 0;
            foreach (var t1 in en)
            {
                if (t1 == s)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        /// <summary>
        /// 获取url参数(传入字符编码代表进行url编码，否则不编码)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding">是否进行url编码</param>
        /// <returns></returns>
        public static string ToUrlParameter(this Dictionary<string, string> data, Encoding encoding = null)
        {
            StringBuilder builder = new StringBuilder();
            data.ForEachT(d => builder.Append($"{d.Key}={(encoding == null ? d.Value : d.Value.UrlEncode(encoding))}&"));
            return builder.ToString().Trim('&');
        }
        /// <summary>
        /// 添加url数据进入集合
        /// </summary>
        /// <param name="data"></param>
        /// <param name="urlData"></param>
        /// <returns></returns>
        public static Dictionary<string, string> AddUrlParameter(this Dictionary<string, string> data, string urlData)
        {
            var ss = urlData.Split('&');
            foreach (var d in ss)
            {
                var keyValue = d.Split('=');
                if (keyValue.Length == 2)
                {
                    if (data.ContainsKey(keyValue[0]))
                        data[keyValue[0]] = keyValue[1];
                    else
                        data.Add(keyValue[0], keyValue[1]);
                }
            }
            return data;
        }
        public static Dictionary<string, string> Remove(this Dictionary<string, string> data, params string[] keys)
        {
            foreach (var key in keys)
            {
                data.Remove(key);
            }
            return data;
        }
        /// <summary>
        /// 获取指定Key的Value值，如果没有则返回默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="en2"></param>
        /// <returns></returns>
        public static T2 GetValueDefault<T1, T2>(this Dictionary<T1, T2> en, T1 index)
        {
            if (en != null && en.ContainsKey(index))
            {
                return en[index];
            }
            else
            {
                return default(T2);
            }
        }
        /// <summary>
        /// 添加或者更新集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="en"></param>
        /// <param name="en2"></param>
        /// <returns></returns>
        public static void AddOrUpdate<T1, T2>(this Dictionary<T1, T2> en, T1 key, T2 value, Action act = null)
        {
            if (en.ContainsKey(key))
            {
                if (act == null)
                    en[key] = value;
                else
                    act();
            }
            else
            {
                en.Add(key, value);
            }
        }
    }
}
