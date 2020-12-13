using Microsoft.AspNetCore.SignalR.Client;
using QuorumDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Data.Hubs
{
    public class ChatClient : IAsyncDisposable
    {  
        private readonly string _hubUrl;
        private HubConnection _hubConnection;
        private string _username;

        public ChatClient(string username, string siteUrl)
        {
            if (string.IsNullOrWhiteSpace(siteUrl))
                throw new ArgumentNullException(nameof(siteUrl));
            // set the hub URL
            _hubUrl = siteUrl.TrimEnd('/') + ChatHub.HubUrl;
            _username = username;
        }

        private bool _started = false;

        public async Task StartAsync()
        {
            if (!_started)
            {
                // create the connection using the .NET SignalR client
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(_hubUrl)
                    .Build();
                Console.WriteLine("ChatClient: calling Start()");

                // add handler for receiving messages
                _hubConnection.On<Message>(MessageFunctions.RECEIVE, (message) =>
                {
                    HandleReceiveMessage(message);
                });

                _hubConnection.On(MessageFunctions.USEREVENT, () =>
                {
                    UserEvent?.Invoke(this, EventArgs.Empty);
                });

                // start the connection
                await _hubConnection.StartAsync();

                Console.WriteLine("ChatClient: Start returned");
                _started = true;

                // register user on hub to let other clients know they've joined
                await _hubConnection.SendAsync(MessageFunctions.REGISTER, _username);
            }
        }

        /// <summary>
        /// Handle an inbound message from a hub
        /// </summary>
        /// <param name="method">event name</param>
        /// <param name="message">message content</param>
        private void HandleReceiveMessage(Message message)
        {
            // raise an event to subscribers
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        } 
        
        /// <summary>
        /// Event raised when this client receives a message
        /// </summary>
        /// <remarks>
        /// Instance classes should subscribe to this event
        /// </remarks>
        public event MessageReceivedEventHandler MessageReceived;

        public event EventHandler UserEvent;

        /// <summary>
        /// Send a message to the hub
        /// </summary>
        public async Task SendAsync(Message message)
        {
            // check we are connected
            if (!_started)
                throw new InvalidOperationException("Client not started");
            // send the message
            await _hubConnection.SendAsync(MessageFunctions.SEND, message);
        }

        public async ValueTask DisposeAsync()
        {
            Console.WriteLine("ChatClient: Disposing");
            await StopAsync();
        }

        public async Task StopAsync()
        {
            if (_started)
            {
                // disconnect the client
                //await _hubConnection.SendAsync(MessageFunctions.DISCONNECT);
                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();

                _hubConnection = null;
                _started = false;
            }
        }
    }

    /// <summary>
    /// Delegate for the message handler
    /// </summary>
    /// <param name="sender">the SignalRclient instance</param>
    /// <param name="e">Event args</param>
    public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);

    /// <summary>
    /// Message received argument class
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs
    {
        public MessageReceivedEventArgs(Message message)
        {
            Message = message;
        }

        public Message Message { get; set; }
    }
}
