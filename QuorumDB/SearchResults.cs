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

        public Task<List<SearchResults>> GetSearchResultsByQuorum(string keyword)
        {
            string sql = "SELECT Title FROM dbo.Forums WHERE dbo.Forums.Title LIKE '@Keyword'";
            return _db.LoadData<SearchResults, dynamic>(sql, new { Keyword = keyword });
        }

        public Task<List<SearchResults>> GetSearchResultsByPost(string keyword)
        {
            string sql = "SELECT Title FROM dbo.ForumThreads WHERE dbo.ForumThreads.Title LIKE '@Keyword'";
            return _db.LoadData<SearchResults, dynamic>(sql, new { Keyword = keyword });
        }
    }
}
