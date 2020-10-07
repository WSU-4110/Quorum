﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace QuorumDB
{
    public class UserData : IUserData
    {
        private readonly IDbAccess _db;

        public UserData(IDbAccess db)
        {
            _db = db;
        }

        public Task<List<IdentityUser>> GetUsers()
        {
            string sql = "select * from dbo.AspNetUsers";
            return _db.LoadData<IdentityUser, dynamic>(sql, new { });
        }
    }
}
