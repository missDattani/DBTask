using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAllOverTopics.Common.Helpers;
using WebApplicationAllOverTopics.Model.Config;
using WebApplicationAllOverTopics.Model.ViewModel;

namespace WebApplicationAllOverTopics.Data.DBRepository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        #region Fields
        private readonly IConfiguration configuration;
        #endregion

        #region Constructor
        public UserRepository(IConfiguration configuration, IOptions<DataConfig> dataConfig) : base(dataConfig, configuration)
        {
            this.configuration = configuration;
        }
        #endregion
        public async Task<int> AddEditUser(UserModel userModel)
        {
            if (userModel.Id == 0)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", null);
                parameter.Add("@Name", userModel.Name);
                parameter.Add("@Email", userModel.Email);
                parameter.Add("@Password", userModel.Password);
                parameter.Add("@RoleName", userModel.RoleName);
                return await ExecuteAsync<int>(StoredProcedures.AddUser, parameter, commandType: CommandType.StoredProcedure);
            }
            else
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", userModel.Id);
                parameter.Add("@Name", userModel.Name);
                parameter.Add("@Email", userModel.Email);
                parameter.Add("@Password", userModel.Password);
                parameter.Add("@RoleName", userModel.RoleName);
                return await ExecuteAsync<int>(StoredProcedures.AddUser, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<UserModel>> GetUsers()
        {
           var result = await QueryAsync<UserModel>(StoredProcedures.AllUsers, commandType: CommandType.StoredProcedure); 
            return result.ToList();
        }

        public async Task<UserModel> UserLogin(LoginModel loginModel)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Email", loginModel.Email);
            parameter.Add("@Password", loginModel.Password);
            var data = await QueryFirstOrDefaultAsync<UserModel>(StoredProcedures.LoginUser, parameter, commandType: CommandType.StoredProcedure);
            return data;
        }
    }
}

