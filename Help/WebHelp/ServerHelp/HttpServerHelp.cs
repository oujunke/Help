using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using ExtendHelp;
using HttpServer;

namespace Help.WebHelp.ServerHelp
{
    public class HttpServerHelp
    {
        private static HttpServer.HttpListener httpListener;
        private static MainModule mainModule = new MainModule();
        private static List<MainModule> Modules = new List<MainModule> { mainModule };
        public static void Open(int Port, int backlog = 5)
        {
            if (httpListener == null)
            {
                httpListener = HttpServer.HttpListener.Create(IPAddress.Any, Port);
                httpListener.RequestReceived += HttpListener_RequestReceived;
            }
            httpListener.Start(backlog);
        }
        public static void Stop()
        {
            if (httpListener != null)
                httpListener.Stop();
        }
        public static void AddMethod(string url, Func<AutoDictionary<string, string>, string> Method)
        {
            mainModule.AddMethod(url, Method);
        }
        public static void AddModule(MainModule module)
        {
            Modules.Add(module);
        }
        private static void HttpListener_RequestReceived(object sender, RequestEventArgs e)
        {
            IHttpRequest request = e.Request;
            IHttpClientContext context = sender as IHttpClientContext;
            foreach (var module in Modules)
            {
                if (module.Execute(request.Uri.AbsolutePath, request, out string result))
                {
                    context.Respond(result??string.Empty);
                    return;
                }
            }
        }
    }
}
