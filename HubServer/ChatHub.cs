using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HubSample
{
    [HubName("DummyHub")]
    public class ChatHub : Hub
    {
        [HubMethodName("MessageFromClient")]
        public void NewMessageFromClient(string name, string message)
        {
            Clients.All.NewMessageFromServer(name, message);
        }
    }
}