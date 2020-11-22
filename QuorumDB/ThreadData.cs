using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuorumDB.Models;

namespace QuorumDB
{
    public class ThreadData : IThreadData
    {
        private readonly IDbAccess _db;

        public ThreadData(IDbAccess db)
        {
            _db = db;
        }

        public Task<List<ForumThread>> GetForumThreads()
        {
            string sql = "select * from dbo.ForumThreads";
            return _db.LoadData<ForumThread, dynamic>(sql, new { });
        }

        public Task<List<ForumThread>> GetThreadById(int id)
        {
            string sql = $"select * from dbo.ForumThreads where Id = @Id";
            return _db.LoadData<ForumThread, dynamic>(sql, new { Id = id });
        }

        public Task<List<ForumThread>> GetThreadByForumId(int id)
        {
            string sql = $"select * from dbo.ForumThreads where ForumId = @Id";
            return _db.LoadData<ForumThread, dynamic>(sql, new { Id = id });
        }
    }
}
