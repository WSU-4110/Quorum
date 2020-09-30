using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QuorumDB
{
    public class DataAccess : IDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                var rows = await dbConnection.QueryAsync<T>(sql, parameters);
                return rows.ToList();
            }
        }

        public Task Execute<U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                var rows = dbConnection.ExecuteAsync(sql, parameters);
                return rows;
            }
        }
    }
}
