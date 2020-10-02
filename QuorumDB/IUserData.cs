using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuorumDB
{
    public interface IUserData
    {
        Task<List<IdentityUser>> GetUsers();
    }
}