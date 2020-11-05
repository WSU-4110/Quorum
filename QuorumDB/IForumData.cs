using QuorumDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuorumDB
{
    public interface IForumData
    {
        Task<List<Forum>> GetForums();
        Task<List<Forum>> GetQuorumHomePage();
        Task<List<Forum>> GetSearchQuorum(string input);
        Task<List<Forum>> GetSearchSection(string input);
        Task<List<Forum>> GetForumByURL(string input);
        Task<List<string>> GetCurrentForumID(string input);
        Task<List<string>> GetForumURL(int Id);
    }
}