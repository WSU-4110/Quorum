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
            string sql = "select * from dbo.AspNetUsers";
            return _db.LoadData<ForumThread, dynamic>(sql, new { });
        }
    }
}
