using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoreProject.Model.Config;
using TrainingCoreProject.Model.ViewModels.User;
using System.Data;

namespace TrainingCoreProject.Data.DBRepository.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        #region Fields
        public readonly IConfiguration configuration;
        #endregion

        #region Constructor
        public UserRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig,configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region Login user
        public async Task<UserModel> LoginUser(LoginModel loginModel)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Email", loginModel.Email);
            parameter.Add("@Password",loginModel.Password);
            var data = await QueryFirstOrDefaultAsync<UserModel>("Sp_LoginUser", parameter, commandType: CommandType.StoredProcedure);
            return data;
        }

        #endregion

        #region RegisterUser

        public async Task<int> RegisterUser(UserModel userModel)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", null);
            parameter.Add("@UserName", userModel.UserName);
            parameter.Add("@Email", userModel.Email);
            parameter.Add("@Password",userModel.Password);
            var data = await ExecuteAsync<int>("Sp_RegisterUser",parameter, commandType: CommandType.StoredProcedure); 
            return data;
        }

        #endregion
    }
}
