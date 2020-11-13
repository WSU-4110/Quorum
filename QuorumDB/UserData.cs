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

    public class GetUserDataCommand : ICommand {
        UserData userdata;

        public GetUserDataCommand(UserData userdata) {
            this.userdata = userdata;
        }

        public void Execute()
        {
            userdata.GetUsers();
        }
    }

    public class GetUserIDCommand : ICommand
    {
        UserData userdata;
        int id;

        public GetUserIDCommand(UserData userdata, int id)
        {
            this.userdata = userdata;
            this.id = id;
        }

        public void Execute()
        {
            userdata.GetUserById(id);
        }
    }

    public class GetUsernameCommand : ICommand
    {
        UserData userdata;
        string username;

        public GetUsernameCommand(UserData userdata, string username)
        {
            this.userdata = userdata;
            this.username = username;
        }

        public void Execute()
        {
            userdata.GetUserByUserName(username);
        }
    }
}
