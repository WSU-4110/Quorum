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
        private readonly DbAccess _db = DbAccess.GetInstance();

        public ThreadData()
        {
        }

        public Task<List<ForumThread>> GetForumThreads()
        {
            string sql = "select * from dbo.AspNetUsers";
            return _db.LoadData<ForumThread, dynamic>(sql, new { });
        }
    }
}
