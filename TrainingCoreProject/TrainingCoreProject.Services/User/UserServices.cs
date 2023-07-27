using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoreProject.Data.DBRepository.User;
using TrainingCoreProject.Model.ViewModels.User;

namespace TrainingCoreProject.Services.User
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
        #endregion
    }
}
