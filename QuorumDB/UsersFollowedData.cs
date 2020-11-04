using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuorumDB.Models;

namespace QuorumDB
{
    public class UsersFollowedData : IUsersFollowedData
    {
        private readonly IDbAccess _db;

        public UsersFollowedData(IDbAccess db)
        {
            _db = db;
        }

        public Task<List<UsersFollowed>> GetUsersFollowed()
        {
            string sql = "select * from dbo.AspNetUsers";
            return _db.LoadData<UsersFollowed, dynamic>(sql, new { });
        }
    }
}
