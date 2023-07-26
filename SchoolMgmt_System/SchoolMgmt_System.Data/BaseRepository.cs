using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SchoolMgmt_System.Model.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Data
{
    public class BaseRepository
    {
        #region Fields
        public readonly IOptions<DataConfig> ConnectionString;
        public readonly IConfiguration configuration;
        #endregion

        #region Constructure
        public BaseRepository(IOptions<DataConfig> ConnectionString, IConfiguration configuration=null)
        {
            this.configuration = configuration;
        }
        #endregion

        #region SQL Methods
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql,object param=null,IDbTransaction transaction=null,int? commandTimeout = null,CommandType? commandType =null)
        {
            string connString = ConfigurationExtensions.GetConnectionString(this.configuration, "DefaultConnection");
            using (SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<T>(sql, param,commandType : CommandType.StoredProcedure);
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


        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            string connString = ConfigurationExtensions.GetConnectionString(this.configuration, "DefaultConnection");
            using (SqlConnection conn = new SqlConnection(connString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion

    }
}
