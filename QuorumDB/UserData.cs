using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuorumDB.Models;

namespace QuorumDB
{
    public class UserData : IUserData
    {
        private readonly IDbAccess _db;

        public UserData(IDbAccess db)
        {
            _db = db;
        }

        public Task< List<AspNetUser> > GetUsers()
        {
            string sql = "select * from dbo.AspNetUsers";
            return _db.LoadData<AspNetUser, dynamic>(sql, new { });
        }

        //HARD CODED 
        public Task< List<Forum> > GetQuorumHomePage()
        {
            string sql = "select * from dbo.Forums where ForumID = 3";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }
    }
}
