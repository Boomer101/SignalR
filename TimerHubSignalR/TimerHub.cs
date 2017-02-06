using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using System.Timers;
using Microsoft.AspNet.SignalR.Hubs;

namespace TimerHubSignalR
{
    [HubName("TimerHub")]
    public class TimerHub : Hub
    {
     
    }

    public class TimerClass
    {
        private static TimerClass _instance;
        private static Timer timer;
        public TimerClass()
        {
            timer = new Timer(200);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            GlobalHost.ConnectionManager.GetHubContext<TimerHub>().Clients.All.sendTime(DateTime.UtcNow.ToString());
        }

        internal static TimerClass Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TimerClass();
                }

                return _instance;
            }
        }
    }
}
