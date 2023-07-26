using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAllOverTopics.Data.DBRepository;
using WebApplicationAllOverTopics.Model.ViewModel;

namespace WebApplicationAllOverTopics.Services.User
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
        public async Task<int> AddEditUser(UserModel userModel)
        {
           return await userRepository.AddEditUser(userModel);
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        public Task<UserModel> UserLogin(LoginModel loginModel)
        {
            return userRepository.UserLogin(loginModel);
        }

        #endregion
    }
}
