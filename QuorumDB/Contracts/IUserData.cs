using QuorumDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuorumDB
{
    public interface IUserData
    {
        Task<string> GetUserAvatar(string userName);
        Task<List<AspNetUser>> GetUserById(string id);
        Task<List<AspNetUser>> GetUserByUserName(string userName);
        Task<List<AspNetUser>> GetUsers();
        Task SetUserAvatar(string userName, string url);
    }
}