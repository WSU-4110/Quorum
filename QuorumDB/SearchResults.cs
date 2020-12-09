using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuorumDB.Models;

namespace QuorumDB
{
    public class SearchResults : ISearchResults
    {
        private readonly IDbAccess _db;

        public SearchResults(IDbAccess db)
        {
            _db = db;
        }

        public Task<List<Forum>> GetSearchResultsByQuorum(string keyword)
        {
            string sql = "SELECT * FROM dbo.Forums WHERE dbo.Forums.Title LIKE '%' + @Keyword + '%'";
            return _db.LoadData<Forum, dynamic>(sql, new { Keyword = keyword });
        }

        public Task<List<ForumThread>> GetSearchResultsByPost(string keyword)
        {
            string sql = "SELECT * FROM dbo.ForumThreads WHERE dbo.ForumThreads.Title LIKE '%' + @Keyword + '%'";
            return _db.LoadData<ForumThread, dynamic>(sql, new { Keyword = keyword });
        }
    }
}
