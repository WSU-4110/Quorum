using System.Collections.Generic;

namespace Quorum.Data.Hubs
{
    public interface IConnectionManager
    {
        List<string> ListOnlineUsers { get; }

        void AddConnection(string username, string circuit);
        HashSet<string> GetConnections(string username);
        void RemoveConnection(string circuit);
        int UserCount();
    }
}