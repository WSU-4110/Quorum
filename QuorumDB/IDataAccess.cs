using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuorumDB
{
    public interface IDataAccess
    {
        Task Execute<U>(string sql, U parameters, string connectionString);
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString);
    }
}