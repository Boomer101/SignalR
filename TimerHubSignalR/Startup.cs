using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(TimerHubSignalR.Startup))]

namespace TimerHubSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var timerClass = TimerClass.Instance;
            app.UseCors(CorsOptions.AllowAll);
            // Sucht selbst nach SignalR Klassen
            app.MapSignalR();
        }
    }
}
