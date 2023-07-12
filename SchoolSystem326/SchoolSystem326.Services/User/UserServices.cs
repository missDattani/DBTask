using SchoolSystem326.Data.DBRepository.User;
using SchoolSystem326.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Services.User
{
    public class UserServices : IUserServices
    {
        #region Fields
        private readonly IUserRepository userRepository;
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

        public async Task<int> RegisterUser(UserModel userModel)
        {
            return await userRepository.RegisterUser(userModel);
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await userRepository.GetUserById(id);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await userRepository.GetAllUsers();
        }
        #endregion
    }
}
