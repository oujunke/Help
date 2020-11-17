using Help.Model;
using HttpServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace Help.WebHelp.ServerHelp
{
   public class MainModule
    {
        public Dictionary<string, Func<AutoDictionary<string, string>, string>> ModuleMethod = new Dictionary<string, Func<AutoDictionary<string, string>, string>>();
        public void AddMethod(string url,Func<AutoDictionary<string, string>, string> Method)
        {
            url = url.ToLower();
            if (!ModuleMethod.ContainsKey(url))
            {
                ModuleMethod.Add(url,Method);
            }
        }
        
        public bool Execute(string key, IHttpRequest request,out string result)
        {
            key = key.ToLower().Trim('/','\\').Split('?')[0];
            if (key.StartsWith("content")&&File.Exists(key)) {
                result = File.ReadAllText(key);
                return true;
            }
            else if (ModuleMethod.ContainsKey(key))
            {
                var getDataDictionary = GetData(request.Uri.Query.Trim('?'));
                var postDataDictionary = GetForm(request);
                foreach (var item in getDataDictionary)
                {
                    if (!postDataDictionary.ContainsKey(item.Key))
                    {
                        postDataDictionary.Add(item.Key,item.Value);
                    }
                }
                result = ModuleMethod[key](postDataDictionary);
                return true;
            }
            result = null;
            return false;
        }
        private AutoDictionary<string, string> GetForm(IHttpRequest Request)
        {
            var s = GetBody(Request);
            return GetData(s);
        }

        private static AutoDictionary<string, string> GetData(string s)
        {
            AutoDictionary<string, string> Form = new AutoDictionary<string, string>();
            var ss = s.Split('&');
            foreach (var f in ss)
            {
                var p = f.Split('=');
                if (p.Length > 1)
                {
                    Form.Add(p[0], p[1]);
                }
            }
            return Form;
        }

        public string GetBody(IHttpRequest Request)
        {
            var bs = new byte[Request.Body.Length];
            Request.Body.Read(bs, 0, bs.Length);
            var s = Encoding.UTF8.GetString(bs);
            return s;
        }
    }
}
