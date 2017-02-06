using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Owin;
using Microsoft.Owin.Cors;

namespace PersistentConnectionServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine($"Server is running on {url}");
                Console.ReadLine();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Cors zuerst, Reihenfolge wichtig !
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR<MyPersistentConnection>("/ps");
        }
    }

    public class MyPersistentConnection : PersistentConnection
    {
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            // Jeder Client erhält eine eigene ID, pro neue Verbindung 
            Console.WriteLine($"New client connected, Connection ID: {connectionId}");
            return base.OnConnected(request, connectionId);
        }
        protected override async Task OnReceived(IRequest request, string connectionId, string data)
        {
            // Antwort an alle Clients
            await Connection.Broadcast(data);
        }
    }
}
