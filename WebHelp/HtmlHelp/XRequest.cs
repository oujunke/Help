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
        #region 成员字段
        private string _contentType;
        private string _userAgent;
        private string _referer;
        public int length;
        private bool _keepAlive;
        private Encoding _webEncoding;
        private int _timeout;
        private string _lastUrl;
        private string _webProxy;
        private CookieContainer _webCookieContainer;
        #endregion

        #region 成员属性
        /// <summary>
        /// 获取或设置 Content-typeHTTP 标头的值
        /// </summary>
        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        /// <summary>
        /// 获取或设置 User-agentHTTP 标头的值
        /// </summary>
        public string UserAgent
        {
            get { return _userAgent; }
            set { _userAgent = value; }
        }

        /// <summary>
        /// 获取或设置 RefererHTTP 标头的值
        /// </summary>
        public string Referer
        {
            get { return _referer; }
            set { _referer = value; }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否与 Internet 资源建立持久性连接
        /// </summary>
        public bool KeepAlive
        {
            get { return _keepAlive; }
            set { _keepAlive = value; }
        }

        /// <summary>
        /// 网页内容的编码方式
        /// </summary>
        public Encoding WebEncoding
        {
            get { return _webEncoding; }
            set { _webEncoding = value; }
        }

        /// <summary>
        /// 请求超时时间
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        /// <summary>
        /// 请求到的最后的地址
        /// </summary>
        public string LastUrl
        {
            get { return _lastUrl; }
            set { _lastUrl = value; }
        }

        /// <summary>
        /// 请求使用的代理
        /// </summary>
        public string WebProxy
        {
            get { return _webProxy; }
            set { _webProxy = value; }
        }

        /// <summary>
        /// 获取或设置与此请求关联的 cookie。
        /// </summary>
        public CookieContainer WebCookieContainer
        {
            get { return _webCookieContainer; }
            set { _webCookieContainer = value; }
        }
        #endregion

        #region 构造方法
        public XRequest ()
        {
            _userAgent = "Apache. Google webkit. volley/0/ai/eve";
            _timeout = 30000;
            _webEncoding = Encoding.UTF8;
            _contentType = "application/x-www-form-urlencoded; charset=UTF-8";
            _lastUrl = string.Empty;
            _webProxy = string.Empty;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
        }

        public XRequest (CookieContainer ccontainer)
            : this()
        {
            _webCookieContainer = ccontainer;
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
            return GetHtml(url, _webEncoding);
        }

        public string GetHtml (string url, WebProxy proxy)
        {
            return GetHtml(url, _webEncoding, proxy);
        }
        public void  GetCookie(string url)
        {
            byte[] bytes = Encoding.Default.GetBytes(url);
            CookieContainer myCookieContainer = new CookieContainer();
            try
            {
                //新建一个CookieContainer
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                //新建一个HttpWebRequest
                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                myHttpWebRequest.AllowAutoRedirect = false;
                myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)";
                myHttpWebRequest.Timeout = 60000;
                myHttpWebRequest.KeepAlive = true;
                myHttpWebRequest.ContentLength = bytes.Length;
                myHttpWebRequest.Method = "POST";
                myHttpWebRequest.CookieContainer = myCookieContainer;
                //设置HttpWebRequest
                Stream myRequestStream = myHttpWebRequest.GetRequestStream();
                myRequestStream.Write(bytes, 0, bytes.Length);
                myRequestStream.Close();
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
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
                request.CookieContainer = _webCookieContainer;
                
                request.Timeout = 30000;
                request.ReadWriteTimeout = 30000;
                request.UserAgent = _userAgent;
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                //request.Connection = "Keep-Alive";
                request.Referer =Referer;
                if (proxy != null) request.Proxy = proxy;
                if (!_keepAlive)
                {
                    request.KeepAlive = false;
                    request.ProtocolVersion = HttpVersion.Version11;
                }
                var response = (HttpWebResponse)request.GetResponse();
                var recvStream = response.GetResponseStream();
                var responseEncoding = Encoding.GetEncoding(response.CharacterSet);


                if (response.Cookies != null) _webCookieContainer?.Add(response.Cookies);
                if (recvStream != null)
                {
                    if (response.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        using (var stream = new GZipStream(recvStream, CompressionMode.Decompress))
                        {
                            using (var reader = new StreamReader(stream, responseEncoding))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))
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
                _lastUrl = response.ResponseUri.ToString();
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
            return PostHtml(url, args, _webEncoding);
        }

        public string PostHtml (string url, string args, WebProxy proxy)
        {
            return PostHtml(url, args, _webEncoding,true, proxy);
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
                request.CookieContainer = cc ?? _webCookieContainer;
                request.Timeout = _timeout;
                request.ReadWriteTimeout = _timeout;
                request.UserAgent = _userAgent;
                request.Referer = _referer;
                request.ContentType = _contentType;
                request.KeepAlive = false;//测试
                request.Headers.Add("Accept-Encoding:gzip");
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
                    if (response.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        using (var stream = new GZipStream(recvStream, CompressionMode.Decompress))
                        {
                            using (var reader = new StreamReader(stream, enc))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }
                    else if (response.ContentEncoding.ToLower().Contains("deflate"))
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
                _lastUrl = response.ResponseUri.ToString();
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
                request.CookieContainer = _webCookieContainer;
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version11;
                request.Timeout = _timeout;
                request.ReadWriteTimeout = _timeout;
                request.UserAgent = _userAgent;
                request.Referer = _referer;
                if (proxy != null) request.Proxy = proxy;
                var response = (HttpWebResponse)request.GetResponse();
                length = Convert.ToInt32(response.ContentLength);
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
                var bytes = _webEncoding.GetBytes(args);
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = _webCookieContainer;
                request.KeepAlive = true;
                request.ProtocolVersion = HttpVersion.Version11;
                request.Timeout = _timeout;
                request.ReadWriteTimeout = _timeout;
                request.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
                request.Headers.Add("Accept-Language: zh-cn");
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                request.Headers.Add("Accept-Language: zh-Hans-CN,zh-Hans;q=0.5");
                request.UserAgent = _userAgent;
                request.Referer = _referer;
                request.Method = "POST";
                var stream = request.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                var response = (HttpWebResponse)request.GetResponse();
                length = Convert.ToInt32(response.ContentLength);
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