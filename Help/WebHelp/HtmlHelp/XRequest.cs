using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Text;
using ExtendHelp;
namespace Help.WebHelp.HtmlHelp
{
    public class XRequest
    {
        #region 成员属性
        /// <summary>
        /// 获取或设置 Content-typeHTTP 标头的值
        /// </summary>
        public string ContentType { set; get; }
        /// <summary>
        /// 获取或设置 Accept 标头的值
        /// </summary>
        public string Accept { set; get; }
        /// <summary>
        /// 获取或设置 User-agentHTTP 标头的值
        /// </summary>
        public string UserAgent { set; get; }

        /// <summary>
        /// 获取或设置 RefererHTTP 标头的值
        /// </summary>
        public string Referer { set; get; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否与 Internet 资源建立持久性连接
        /// </summary>
        public bool KeepAlive { set; get; }
        /// <summary>
        /// 响应长度
        /// </summary>
        public int Length { set; get; }
        /// <summary>
        /// 网页内容的编码方式
        /// </summary>
        public Encoding WebEncoding { set; get; }

        /// <summary>
        /// 请求超时时间
        /// </summary>
        public int Timeout { set; get; }

        /// <summary>
        /// 请求到的最后的地址
        /// </summary>
        public string LastUrl { set; get; }

        /// <summary>
        /// 请求使用的代理
        /// </summary>
        public string WebProxy { set; get; }

        /// <summary>
        /// 获取或设置与此请求关联的 cookie。
        /// </summary>
        public CookieContainer WebCookieContainer { set; get; }

        public WebHeaderCollection HeaderCollection { set; get; }
        #endregion

        #region 构造方法
        public XRequest ()
        {
            UserAgent = "Apache. Google webkit. volley/0/ai/eve";
            Timeout = 30000;
            WebEncoding = Encoding.UTF8;
            ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            LastUrl = string.Empty;
            WebProxy = string.Empty;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
        }

        public XRequest (CookieContainer ccontainer)
            : this()
        {
            WebCookieContainer = ccontainer;
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
        }
        #endregion

        #region 成员方法

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtml (string url)
        {
            return GetHtml(url, WebEncoding);
        }

        public string GetHtml (string url, WebProxy proxy)
        {
            return GetHtml(url, WebEncoding, proxy);
        }
        public void  GetCookie(string url)
        {
            byte[] bytes = Encoding.Default.GetBytes(url);
            CookieContainer myCookieContainer = new CookieContainer();
            try
            {
                //新建一个CookieContainer
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //新建一个HttpWebRequest
                request.ContentType = ContentType;
                request.AllowAutoRedirect = false;
                request.UserAgent = UserAgent;
                request.Timeout = Timeout;
                request.Accept = Accept;
                if (!KeepAlive)
                {
                    request.KeepAlive = false;
                    request.ProtocolVersion = HttpVersion.Version11;
                }
                if (HeaderCollection != null)
                {
                    request.Headers.Add(HeaderCollection);
                }
                request.ContentLength = bytes.Length;
                request.Method = "POST";
                request.CookieContainer = myCookieContainer;
                //设置HttpWebRequest
                Stream myRequestStream = request.GetRequestStream();
                myRequestStream.Write(bytes, 0, bytes.Length);
                myRequestStream.Close();
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)request.GetResponse();
                foreach (Cookie ck in myHttpWebResponse.Cookies)
                {
                    myCookieContainer.Add(ck);
                }
                myHttpWebResponse.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取COOKIES失败！"+ex.Message);
                //MessageBox.show();
                return;
            }
        }
        /// <summary>
        /// 得到cookie值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static string GetCookie(string cookieName, CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });
            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c1 in colCookies) lstCookies.Add(c1);
            }
            var model = lstCookies.Find(p => p.Name == cookieName);
            if (model != null)
            {
                return model.Value;
            }
            return string.Empty;
        }

        public string GetHtml (string url, Encoding enc, WebProxy proxy = null)
        {
            string result = null;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = true;
                request.CookieContainer = WebCookieContainer;
                request.Accept = Accept;
                request.Timeout = Timeout;
                request.ReadWriteTimeout = Timeout;
                request.UserAgent = UserAgent;
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                request.Referer =Referer;
                if (proxy != null) request.Proxy = proxy;
                if (!KeepAlive)
                {
                    request.KeepAlive = false;
                    request.ProtocolVersion = HttpVersion.Version11;
                }
                if (HeaderCollection != null)
                {
                    request.Headers.Add(HeaderCollection);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var recvStream = response.GetResponseStream();
                var responseEncoding = Encoding.GetEncoding(response.CharacterSet);

                if (response.Cookies != null) WebCookieContainer?.Add(response.Cookies);
                if (recvStream != null)
                {
                    if (response.ContentEncoding?.ToLower().Contains("gzip")==true)
                    {
                        using (var stream = new GZipStream(recvStream, CompressionMode.Decompress))
                        {
                            using (var reader = new StreamReader(stream, responseEncoding))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }
                    else if (response.ContentEncoding?.ToLower().Contains("deflate")==true)
                    {
                        using (var stream = new DeflateStream(recvStream, CompressionMode.Decompress))
                        {
                            using (var reader = new StreamReader(stream, responseEncoding))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        using (var reader = new StreamReader(recvStream, responseEncoding))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
                LastUrl = response.ResponseUri.ToString();
                response.Close();
                request.Abort();
            }
            catch (Exception ex)
            {
                result = $"Exception:{ex.Message}";
            }
            return result;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string PostHtml (string url, string args)
        {
            return PostHtml(url, args, WebEncoding);
        }

        public string PostHtml (string url, string args, WebProxy proxy)
        {
            return PostHtml(url, args, WebEncoding,true, proxy);
        }
        public CookieCollection cookieCollection = null;
        public string PostHtml (string url, string args, Encoding enc,bool isAddCookies=false, WebProxy proxy = null)
        {
           
            return PostHtml(url, enc.GetBytes(args), enc, isAddCookies, proxy);
        }
        public string PostHtml(string url, byte[] bytes,  Encoding enc,bool isAddCookies = false, WebProxy proxy = null)
        {
            string result = null;
            CookieContainer cc = null;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                if (!isAddCookies && cookieCollection != null)
                {
                    cc = new CookieContainer();
                    foreach (Cookie c in cookieCollection)
                    {
                        c.Path = "/";
                        cc.Add(c);
                    }
                }
                request.CookieContainer = cc ?? WebCookieContainer;
                request.Timeout = Timeout;
                request.ReadWriteTimeout = Timeout;
                request.UserAgent = UserAgent;
                request.Referer = Referer;
                request.Accept = Accept;
                request.ContentType = ContentType;
                request.Headers.Add("Accept-Encoding:gzip");
                if (!KeepAlive)
                {
                    request.KeepAlive = false;
                    request.ProtocolVersion = HttpVersion.Version11;
                }
                if (HeaderCollection != null)
                {
                    request.Headers.Add(HeaderCollection);
                }
                request.ContentLength = bytes.Length;
                request.Method = "POST";
                request.ProtocolVersion = HttpVersion.Version10;
                if (proxy != null) request.Proxy = proxy;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                if (isAddCookies)
                {
                    cookieCollection = response.Cookies;
                }
                var recvStream = response.GetResponseStream();
                if (recvStream != null)
                {
                    if (response.ContentEncoding?.ToLower().Contains("gzip")==true)
                    {
                        using (var stream = new GZipStream(recvStream, CompressionMode.Decompress))
                        {
                            using (var reader = new StreamReader(stream, enc))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }
                    else if (response.ContentEncoding?.ToLower().Contains("deflate")==true)
                    {
                        using (var stream = new DeflateStream(recvStream, CompressionMode.Decompress))
                        {
                            using (var reader = new StreamReader(stream, enc))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        using (var reader = new StreamReader(recvStream, enc))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
                LastUrl = response.ResponseUri.ToString();
                response.Close();
                request.Abort();
            }
            catch (Exception ex)
            {
                result = $"Exception:{ex.Message}";
            }
            return result;
        }

        /// <summary>
        /// 请求流
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Stream GetStream (string url, WebProxy proxy = null)
        {
            Stream recvStream = null;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = WebCookieContainer;
                if (!KeepAlive)
                {
                    request.KeepAlive = false;
                    request.ProtocolVersion = HttpVersion.Version11;
                }
                if (HeaderCollection != null)
                {
                    request.Headers.Add(HeaderCollection);
                }
                request.ProtocolVersion = HttpVersion.Version11;
                request.Timeout = Timeout;
                request.ReadWriteTimeout = Timeout;
                request.UserAgent = UserAgent;
                request.Accept = Accept;
                request.Referer = Referer;
                if (proxy != null) request.Proxy = proxy;
                var response = (HttpWebResponse)request.GetResponse();
                Length = Convert.ToInt32(response.ContentLength);
                recvStream = response.GetResponseStream();
            }
            catch (Exception ex)
            {
                
            }

            return recvStream;
        }


        public Stream PostStream (string url, string args)
        {
            Stream recvStream = null;

            try
            {
                var bytes = WebEncoding.GetBytes(args);
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = WebCookieContainer;
                request.ProtocolVersion = HttpVersion.Version11;
                request.Timeout = Timeout;
                request.ReadWriteTimeout = Timeout;
                request.ContentType = ContentType;
                request.Headers.Add("Accept-Language: zh-cn");
                request.Accept =Accept;
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                request.Headers.Add("Accept-Language: zh-Hans-CN,zh-Hans;q=0.5");
                request.UserAgent = UserAgent;
                request.Referer = Referer;
                request.Method = "POST";
                if (!KeepAlive)
                {
                    request.KeepAlive = false;
                    request.ProtocolVersion = HttpVersion.Version11;
                }
                if (HeaderCollection != null)
                {
                    request.Headers.Add(HeaderCollection);
                }
                var stream = request.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                var response = (HttpWebResponse)request.GetResponse();
                Length = Convert.ToInt32(response.ContentLength);
                recvStream = response.GetResponseStream();
            }
            catch (Exception)
            {
                // ignored
            }

            return recvStream;
        }
        #endregion
    }
}