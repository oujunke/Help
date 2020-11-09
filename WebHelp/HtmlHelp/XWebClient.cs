using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using ExtendHelp;
using Help.Model;

namespace Help.WebHelp.HtmlHelp
{
    // Token: 0x0200001B RID: 27
    public class XWebClient : WebClient
    {
        /// <summary>
        /// 
        /// </summary>
        public string ContentType
        {
            get
            {
                return this.HeaderCollection["Content-Type"];
            }
            set
            {
                this.HeaderCollection["Content-Type"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Accept
        {
            get
            {
                return this.HeaderCollection["Accept"];
            }
            set
            {
                this.HeaderCollection["Accept"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserAgent
        {
            get
            {
                return this.HeaderCollection["User-Agent"];
            }
            set
            {
                this.HeaderCollection["User-Agent"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Referer
        {
            get
            {
                return this.HeaderCollection["Referer"];
            }
            set
            {
                this.HeaderCollection["Referer"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AcceptEncoding
        {
            get
            {
                return this.HeaderCollection["Accept-Encoding"];
            }
            set
            {
                this.HeaderCollection["Accept-Encoding"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AcceptLanguage
        {
            get
            {
                return this.HeaderCollection["Accept-Language"];
            }
            set
            {
                this.HeaderCollection["Accept-Language"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string WebProxy { get; set; }

        /// <summary>
        /// Http请求头
        /// </summary>
        public WebHeaderCollection HeaderCollection { get; set; } = new WebHeaderCollection();

        /// <summary>
        /// 
        /// </summary>
        public bool OpenCookie { get; set; } = true;

        /// <summary>
        /// 使用的编码
        /// </summary>
        public Encoding WebEncoding { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 上次请求Url
        /// </summary>
        public string LastUrl { get; set; }

        /// <summary>
        /// 默认代理
        /// </summary>
        public WebProxy DefaultProxy { get; set; }

        /// <summary>
        /// Cookie
        /// </summary>
        public CookDictionary WebCookieDictionary { get; set; } = new CookDictionary();

        /// <summary>
        /// 空白Cookie(默认空白不传)
        /// </summary>
        public CookDictionary EmptyCookieDictionary { get; set; } = new CookDictionary();

        /// <summary>
        /// 初始化方法
        /// </summary>
        public XWebClient(bool init=true)
        {
            this.WebEncoding = Encoding.UTF8;
            if (init)
            {
                this.AcceptEncoding = "gzip, deflate, br";
                this.AcceptLanguage = "zh,en;q=0.9,zh-CN;q=0.8";
                this.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";
                this.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                this.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            }

        }
        static XWebClient()
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(
                delegate
                {
                    return true;
                }
            );
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
        }
        /// <summary>
        /// 获得请求类
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest webRequest = base.GetWebRequest(address);
            bool flag = webRequest is HttpWebRequest;
            if (flag)
            {
                ((HttpWebRequest)webRequest).AllowAutoRedirect = false;
            }
            return webRequest;
        }

        /// <summary>
        /// 获得指定地址的字符串
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public string GetCookie(string host)
        {
            StringBuilder stringBuilder = new StringBuilder();
            IOrderedEnumerable<string> orderedEnumerable = from k in this.WebCookieDictionary.Keys
                                                           where host.EndsWith(k)
                                                           select k into s
                                                           orderby s.Length
                                                           select s;
            foreach (string key in orderedEnumerable)
            {
                foreach (KeyValuePair<string, string> keyValuePair in this.WebCookieDictionary[key])
                {
                    bool flag = !keyValuePair.Value.IsNullOrWhiteSpace() || this.EmptyCookieDictionary[key].ContainsKey(keyValuePair.Key);
                    if (flag)
                    {
                        stringBuilder.Append(string.Concat(new string[]
                        {
                            " ",
                            keyValuePair.Key,
                            "=",
                            keyValuePair.Value,
                            ";"
                        }));
                    }
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 发起Http请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        private string Request(string url, string method, byte[] data, WebProxy proxy = null)
        {
            string result;
            try
            {
                Encoding encoding;
                MemoryStream memoryStream = this.RequestStream(url, method, data, out encoding, proxy);
                result = encoding.GetString(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                result = "Exception:" + ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 发起Http请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <param name="webEncoding"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        private MemoryStream RequestStream(string url, string method, byte[] data, out Encoding webEncoding, WebProxy proxy = null)
        {
            MemoryStream memoryStream = new MemoryStream();
            string host = url.RegexGetString("https?://([^/\\\\]*)", 1);
            string cookie = this.GetCookie(host);
            base.Headers.Clear();
            base.Headers.Add(this.HeaderCollection);
            bool flag = !cookie.IsNullOrWhiteSpace();
            if (flag)
            {
                base.Headers["Cookie"] = cookie;
            }
            base.Encoding = this.WebEncoding;
            base.Proxy = (proxy ?? this.DefaultProxy);
            byte[] array = null;
            bool flag2 = method == "POST";
            if (flag2)
            {
                array = base.UploadData(url, data);
            }
            else
            {
                array = base.DownloadData(url);
            }
            WebHeaderCollection responseHeaders = base.ResponseHeaders;
            string[] array2 = (responseHeaders != null) ? responseHeaders.GetValues("Set-Cookie") : null;
            bool flag3 = array2 != null;
            if (flag3)
            {
                this.SetCookie(url, array2);
            }
            webEncoding = this.WebEncoding;
            WebHeaderCollection responseHeaders2 = base.ResponseHeaders;
            string text = (responseHeaders2 != null) ? responseHeaders2.Get("Location") : null;
            bool flag4 = !text.IsNullOrWhiteSpace();
            MemoryStream result;
            if (flag4)
            {
                bool flag5 = !text.StartsWith("http");
                if (flag5)
                {
                    text = url.RegexGetString("(https?://[^/\\\\]*)", 1) + text;
                }
                result = this.GetSteam(text, out webEncoding, null);
            }
            else
            {
                WebHeaderCollection responseHeaders3 = base.ResponseHeaders;
                string str = (responseHeaders3 != null) ? responseHeaders3.Get("Content-Type") : null;
                bool flag6 = !str.IsNullOrWhiteSpace();
                if (flag6)
                {
                    string text2 = str.RegexGetString("charset=([^; ,]*)", 1);
                    bool flag7 = !text2.IsNullOrWhiteSpace();
                    if (flag7)
                    {
                        try
                        {
                            Encoding encoding = Encoding.GetEncoding(text2);
                            bool flag8 = encoding.BodyName == text2;
                            if (flag8)
                            {
                                webEncoding = encoding;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                WebHeaderCollection responseHeaders4 = base.ResponseHeaders;
                string text3 = (responseHeaders4 != null) ? responseHeaders4.Get("Content-Encoding") : null;
                this.LastUrl = url;
                bool flag9 = text3.IsNullOrWhiteSpace();
                if (flag9)
                {
                    memoryStream.Write(array, 0, array.Length);
                    result = memoryStream;
                }
                else
                {
                    using (MemoryStream memoryStream2 = new MemoryStream(array))
                    {
                        bool flag10 = text3.ToLower().Contains("gzip");
                        if (flag10)
                        {
                            using (GZipStream gzipStream = new GZipStream(memoryStream2, CompressionMode.Decompress))
                            {
                                gzipStream.CopyTo(memoryStream);
                            }
                        }
                        else
                        {
                            bool flag11 = text3.ToLower().Contains("deflate");
                            if (flag11)
                            {
                                using (DeflateStream deflateStream = new DeflateStream(memoryStream2, CompressionMode.Decompress))
                                {
                                    deflateStream.CopyTo(memoryStream);
                                }
                            }
                            else
                            {
                                memoryStream2.CopyTo(memoryStream);
                            }
                        }
                    }
                    result = memoryStream;
                }
            }
            return result;
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public string GetHtml(string url, WebProxy proxy = null)
        {
            return this.Request(url, "GET", null, proxy);
        }

        /// <summary>
        /// 异步Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public Task<string> GetHtmlAsyn(string url, WebProxy proxy = null)
        {
            return Task.Factory.StartNew<string>(() => this.Clone().Request(url, "GET", null, proxy));
        }

        /// <summary>
        /// Get请求返回流
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public MemoryStream GetSteam(string url, out Encoding encoding, WebProxy proxy = null)
        {
            return this.RequestStream(url, "GET", null, out encoding, proxy);
        }

        /// <summary>
        /// Get请求返回流
        /// </summary>
        /// <param name="url"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public MemoryStream GetSteam(string url, WebProxy proxy = null)
        {
            Encoding encoding;
            return this.RequestStream(url, "GET", null, out encoding, proxy);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public string PostHtml(string url, string data, WebProxy proxy = null)
        {
            byte[] bytes = this.WebEncoding.GetBytes(data);
            return this.Request(url, "POST", bytes, proxy);
        }

        /// <summary>
        /// 异步Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public Task<string> PostHtmlAsyn(string url, string data, WebProxy proxy = null)
        {
            return Task.Factory.StartNew<string>(() => this.Clone().PostHtml(url, data, proxy));
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="bs"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public string PostHtml(string url, byte[] bs, WebProxy proxy = null)
        {
            return this.Request(url, "POST", bs, proxy);
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookieStrings"></param>
        private void SetCookie(string url, string[] cookieStrings)
        {
            string text = url.RegexGetString("https?://([^/\\\\]*)", 1);
            foreach (string str in cookieStrings)
            {
                string text2 = str.RegexGetString("([^=]*=[^;,]*)", 1);
                string text3 = str.RegexGetString("[ ;,][Dd][Oo][Mm][Aa][Ii][Nn]=([^; ]*)", 1);
                bool flag = text3.IsNullOrWhiteSpace();
                if (flag)
                {
                    text3 = text;
                }
                int num = text2.IndexOf('=');
                bool flag2 = num > 0;
                if (flag2)
                {
                    string key = text2.Remove(num);
                    string value = text2.Substring(num + 1);
                    this.WebCookieDictionary[text3][key] = value;
                }
            }
        }

        /// <summary>
        /// 添加FiddlerCookie
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookies"></param>
        public void AddFiddlerCookie(string url, string cookies)
        {
            string[] array = cookies.Replace("Cookie:", "").Split(new char[]
            {
                ';'
            });
            foreach (string text in array)
            {
                int num = text.IndexOf('=');
                bool flag = num > 0;
                if (flag)
                {
                    this.WebCookieDictionary[url][text.Substring(0, num).Trim()] = text.Substring(num + 1).Trim();
                }
            }
        }
        /// <summary>
        /// 深复制对象
        /// </summary>
        /// <returns></returns>
        public XWebClient Clone()
        {
            return new XWebClient
            {
                Accept = this.Accept,
                AcceptEncoding = this.AcceptEncoding,
                AcceptLanguage = this.AcceptLanguage,
                ContentType = this.ContentType,
                DefaultProxy = this.DefaultProxy,
                HeaderCollection = this.HeaderCollection,
                OpenCookie = this.OpenCookie,
                LastUrl = this.LastUrl,
                UserAgent = this.UserAgent,
                Referer = this.Referer,
                Timeout = this.Timeout,
                WebCookieDictionary = this.WebCookieDictionary,
                WebEncoding = this.WebEncoding,
                WebProxy = this.WebProxy
            };
        }

        /// <summary>
        /// Http格式ACCEPT头
        /// </summary>
        public const string HTTP_ACCEPT = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";

        /// <summary>
        /// Http格式CONTENT_TYPE头
        /// </summary>
        public const string HTTP_CONTENT_TYPE = "application/x-www-form-urlencoded;charset=UTF-8";

        /// <summary>
        /// Json格式ACCEPT头
        /// </summary>
        public const string JSON_ACCEPT = "application/json, text/javascript, */*; q=0.01";

        /// <summary>
        /// Json格式CONTENT_TYPE头
        /// </summary>
        public const string JSON_CONTENT_TYPE = "application/json;charset=UTF-8";

        /// <summary>
        /// Fiddler代理
        /// </summary>
        public static WebProxy FiddlerProxy = new WebProxy("127.0.0.1", 8888);
    }
}
