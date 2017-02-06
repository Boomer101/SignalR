using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using System.Timers;

[assembly: OwinStartup(typeof(TimerHub.TimerHub))]

namespace TimerHub
{
    public class TimerHub : Hub
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }

    public static class TimerClass
    {
        private static Timer timer;
        static TimerClass()
        {
            timer = new Timer(200);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            GlobalHost.ConnectionManager.GetHubContext<TimerHub>().Clients.All.sendTime(DateTime.UtcNow.ToString());
        }
    }
}
