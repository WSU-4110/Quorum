using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuorumDB.Models;

namespace QuorumDB
{
    public class UserData
    {
        private readonly DbAccess _db = DbAccess.GetInstance();

        public static UserData instance = new UserData();

        public static UserData GetInstance()
        {
            return instance;
        }


        public UserData()
        {
        }

        public Task<List<AspNetUser>> GetUsers()
        {
            string sql = "select * from dbo.AspNetUsers";
            return _db.LoadData<AspNetUser, dynamic>(sql, new { });
        }

        public Task<List<AspNetUser>> GetUserById(int Id)
        {
            string sql = "Select * from dbo.AspNetUsers where Id=@Id";
            return _db.LoadData<AspNetUser, dynamic>(sql, new { Id = Id });
        }

        public Task<List<AspNetUser>> GetUserByUserName(string userName)
        {
            string sql = "Select * from dbo.AspNetUsers where UserName=@UserName";
            return _db.LoadData<AspNetUser, dynamic>(sql, new { UserName = userName });
        }
    }
}
