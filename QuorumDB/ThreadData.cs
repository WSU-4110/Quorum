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

        public ThreadData()
        {
        }

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

        public Task<List<ForumThread>> GetRecentActivity()
        {
            string sql = $"select top 10 * from dbo.ForumThreads where ID in(" +
                            "select ThreadID " +
                            "from dbo.ForumReplies " +
                            "group by ThreadID " +
                            "order by max(CreatedTime) DESC offset 0 rows);";
            return _db.LoadData<ForumThread, dynamic>(sql, new { });
        }

        public Task<List<ForumThread>> GetTopThreads()
        {
            string sql = @" Select top 5 * from [dbo].[ForumThreads]
                            order by ViewCount DESC";
            return _db.LoadData<ForumThread, dynamic>(sql, new { });
        }

        public async Task IncreaseViewCountById(int id)
        {
            string sql = "update dbo.ForumThreads set ViewCount=ViewCount+1 where id = @Id";
            await _db.Execute<dynamic>(sql, new { Id = id });
        }
    }
}
