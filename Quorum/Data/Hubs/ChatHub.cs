using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuorumDB.Models;

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

        // TODO : Make the user event broadcast the user whos actually removed
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            _manager.RemoveConnection(Context.ConnectionId);
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await Clients.AllExcept(Context.ConnectionId).SendAsync(MessageFunctions.USEREVENT);
            await base.OnDisconnectedAsync(e);
        }

        public async Task Register(string username)
        {
            _manager.AddConnection(username, Context.ConnectionId);
            await Clients.AllExcept(Context.ConnectionId).SendAsync(MessageFunctions.USEREVENT);
        }

        public async Task SendMessage(Message message)
        {
            HashSet<string> connections = _manager.GetConnections(message.ToUserName);
            //Include yourself
            connections.Add(Context.ConnectionId);
            await Clients.Clients(connections).SendAsync(MessageFunctions.RECEIVE, message);
        }

        public async Task BroadcastMessage(string message)
        {
            await Clients.All.SendAsync(MessageFunctions.BROADCAST, message);
        }
    }
}
