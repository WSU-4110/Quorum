using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuorumDB.Models;

namespace QuorumDB
{
    public class ForumData : IForumData
    {
        private readonly IDbAccess _db;

        public ForumData(IDbAccess db)
        {
            _db = db;
        }

        public Task<List<Forum>> GetQuorums()
        {
            string sql = "select * from dbo.Forums";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

    }
}
