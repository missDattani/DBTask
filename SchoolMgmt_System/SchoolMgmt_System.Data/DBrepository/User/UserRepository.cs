using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SchoolMgmt_System.Common.Helpers;
using SchoolMgmt_System.Model.Config;
using SchoolMgmt_System.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Data.DBrepository.User
{
    public class UserRepository :BaseRepository, IUserRepository
    {
        #region Field
        public IConfiguration _Configuration;
        #endregion
        #region Constructor
        public UserRepository(IConfiguration configuration, IOptions<DataConfig> dataconfig) : base(dataconfig, configuration)
        {
            _Configuration = configuration;
        }

        public async Task<UserModel> CheckUser(UserModel userModel)
        {
            var param = new DynamicParameters();
            param.Add("@UserName", userModel.Email);
            return await QueryFirstOrDefaultAsync<UserModel>(StoredProcedures.CheckUser, param, commandType: CommandType.StoredProcedure);
        }


		public async Task<ForgotData> GetUserDetailsByEmail(ForgotData userData)
		{
			var param = new DynamicParameters();
			param.Add("@Email", userData.Email);
			return await QueryFirstOrDefaultAsync<ForgotData>(StoredProcedures.GetUserDetailsByEmail, param, commandType: CommandType.StoredProcedure);
		}
		#endregion
		public async Task<UserModel> LoginUser(LoginModel loginModel)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@UserEmail", loginModel.Email);
            parameter.Add("@Password", loginModel.Password);
            var data = await QueryFirstOrDefaultAsync<UserModel>(StoredProcedures.UserLogin, parameter, commandType: CommandType.StoredProcedure);
            return data;
        }

        public async Task<int> RegisterUser(UserModel user)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@FirstName", user.FirstName);
            parameter.Add("@LastName", user.LastName);
            parameter.Add("@Email", user.Email);
            parameter.Add("@Password", user.Password);
            var data = await ExecuteAsync<int>(StoredProcedures.UserInfo, parameter, commandType: CommandType.StoredProcedure);
            return data;
        }
    }
}
