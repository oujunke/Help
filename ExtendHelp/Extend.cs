using ExtendHelp.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExtendHelp
{
    public static class Extend
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="act"></param>
        /// <returns></returns>
        public static Task<T> Async<T>(Func<T> act)
        {
            return Task.Factory.StartNew(act);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="act"></param>
        /// <returns></returns>
        public static T WaitResult<T>(this Task<T> task)
        {
            if (task.IsCanceled)
            {
                return default(T);
            }
            task.Wait();
            return task.Result;
        }
        /// <summary>
        /// 等待某个对象的值发生期望的变化
        /// </summary>
        /// <param name="obj">监视的值</param>
        /// <param name="fun">期望变化，默认是不为空</param>
        public static void WaitNotNull(this object obj, Func<bool> fun = null)
        {
            fun = fun ?? (() => obj != null);
            while (true)
            {
                if (fun())
                {
                    return;
                }
                Thread.Sleep(100);
            }
        }
        private static bool DefaultJudgment(object p)
        {
            return p != null;
        }
        /// <summary>
        /// 等待某个对象的值发生期望的变化
        /// </summary>
        /// <param name="obj">监视的值</param>
        /// <param name="fun">期望变化，默认是不为空</param>
        public static void WaitNotNull(this object obj, ref string p, Func<object, bool> fun = null)
        {
            fun = fun ?? DefaultJudgment;
            while (true)
            {
                if (fun(p))
                {
                    return;
                }
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// 用指定条件筛选datarow
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fuc"></param>
        /// <returns></returns>
        public static List<DataRow> Find(this DataRowCollection dr, Func<DataRow, bool> fuc)
        {
            List<DataRow> res = new List<DataRow>();
            dr.ForEach<DataRow>(r =>
            {
                if (fuc(r))
                {
                    res.Add(r);
                }
            });
            return res;
        }
        /// <summary>
        /// 获得Sqlite时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int GetSqliteDate(this DateTime dt)
        {
            DateTime d = new DateTime(1970, 1, 1);
            return (int)(dt - d).TotalSeconds;
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetTimeStamp(this DateTime dateTime)
        {
            return GetTimeStampInt(dateTime).ToString();
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long GetTimeStampInt(this DateTime dateTime)
        {
            return ((dateTime.ToUniversalTime().Ticks - 621355968000000000) / 10000);
        }
        /// <summary>
        /// 时间戳转时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this string timeStamp)
        {
            if (timeStamp.IsNullOrWhiteSpace())
            {
                return DateTime.MinValue;
            }
            var num = Int64.Parse(timeStamp);
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            if (num > 9466560000)
            {
                TimeSpan toNow = new TimeSpan(num * 10000);
                return dtStart.Add(toNow);
            }
            else
            {
                TimeSpan toNow = new TimeSpan(num * 1000 * 10000);
                return dtStart.Add(toNow);
            }
        }
        public static DateTime GetDateTimes(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = Int64.Parse($"{timeStamp}0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        /// <summary>
        /// 把DataRow强制转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public static T Cast<T>(this DataRow dataRow) where T : IDataRowByModelInterface, new()
        {
            T t = new T();
            t.SetAttribute(dataRow.ItemArray);
            return t;
        }
        /// <summary>
        /// 把DataRow集合强制转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public static List<T> Cast<T>(this IEnumerable<DataRow> dataRows) where T : IDataRowByModelInterface, new()
        {
            T t = new T();
            List<T> list = new List<T>();
            dataRows.ForEachT(r =>
            {
                t = new T();
                t.SetAttribute(r.ItemArray);
                list.Add(t);
            });
            return list;
        }
        public static string GetCookie(this CookieContainer cookieContainer, string name)
        {
            Hashtable table = (Hashtable)cookieContainer.GetType().InvokeMember("m_domainTable",
               System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
               System.Reflection.BindingFlags.Instance, null, cookieContainer, new object[] { });
            foreach (object cookieList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)cookieList.GetType().InvokeMember("m_list",
                   System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                   | System.Reflection.BindingFlags.Instance, null, cookieList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                {
                    foreach (Cookie c1 in colCookies)
                    {
                        if (c1.Name == name)
                        {
                            return c1.Value;
                        }
                    }
                }
            }
            return string.Empty;
        }
        public static Dictionary<string, string> GetAllCookie(this CookieContainer cookieContainer)
        {
            Hashtable table = (Hashtable)cookieContainer.GetType().InvokeMember("m_domainTable",
               System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
               System.Reflection.BindingFlags.Instance, null, cookieContainer, new object[] { });
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (object cookieList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)cookieList.GetType().InvokeMember("m_list",
                   System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                   | System.Reflection.BindingFlags.Instance, null, cookieList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                {
                    foreach (Cookie c1 in colCookies)
                    {
                        if (dictionary.ContainsKey(c1.Name))
                        {
                            dictionary[c1.Name] = c1.Value;
                        }
                        else
                        {
                            dictionary.Add(c1.Name, c1.Value);
                        }
                    }
                }
            }
            return dictionary;
        }
        public static Dictionary<string, Dictionary<string, string>> GetAllUrlCookie(this CookieContainer cookieContainer)
        {
            Hashtable table = (Hashtable)cookieContainer.GetType().InvokeMember("m_domainTable",
               System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
               System.Reflection.BindingFlags.Instance, null, cookieContainer, new object[] { });
            Dictionary<string, Dictionary<string, string>> dictionary = new Dictionary<string, Dictionary<string, string>>();
            foreach (DictionaryEntry cookieList in table)
            {
                var data = new Dictionary<string, string>();
                dictionary.Add(cookieList.Key.ToString(), data);
                SortedList lstCookieCol = (SortedList)cookieList.Value.GetType().InvokeMember("m_list",
                   System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                   | System.Reflection.BindingFlags.Instance, null, cookieList.Value, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                {
                    foreach (Cookie c1 in colCookies)
                    {
                        if (data.ContainsKey(c1.Name))
                        {
                            data[c1.Name] = c1.Value;
                        }
                        else
                        {
                            data.Add(c1.Name, c1.Value);
                        }
                    }
                }
            }
            return dictionary;
        }
    }
}
