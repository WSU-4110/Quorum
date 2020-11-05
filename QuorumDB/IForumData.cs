using QuorumDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuorumDB
{
    public interface IForumData
    {
        Task<List<Forum>> GetQuorumHomePage();
        Task<List<Forum>> GetSearchQuorum(string input);
        Task<List<Forum>> GetSearchSection(string input);
        Task<List<Forum>> GetSearchURL(string input);
    }
}