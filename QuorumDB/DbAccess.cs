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
    public class DbAccess : IDbAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionString { get; set; } = "quorum";

        public DbAccess(IConfiguration config)
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

        public async Task Execute<U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionString);

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                await dbConnection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
