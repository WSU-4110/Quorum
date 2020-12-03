using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuorumDB.Models;

namespace QuorumDB
{
    public interface IThreadData
    {
        Task<List<ForumThread>> GetForumThreads();
        Task<List<ForumThread>> GetThreadById(int id);
        Task<List<ForumThread>> GetThreadsByForumId(int id);
        Task<List<ForumThread>> GetRecentActivity();
        Task<List<ForumThread>> GetTopThreads();
        Task IncreaseViewCountById(int id);
    }
}