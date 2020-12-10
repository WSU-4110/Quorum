using Microsoft.AspNetCore.Components.Server.Circuits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quorum.Data.Hubs
{
    public interface IConnectionManager
    {
        void AddConnection(string username, Circuit circuit);

        void RemoveConnection(Circuit circuit);

        HashSet<Circuit> GetConnections (string username);

        List<string> OnlineUsers { get; }
    }
}
