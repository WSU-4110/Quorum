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
        private readonly IDbAccess _db;

        public ReplyData(IDbAccess db)
        {
            _db = db;
        }

        public Task<List<ForumReply>> GetForumReplies()
        {
            string sql = "select * from dbo.AspNetUsers";
            return _db.LoadData<ForumReply, dynamic>(sql, new { });
        }

        public Task<List<ForumReply>> GetReplyById(int id)
        {
            string sql = "select * from dbo.ForumReplies where Id = @Id";
            return _db.LoadData<ForumReply, dynamic>(sql, new { Id = id });
        }

        public Task<List<ForumReply>> GetAllRepliesByThreadId(int id)
        {
            string sql = "select * from dbo.ForumReplies where ThreadId = @Id";
            return _db.LoadData<ForumReply, dynamic>(sql, new { Id = id });
        }
        
        public Task<List<ForumReply>> GetRepliesByThreadId(int id, int page)
        {
            int rowsPerPage = 10;
            string sql = @" Select * from dbo.ForumReplies 
                            where ThreadId = @Id
                            ORDER BY(SELECT NULL)
                            OFFSET (@Page-1)*@RowsPerPage ROWS
                            FETCH NEXT @RowsPerPage ROWS ONLY";
            return _db.LoadData<ForumReply, dynamic>(sql, new { Id = id, Page = page, RowsPerPage = rowsPerPage});
        }

        public async Task<int> GetReplyCountByThreadId(int id)
        {
            string sql = "Select COUNT(*) from dbo.ForumReplies where ThreadId = @Id";

            var numList = await _db.LoadData<int, dynamic>(sql, new { Id = id });
            return numList[0];
        }

        public async Task DeleteReplyById(int id)
        {
            string sql = "delete from dbo.ForumReplies where id = @Id";
            await _db.Execute<dynamic>(sql, new { Id = id });
        }

        public async Task UpdateLastActivity(int threadId)
        {
            string sql = "update dbo.ForumThreads set LastActivity = @Time where Id = @ThreadId";
            await _db.Execute<dynamic>(sql, new { Time = DateTimeOffset.UtcNow, ThreadId = threadId });
        }
    }
}
