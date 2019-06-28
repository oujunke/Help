using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Help.WebHelp.HtmlHelp
{
    public static class DataHelp
    {
        private static JavaScriptSerializer _jss = new JavaScriptSerializer();
        private static DataContractJsonSerializer _dcjs;
        #region Serialization JSON
        /// <summary>
        /// 把对象序列化为JSON字符串
        /// </summary>
        /// <param name="obj">需要序列化的字符串</param>
        /// <returns></returns>
        public static string ObjectToJSON(this object obj)
        {
            return _jss.Serialize(obj);
        }
        /// <summary>
        /// 把JSON字符串序列化为JSON字符串对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="JSON">需要反序列化的字符串</param>
        /// <returns></returns>
        public static T JSONToObject<T>(this string JSON)
        {
            return _jss.Deserialize<T>(JSON);
        }
        /// <summary>
        /// 把JSON字符串序列化为JSON字符串对象
        /// </summary>
        /// <typeparam name="Object"></typeparam>
        /// <param name="JSON">需要反序列化的字符串</param>
        /// <param name="t">需要反序列化成的类型</param>
        /// <returns></returns>
        public static Object JSONToObject(this string JSON,Type t)
        {
            return _jss.Deserialize(JSON,t);
        }
        #endregion
        #region Json
        /// <summary>
        /// 把对象序列化为JSON字符串
        /// </summary>
        /// <param name="obj">需要序列化的字符串</param>
        /// <returns></returns>
        public static string ObjectToJSONByJSON(this object obj)
        {
            _dcjs = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                _dcjs.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.GetBuffer());
            }
        }
        #endregion
    }
}
