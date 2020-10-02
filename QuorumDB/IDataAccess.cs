using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuorumDB
{
    public interface IDataAccess
    {
        Task Execute<U>(string sql, U parameters);
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
    }
}