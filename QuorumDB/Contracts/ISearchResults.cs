using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuorumDB.Models;

namespace QuorumDB
{
    public interface ISearchResults
    {
        Task<List<SearchResults>> GetSearchResultsByPost(string keyword);
        Task<List<SearchResults>> GetSearchResultsByQuorum(string keyword);
    }
}