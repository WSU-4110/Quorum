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
        private static ConcurrentDictionary<string, HashSet<string>> userMap = new ConcurrentDictionary<string, HashSet<string>>();
        // Relationship between circuit -> user
        private static ConcurrentDictionary<string, string> usersByClientId = new ConcurrentDictionary<string, string>();

        public List<string> ListOnlineUsers => userMap.Keys.ToList();

        public void AddConnection(string username, string circuit)
        {
            try
            {
                if (userMap.ContainsKey(username) == false)
                {
                    userMap[username] = new HashSet<string>();
                }
                userMap[username].Add(circuit);
                usersByClientId.TryAdd(circuit, username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public HashSet<string> GetConnections(string username)
        {
            var connections = new HashSet<string>();
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

        public void RemoveConnection(string circuit)
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

        public int UserCount()
        {
            return usersByClientId.Count;
        }
    }
}
