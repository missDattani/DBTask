using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SchoolSystem326.Common.Helper;
using SchoolSystem326.Model.Config;
using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Data.DBRepository.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        #region Fields
        public IConfiguration configuration;
        #endregion

        #region Constructor
        public UserRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig,configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region Methods
        public async Task<UserModel> LoginUser(LoginModel loginModel)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Email", loginModel.Email);
            parameter.Add("@Password",loginModel.Password);
            return await QueryFirstOrDefaultAsync<UserModel>(StoredProcedures.UserLogin, parameter, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> RegisterUser(UserModel userModel)
        {
            if(userModel.Id == 0)
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", null);
                parameter.Add("@FName", userModel.FirstName);
                parameter.Add("@LName", userModel.LastName);
                parameter.Add("@Address", userModel.Address);
                parameter.Add("@Gender", userModel.Gender);
                parameter.Add("@DOB", userModel.DOB);
                parameter.Add("@Role", userModel.Role);
                parameter.Add("@Mobile", userModel.MobileNo);
                parameter.Add("@Email", userModel.Email);
                parameter.Add("@Password", userModel.Password);
                parameter.Add("@CoId", userModel.CountryId);
                parameter.Add("@StId", userModel.StateId);
                parameter.Add("@CiId", userModel.CityId);
                var data = await ExecuteAsync<int>(StoredProcedures.RegisterUser, parameter, commandType: CommandType.StoredProcedure);
                return data;
            }
            else
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", userModel.Id);
                parameter.Add("@FName", userModel.FirstName);
                parameter.Add("@LName", userModel.LastName);
                parameter.Add("@Address", userModel.Address);
                parameter.Add("@Gender", userModel.Gender);
                parameter.Add("@DOB", userModel.DOB);
                parameter.Add("@Role", userModel.Role);
                parameter.Add("@Mobile", userModel.MobileNo);
                parameter.Add("@Email", userModel.Email);
                parameter.Add("@Password", userModel.Password);
                parameter.Add("@CoId", userModel.CountryId);
                parameter.Add("@StId", userModel.StateId);
                parameter.Add("@CiId", userModel.CityId);
                var data = await ExecuteAsync<int>(StoredProcedures.RegisterUser, parameter, commandType: CommandType.StoredProcedure);
                return data;
            }
          
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
          var user = await QueryAsync<UserModel>(StoredProcedures.GetUsers,commandType:CommandType.StoredProcedure);
            return user.ToList();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);
            return await QueryFirstOrDefaultAsync<UserModel>(StoredProcedures.GetUserById, parameter, commandType: CommandType.StoredProcedure);
        }
        #endregion
    }
}
