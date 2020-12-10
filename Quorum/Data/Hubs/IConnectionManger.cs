using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Data.Hubs
{
    public interface IConnectionManger
    {
        void AddConnection(string username, string circuitId);
        void RemoveConnection(string circuitId);
        HashSet<string> GetConnections (string username);
        List<string> OnlineUsers { get; }
    }
}
