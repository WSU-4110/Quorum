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
        private readonly DbAccess _db = DbAccess.GetInstance();


        public UsersFollowedData()
        {
        }

        public Task<List<UsersFollowed>> GetUsersFollowed()
        {
            string sql = "select * from dbo.AspNetUsers";
            return _db.LoadData<UsersFollowed, dynamic>(sql, new { });
        }
    }
}
