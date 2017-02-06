using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace TimerHubClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            var connection = new HubConnection("http://localhost:22081");
            var hubProxy = connection.CreateHubProxy("TimerHub");
        }
    }
}
