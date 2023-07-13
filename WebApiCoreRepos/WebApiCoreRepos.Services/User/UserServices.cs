using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCoreRepos.Data.DBRpository;
using WebApiCoreRepos.Model.ViewModel;

namespace WebApiCoreRepos.Services.User
{
    public class UserServices : IUserServices
    {
        #region Fields
        public IUserRepository userRepository;
        #endregion

        #region Constructor
        public UserServices(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<List<UserModel>> GetUsers()
        {
            return userRepository.GetUsers();   
        }
        #endregion
        public Task<UserModel> LoginUser(LoginModel loginModel)
        {
           return userRepository.LoginUser(loginModel);
        }

        public Task<int> RegisterUser(UserModel userModel)
        {
           return userRepository.RegisterUser(userModel);
        }
    }
}
