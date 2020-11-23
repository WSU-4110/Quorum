using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuorumDB
{
    public interface IUsersFollowedData
    {
        Task FollowUser(string userName, string userFollowed);
        Task<List<string>> GetUsersFollowed(string userName);
        Task<int> GetUsersFollowedCount(string userName);
        Task UnfollowUser(string userName, string userUnfollowed);
    }
}