using EmployeeDataWeb.Model.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.User
{
    public interface IUserServices
    {
        Task<UserModel> LoginUser(LoginModel loginModel);
        Task<int> UpdatePassword(string Email,string Password);

        Task<UserModel> GetUserByEmail(string Email);

        Task<int> VerifyOTP(int otp, string Email);

        Task<int> UpdateOTP(int otp,int Id);
        Task<int> UpdateTokenData(string token, int Id);

        Task<int> ValidateToken(int Id, string token, DateTime TokenValidDate);
    }
}
