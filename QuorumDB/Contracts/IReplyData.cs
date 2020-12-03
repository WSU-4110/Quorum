using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuorumDB.Models;

namespace QuorumDB
{
    public interface IReplyData
    {
        Task<List<ForumReply>> GetForumReplies();
        Task<List<ForumReply>> GetReplyById(int id);
        Task<List<ForumReply>> GetAllRepliesByThreadId(int id);
        Task<List<ForumReply>> GetRepliesByThreadId(int id, int page);
        Task<int> GetReplyCountByThreadId(int id);
        Task DeleteReplyById(int replyId);
        Task UpdateLastActivity(int threadId);
    }
}