using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TimerHub.Startup))]

namespace TimerHub
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Sucht selbst nach SignalR Klassen
            app.MapSignalR();
        }
    }
}
