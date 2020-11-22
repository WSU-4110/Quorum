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
        Task<List<ForumReply>> GetRepliesByThreadId(int id);
    }
}