using Microsoft.AspNetCore.Components.Server.Circuits;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Data.Hubs
{
    public class ConnectionManager : IConnectionManager
    {
        // Relationship between users -> many connection ids
        private static ConcurrentDictionary<string, HashSet <Circuit> > userMap = new ConcurrentDictionary<string, HashSet<Circuit>>();
        // Relationship between circuit -> user
        private static ConcurrentDictionary<Circuit, string> usersByClientId = new ConcurrentDictionary<Circuit, string>();

        public List<string> OnlineUsers => throw new NotImplementedException();

        public void AddConnection(string username, Circuit circuit)
        {
            try
            {
                if (userMap.ContainsKey(username) == false)
                {
                    userMap[username] = new HashSet<Circuit>();
                }
                userMap[username].Add(circuit);
                usersByClientId.TryAdd(circuit, username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public HashSet<Circuit> GetConnections(string username)
        {
            var connections = new HashSet<Circuit>();
            try
            {
                connections = userMap[username];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return connections;
        }

        public void RemoveConnection(Circuit circuit)
        {
            try
            {
                string username = "unknown";
                if (usersByClientId.TryGetValue(circuit, out string userName))
                    username = userName;

                if (userMap.ContainsKey(username) == true)
                {
                    userMap[username].Remove(circuit);
                    if (userMap[username].Count == 0)
                        userMap.TryRemove(userName, out var _);
                }
                usersByClientId.TryRemove(circuit, out var _);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
