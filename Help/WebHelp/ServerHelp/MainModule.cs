using HttpServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.WebHelp.ServerHelp
{
    public class MainModule
    {
        public Dictionary<string, Func<AutoDictionary<string, string>, Task<string>>> ModuleMethod = new Dictionary<string, Func<AutoDictionary<string, string>, Task<string>>>();
        public void AddMethod(string url, Func<AutoDictionary<string, string>, Task<string>> Method)
        {
            url = url.ToLower();
            if (!ModuleMethod.ContainsKey(url))
            {
                ModuleMethod.Add(url, Method);
            }
        }

        public async Task<(bool, string)> Execute(string key, IRequest request)
        {
            string result;
            key = key.ToLower().Trim('/', '\\').Split('?')[0];
            if (key.StartsWith("content") && File.Exists(key))
            {
                var sr = new StreamReader(key);
                result = sr.ReadToEnd();
                return (true, result);
            }
            else if (ModuleMethod.ContainsKey(key))
            {
                var getDataDictionary = GetData(request.Uri.Query.Trim('?'));
                var postDataDictionary = GetForm(request);
                foreach (var item in getDataDictionary)
                {
                    if (!postDataDictionary.ContainsKey(item.Key))
                    {
                        postDataDictionary.Add(item.Key, item.Value);
                    }
                }
                result = await ModuleMethod[key](postDataDictionary);
                return (true, result);
            }
            result = null;
            return (false, result);
        }
        private AutoDictionary<string, string> GetForm(IRequest Request)
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

        public string GetBody(IRequest Request)
        {
            var bs = new byte[Request.Body.Length];
            Request.Body.Read(bs, 0, bs.Length);
            var s = Encoding.UTF8.GetString(bs);
            return s;
        }
    }
}
