using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoreProject.Model.ViewModels.User;

namespace TrainingCoreProject.Data.DBRepository.User
{
    public interface IUserRepository
    {
        Task<UserModel> LoginUser(LoginModel loginModel);

        Task<int> RegisterUser(UserModel userModel);
    }
}
