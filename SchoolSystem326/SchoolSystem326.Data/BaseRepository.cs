using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SchoolSystem326.Model.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SchoolSystem326.Data
{
    public class BaseRepository
    {
        public readonly IOptions<DataConfig> ConnectionString;
        public readonly IConfiguration configuration;

        public BaseRepository(IOptions<DataConfig> connectionString, IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql,object param = null,IDbTransaction transaction = null,int? CommandTimeout=null,CommandType? commandType = null)
        {
            string connString = ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection");
            using(SqlConnection connection = new SqlConnection(connString)) 
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? CommandTimeout = null, CommandType? commandType = null)
        {
            string connString = ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection");
            using (SqlConnection connection = new SqlConnection(connString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> ExecuteAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            string conString = ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection");
            using (SqlConnection _db = new SqlConnection(conString))
            {
                await _db.OpenAsync();
                return await _db.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
