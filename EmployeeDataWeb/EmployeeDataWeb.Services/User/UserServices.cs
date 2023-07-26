using EmployeeDataWeb.Data.DBRepository.User;
using EmployeeDataWeb.Model.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.User
{
    public class UserServices : IUserServices
    {
        #region Fields
        public readonly IUserRepository userRepository;
        #endregion

        #region Constructor
        public UserServices(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region Methods

        public async Task<UserModel> LoginUser(LoginModel loginModel)
        {
            return await userRepository.LoginUser(loginModel);
        }

        public async Task<int> UpdatePassword(string Email, string Password)
        {
           return await userRepository.UpdatePassword(Email, Password);
        }
        public async Task<UserModel> GetUserByEmail(string Email)
        {
            return await userRepository.GetUserByEmail(Email);
        }

        public async Task<int> VerifyOTP(int otp, string Email)
        {
            return await userRepository.VerifyOTP(otp, Email);
        }

        public async Task<int> UpdateOTP(int otp, int Id)
        {
            return await userRepository.UpdateOTP(otp, Id);
        }

        public async Task<int> UpdateTokenData(string token, int Id)
        {
            return await userRepository.UpdateTokenData(token, Id);
        }

        public async Task<int> ValidateToken(int Id, string token, DateTime TokenValidDate)
        {
           return await userRepository.ValidateToken(Id, token, TokenValidDate);
        }
        #endregion
    }
}
