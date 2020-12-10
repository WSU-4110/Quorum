using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.Circuits;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Identity;
using QuorumDB.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;

namespace Quorum.Services
{
    public class TrackingCircuitHandler : CircuitHandler
    {
        // Relationship between users -> many connection ids
        private static ConcurrentDictionary<string, HashSet <Circuit> > userMap = new ConcurrentDictionary<string, HashSet <Circuit> >();
        // Relationship between circuit -> user
        private static ConcurrentDictionary<Circuit, string> usersByClientId = new ConcurrentDictionary<Circuit, string>();

        public int GetConnectedCircuitsCount()
        {
            return usersByClientId.Count;
        }

        public event EventHandler CircuitsChanged;
        public event EventHandler MessageEvent;

        public SignInManager<AspNetUser> Manager { get; }
        public IHttpContextAccessor _httpClient { get; }

        public TrackingCircuitHandler(IHttpContextAccessor httpClient)
        {
            _httpClient = httpClient;
        }

         protected virtual void OnCircuitsChanged()
        {
            CircuitsChanged?.Invoke(this, EventArgs.Empty);
        }

        public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine($"Id: {circuit.Id} is null : {_httpClient == null} ");
                //bool isAuthenticated = _httpClient != null ? _httpClient.HttpContext.User.Identity.IsAuthenticated : false ;
                bool isAuthenticated = false;
                string username = "unknown";
                if (isAuthenticated == true)
                    username = _httpClient.HttpContext.User.Identity.Name;

                if (userMap.ContainsKey(username) == false)
                {
                    userMap[username] = new HashSet<Circuit>();
                }
                userMap[username].Add(circuit);
                usersByClientId.TryAdd(circuit, username);

                OnCircuitsChanged();
                return base.OnConnectionUpAsync(circuit, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Task.FromException(e);
            }
        }

        public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            try
            {
                string username = "unknown";
                if(usersByClientId.TryGetValue(circuit, out string userName)) 
                    username = userName;       

                if (userMap.ContainsKey(username) == true)
                {
                    userMap[username].Remove(circuit);
                    if (userMap[username].Count == 0)
                        userMap.TryRemove(userName, out var _);
                }


                usersByClientId.TryRemove(circuit, out var _);

                OnCircuitsChanged();
                return base.OnConnectionDownAsync(circuit, cancellationToken);
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
                return Task.FromException(e);
            }
        }

        public HashSet<Circuit> GetUserConnections(string uname)
        {
            var connections = new HashSet<Circuit>();
            try
            {
                connections = userMap[uname];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return connections;
        }

        public List<string> GetAllUsers()
        {
            return userMap.Keys.ToList();
        }

        public void SendNotification(string uname)
        {
            var connections = GetUserConnections(uname);

            foreach(var connection in connections)
            {
                try
                {
                    await 
                }
            }
        }

    }
}