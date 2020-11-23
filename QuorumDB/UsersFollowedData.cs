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

        public async Task FollowUser(string userName, string userFollowed)
        {
            string sql = "Insert into dbo.UsersFollowed(UserId, FollowedUserId) values (@UserName, @UserFollowed)";
            await _db.Execute<dynamic>(sql, new { UserName = userName, UserFollowed = userFollowed });
        }

        public async Task UnfollowUser(string userName, string userUnfollowed)
        {
            string sql = "Insert into dbo.UsersFollowed(UserId, FollowedUserId) values (@UserName, @UserUnfollowed)";
            await _db.Execute<dynamic>(sql, new { UserName = userName, UserUnfollowed = userUnfollowed });
        }

        public Task<List<string>> GetUsersFollowed(string userName)
        {
            string sql = "select FollowedUserId from dbo.UsersFollowed where UserId = @UserName";
            return _db.LoadData<string, dynamic>(sql, new { UserName = userName });
        }

        public async Task<int> GetUsersFollowedCount(string userName)
        {
            string sql = "Select COUNT(*) from dbo.UsersFollowed where UserId = @UserName";
            var result = await _db.LoadData<int, dynamic>(sql, new { UserName = userName });
            if (result.Count > 0)
            {
                return result[0];
            }
            return 0;
        }
    }
}
