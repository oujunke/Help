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
        public Dictionary<string, Func<IHttpRequest, string>> ModuleMethod = new Dictionary<string, Func<IHttpRequest, string>>();
        public void AddMethod(string url,Func<IHttpRequest, string> Method)
        {
            url = url.ToLower();
            if (!ModuleMethod.ContainsKey(url))
            {
                ModuleMethod.Add(url,Method);
            }
        }
        
        public bool Execute(string key,IHttpRequest request,out string Result)
        {
            key = key.ToLower().Trim('/','\\').Split('?')[0];
            if (key.StartsWith("content")&&File.Exists(key)) {
                var sr = new StreamReader(key);
                Result = sr.ReadToEnd();
                return true;
            }
            else if (ModuleMethod.ContainsKey(key))
            {
                Result=ModuleMethod[key](request);
                return true;
            }
            Result = null;
            return false;
        }
        public Dictionary<string, string> GetForm(IHttpRequest Request)
        {
            var s = GetBody(Request);
            Dictionary<string, string> Form = new Dictionary<string, string>();
            var ss = s.Split('&'); 
            foreach(var f in ss)
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
