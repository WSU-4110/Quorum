using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuorumDB.Models;

namespace QuorumDB
{
    public interface IReplyData
    {
        Task<List<ForumReply>> GetForumReplies();
    }
}