using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuorumDB.Models;

namespace QuorumDB
{
    public class ForumsFollowedData : IForumsFollowedData
    {
        private readonly IDbAccess _db;

        public ForumsFollowedData(IDbAccess db)
        {
            _db = db;
        }

        public Task<List<ForumsFollowed>> GetForumsFollowed()
        {
            string sql = "select * from dbo.ForumsFollowed";
            return _db.LoadData<ForumsFollowed, dynamic>(sql, new { });
        }
    }

    public class GetFollowedCommand : ICommand
    {
        ForumsFollowedData followeddata;

        public GetFollowedCommand(ForumsFollowedData followeddata)
        {
            this.followeddata = followeddata;
        }

        public void Execute()
        {
            followeddata.GetForumsFollowed();
        }
    }
}
