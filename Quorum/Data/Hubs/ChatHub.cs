using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Data.Hubs
{
    public class ChatHub : Hub
    {
        public const string HubUrl = "/chat";

        public IConnectionManager _manager { get; }

        public ChatHub(IConnectionManager manager)
        {
            _manager = manager;
        }

        public override Task OnConnectedAsync()
        {
            _manager.AddConnection()
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
    }
}
