using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Host.HttpListener;
using Microsoft.Owin.Hosting;
using System.IO;

namespace OwinSample
{
    using Owin;
    using AppFunc = Func<IDictionary<string, object>, Task>;
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine($"Server started on {url}");
                Console.ReadKey();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseWelcomePage();
            app.Use<HelloEadnMiddleware>();
        }
    }

    public class HelloEadnMiddleware
    {
        public HelloEadnMiddleware(AppFunc context)
        {

        }
        public async Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using(StreamWriter writer = new StreamWriter(response))
            {
                await writer.WriteAsync("Hello EADN 2");
            }
        }
    }

    public class LoggerModule
    {
        public LoggerModule() { }

    }
}
