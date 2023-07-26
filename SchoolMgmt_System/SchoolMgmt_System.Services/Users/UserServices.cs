using SchoolMgmt_System.Data.DBrepository.User;
using SchoolMgmt_System.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Services.Users
{
    public class UserServices : IUserServices
    {
        #region Fields
        private IUserRepository userServices;
        #endregion

        #region Constructor
        public UserServices(IUserRepository userServices) 
        {
            this.userServices = userServices;
        }
        #endregion

        #region Methods
        public async Task<UserModel> CheckUser(UserModel userModel)
        {
            return await userServices.CheckUser(userModel);
        }

        public async Task<ForgotData> GetUserDetailsByEmail(ForgotData userData)
        {
            return await userServices.GetUserDetailsByEmail(userData);
        }

        public async Task<UserModel> LoginUser(LoginModel loginModel)
        {
            return await userServices.LoginUser(loginModel);
        }

        public async Task<int> RegisterUser(UserModel userModel)
        {
            return await userServices.RegisterUser(userModel);
        }

        #endregion



    }
}
