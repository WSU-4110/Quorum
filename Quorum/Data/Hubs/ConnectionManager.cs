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
                    Console.WriteLine($"\nmaking hashmap for {username}");
                    userMap[username] = new HashSet<string>();
                }
                Console.WriteLine($"adding {username} to hashmap with id {circuit}");
                userMap[username].Add(circuit);
                usersByClientId[circuit] = username;

                Console.WriteLine($"Usermap count: {userMap[username].Count}, usersByClientId count: {usersByClientId.Count}");
                foreach (var connection in userMap[username])
                {
                    Console.WriteLine($"{username} : {connection}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e.StackTrace);
            }
        }

        public HashSet<string> GetConnections(string username)
        {
            var connections = new HashSet<string>();
            try
            {
                connections = userMap[username].ToHashSet();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var connection in connections)
            {
                Console.WriteLine($"returning {username} : {connection}");
            }
            Console.WriteLine();
            return connections;
        }

        public void RemoveConnection(string circuit)
        {
            try
            {
                string username = "unknown";
                if (usersByClientId.TryGetValue(circuit, out string userName))
                    username = userName;

                Console.WriteLine($"\nRemoving {username} from hashmap with id {circuit}");
                if (userMap.ContainsKey(username) == true)
                {
                    userMap[username].Remove(circuit);
                    if (userMap[username].Count == 0)
                    {
                        Console.WriteLine($"\nRemoving hashmap. User count: {userMap[username].Count}. {username} with id {circuit}");
                        // TODO : Make sure this fucntions correctly 
                        userMap.TryRemove(userName, out var _);
                    }
                    Console.WriteLine($"Removing usersByClientId.");
                    usersByClientId.Remove(circuit, out var _);
                }
                //Console.WriteLine($"Usermap count: {userMap[username].Count}, usersByClientId count: {usersByClientId.Count}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e.StackTrace);
            }
        }

        public int UserCount()
        {
            return usersByClientId.Count;
        }
    }
}
