using System;
using System.Windows.Forms;

namespace ExtendHelp
{
    public static class WebBrowserExtend
    {
        private static bool IfAddJavaScript(WebBrowser webBrowser)
        {
            object o = webBrowser.Document.InvokeScript("test");
            return o != null && o.ToString() == "1";
        }
        private static void AddJavaScript(WebBrowser webBrowser)
        {
            if (!IfAddJavaScript(webBrowser))
            {
                var script1 = webBrowser.Document.CreateElement("script");
                script1.SetAttribute("type", "text/javascript");//data: par,
                script1.SetAttribute("text", "function request(url,data,requertype) { var res=$.ajax({url:url,async:false,data:data,type:requertype});return res.responseText;}function test(){return '1';}");
                var head1 = webBrowser.Document.Body.AppendChild(script1);
            }
        }
        /// <summary>
        /// 使用浏览器进行post请求(页面需要支持jq)
        /// </summary>
        /// <param name="webBrowser"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string WPost(this WebBrowser webBrowser, string url, string data = null)
        {
            return request(webBrowser, url, data, "POST");
        }
        /// <summary>
        /// 使用浏览器进行get请求(页面需要支持jq)
        /// </summary>
        /// <param name="webBrowser"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string WGet(this WebBrowser webBrowser, string url)
        {
            return request(webBrowser, url, null, "GET");
        }
        /// <summary>
        /// 调用js方法进行请求
        /// </summary>
        /// <param name="webBrowser"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string request(this WebBrowser webBrowser, string url, string data, string type)
        {
            webBrowser.Invoke(new Action(() => AddJavaScript(webBrowser)));
            object o = webBrowser.Invoke(new Func<object>(() => webBrowser.Document.InvokeScript("request", new object[] { url, data, type })));
            return o?.ToString();
        }
    }
}
