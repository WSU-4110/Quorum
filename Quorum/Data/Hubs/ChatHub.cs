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
            Console.WriteLine($"\n{Context.ConnectionId} connected");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"\nDisconnected {Context.ConnectionId} {e?.Message}");
            _manager.RemoveConnection(Context.ConnectionId);
            await Clients.AllExcept(Context.ConnectionId).SendAsync(MessageFunctions.USEREVENT);
            Console.WriteLine($"\n{e?.StackTrace}");
            await base.OnDisconnectedAsync(e);
        }

        public async Task Register(string username)
        {
            Console.WriteLine($"Trying to add {username} with id: {Context.ConnectionId}");
            _manager.AddConnection(username, Context.ConnectionId);
            await Clients.All.SendAsync(MessageFunctions.USEREVENT);
        }

        public async Task SendMessage(Message message)
        {
            try {
                HashSet<string> toConnections = _manager.GetConnections(message.ToUserName).ToHashSet();
                HashSet<string> fromConnections = _manager.GetConnections(message.FromUserName).ToHashSet();

                //Include yourself
                foreach(var connection in toConnections)
                {
                    Console.WriteLine($"To {message.ToUserName} with id: {connection}");
                }
                foreach (var connection in fromConnections)
                {
                    Console.WriteLine($"From {message.FromUserName} with id: {connection}");
                }
                toConnections.UnionWith(fromConnections);
                await Clients.Clients(toConnections).SendAsync(MessageFunctions.RECEIVE, message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e.StackTrace);
            }
        }

        public async Task BroadcastMessage(string message)
        {
            await Clients.All.SendAsync(MessageFunctions.BROADCAST, message);
        }
    }
}
