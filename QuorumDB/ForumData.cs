using QuorumDB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace QuorumDB
{
    public class ForumData : IForumData
    {
        private readonly IDbAccess _db;

        public ForumData(IDbAccess db)
        {
            _db = db;
        }

        public Task<List<Forum>> GetForums()
        {
            string sql = "select * from dbo.Forums";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

        //HARD CODED 
        public Task<List<Forum>> GetQuorumHomePage()
        {
            string sql = "select * from dbo.Forums where ForumID = 3";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

        //HARD CODED
        public Task<List<Forum>> GetSearchQuorum(string input)
        {
            string sql = "DECLARE @Keyword AS VARCHAR(100) SET @Keyword = '" + input + "' select* from dbo.Forums where dbo.Forums.Title = @Keyword OR dbo.Forums.Description = @Keyword";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

        //HARD CODED
        public Task<List<Forum>> GetSearchSection(string input)
        {
            string sql = "select * from dbo.Forums where ForumID = 3 AND dbo.Forums.Title = '" + input + "';";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

        public Task<List<Forum>> GetSearchURL(string input)
        {
            string sql = "select * from dbo.Forums where dbo.Forums.Url = '" + input + "';";
            return _db.LoadData<Forum, dynamic>(sql, new { });
        }

        //HARD CODED
        /*public Task<List<AspNetUser>> GetSearchPost()
        {
            string input = "Arts"; // Set this to an input
            string sql = "select * from dbo.Forums where ForumID = 3 AND dbo.Forums.Title = '" + input + "';";
            return _db.LoadData<AspNetUser, dynamic>(sql, new { });
        }*/
    }
}
