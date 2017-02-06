using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HubSample.Startup))]

namespace HubSample

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
