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
            string sql = $"select * from dbo.ForumThreads where Id = '{id}'";
            return _db.LoadData<ForumThread, dynamic>(sql, new { });
        }

        public Task<List<ForumThread>> GetThreadsByForumId(int id)
        {
            string sql = $"select * from dbo.ForumThreads where ForumId = '{id}'";
            return _db.LoadData<ForumThread, dynamic>(sql, new { });
        }

        public async Task IncreaseViewCountById(int id)
        {
            string sql = "update dbo.ForumThreads set ViewCount=ViewCount+1 where id = @Id";
            await _db.Execute<dynamic>(sql, new { Id = id });
        }
    }
}
