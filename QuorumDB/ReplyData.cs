using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuorumDB.Models;

namespace QuorumDB
{
    public class ReplyData : IReplyData
    {
        private readonly DbAccess _db = DbAccess.GetInstance();

        public ReplyData()
        {
        }

        public Task<List<ForumReply>> GetForumReplies()
        {
            string sql = "select * from dbo.AspNetUsers";
            return _db.LoadData<ForumReply, dynamic>(sql, new { });
        }
    }
}
