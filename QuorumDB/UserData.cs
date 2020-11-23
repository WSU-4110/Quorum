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

        public Task<List<AspNetUser>> GetUsers()
        {
            string sql = "select * from dbo.AspNetUsers";
            return _db.LoadData<AspNetUser, dynamic>(sql, new { });
        }

        public Task<List<AspNetUser>> GetUserById(string id)
        {
            string sql = "Select * from dbo.AspNetUsers where Id = @Id";
            return _db.LoadData<AspNetUser, dynamic>(sql, new { Id = id });
        }

        public Task<List<AspNetUser>> GetUserByUserName(string userName)
        {
            string sql = "Select * from dbo.AspNetUsers where UserName = @UserName";
            return _db.LoadData<AspNetUser, dynamic>(sql, new { UserName = userName });
        }

        public Task SetUserAvatar(string userName, string url)
        {
            string sql = "update dbo.AspNetUsers set AvatarUrl = @Url where UserName = @UserName";
            return _db.Execute<dynamic>(sql, new { Url = url, UserName = userName });
        }

        public async Task<string> GetUserAvatar(string userName)
        {
            string sql = "Select AvatarUrl from dbo.AspNetUsers where UserName = @UserName";
            var list = await _db.LoadData<string, dynamic>(sql, new { UserName = userName });
            if (list.Count > 0)
            {
                return list[0];
            }
            return "";
        }
    }
}
