using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoreProject.Model.ViewModels.User;

namespace TrainingCoreProject.Services.User
{
    public interface IUserServices
    {
        Task<UserModel> LoginUser(LoginModel loginModel);

        Task<int> RegisterUser(UserModel userModel);
    }
}
