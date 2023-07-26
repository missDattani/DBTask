using Dapper;
using EmployeeDataWeb.Common.Helpers;
using EmployeeDataWeb.Model.Config;
using EmployeeDataWeb.Model.ViewModels.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Data.DBRepository.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        #region Fields
        private readonly IConfiguration configuration;
        #endregion

        #region Constructor
        public UserRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig, configuration) 
        {
            this.configuration = configuration;
        }

     
        #endregion
        public async Task<UserModel> LoginUser(LoginModel login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Email", login.Email);
            parameter.Add("@Password", login.Password);
            var data = await QueryFirstOrDefaultAsync<UserModel>(StoredProcedures.UserLogin, parameter,commandType:CommandType.StoredProcedure);
            return data;
        }

        public async Task<int> UpdatePassword(string Email, string Password)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Email", Email);
            parameter.Add("@NewPassword", Password);
            var data = await QueryFirstOrDefaultAsync<int>(StoredProcedures.ChangePassword,parameter,commandType:CommandType.StoredProcedure); 
            return data;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Email", email);
            var data = await QueryFirstOrDefaultAsync<UserModel>(StoredProcedures.GetUserByEmail,parameter,commandType:CommandType.StoredProcedure); 
            return data;
        }

        public async Task<int> VerifyOTP(int otp, string Email)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@OTP", otp);
            parameter.Add("@Email", Email);
            var data = await QueryFirstOrDefaultAsync<int>(StoredProcedures.VerifyOTP,parameter,commandType:CommandType.StoredProcedure); 
            return data;
        }

        public async Task<int> UpdateOTP(int otp, int Id)
        {
           var parameter = new DynamicParameters();
            parameter.Add("@Id", Id);
            parameter.Add("@OTP", otp);
            var data = await ExecuteAsync<int>(StoredProcedures.UpdateOTP,parameter, commandType:CommandType.StoredProcedure);
            return data;
        }

        public async Task<int> UpdateTokenData(string token, int Id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", Id);
            parameter.Add("@Token", token);
            var data = await ExecuteAsync<int>(StoredProcedures.UpdateToken,parameter, commandType:CommandType.StoredProcedure);
            return data;
        }

        public async Task<int> ValidateToken(int Id, string token, DateTime TokenValidDate)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", Id);
            parameter.Add("@Token", token);
            parameter.Add("@TokenDate", TokenValidDate);
            var data = await QueryFirstOrDefaultAsync<int>(StoredProcedures.ValidateToken,parameter, commandType:CommandType.StoredProcedure); 
            return data;
        }
    }
}
