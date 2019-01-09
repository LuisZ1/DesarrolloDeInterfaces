using chatdeclaseService.DataObjects;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chatdeclaseService.Hubs {
    public class ChatHub : Hub {

        public void Send(ChatMessage message) {
            Clients.All.broadcastMessage(message);
        }

    }
}