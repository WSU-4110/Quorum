using QuorumDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuorumDB
{
    public interface IForumData
    {
        Task<List<Forum>> GetAllForums();
        Task<List<Forum>> GetForumsByParentId(int Id);
        Task<List<Forum>> GetQuorumHomePage();
        Task<List<Forum>> GetSearchQuorum(string input);
        Task<List<Forum>> GetSearchSection(string input);
        Task<List<Forum>> GetForumByURL(string input);
        Task<List<int>> GetCurrentForumID(string input);
        Task<List<string>> GetForumURL(int Id);
    }
}