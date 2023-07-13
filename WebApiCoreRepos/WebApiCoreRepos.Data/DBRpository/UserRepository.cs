using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCoreRepos.Common.Helpers;
using WebApiCoreRepos.Model.Config;
using WebApiCoreRepos.Model.ViewModel;

namespace WebApiCoreRepos.Data.DBRpository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        #region Fields
        public IConfiguration configuration;
        #endregion

        #region Controller
        public UserRepository(IConfiguration configuration, IOptions<DataConfig> dataConfig) : base(dataConfig, configuration)
        {
            this.configuration = configuration;
        }

  
        #endregion

        #region Method
        public async Task<UserModel> LoginUser(LoginModel loginModel)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Email", loginModel.EMAIL);
            parameter.Add("@Password", loginModel.PASSWORD);
            var data = await QueryFirstOrDefaultAsync<UserModel>(StoredProcedures.UserLogin, parameter,commandType:CommandType.StoredProcedure);
            return data;
        }

        public async Task<int> RegisterUser(UserModel userModel)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Name", userModel.NAME);
            parameter.Add("@Email",userModel.EMAIL);
            parameter.Add("@Password", userModel.PASSWORD);
            return await ExecuteAsync<int>(StoredProcedures.UserRegister,parameter,commandType:CommandType.StoredProcedure);
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var data = await QueryAsync<UserModel>(StoredProcedures.UserData, commandType:CommandType.StoredProcedure);
            return data.ToList();
        }
        #endregion
    }
}
