using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace QuorumDB
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionString { get; set; } = "quorumDB";

        public DataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionString);

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var rows = await dbConnection.QueryAsync<T>(sql, parameters);
                return rows.ToList();
            }
        }

        public Task Execute<U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionString);

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                return dbConnection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
