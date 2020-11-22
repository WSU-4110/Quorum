using QuorumDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuorumDB
{
    public interface IUserData
    {
        Task<List<AspNetUser>> GetUsers();
        Task<List<AspNetUser>> GetUserById(string Id);
        Task<List<AspNetUser>> GetUserByUserName(string userName);
    }
}