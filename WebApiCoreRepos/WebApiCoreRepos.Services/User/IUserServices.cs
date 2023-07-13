using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCoreRepos.Model.ViewModel;

namespace WebApiCoreRepos.Services.User
{
    public interface IUserServices
    {
        Task<UserModel> LoginUser(LoginModel loginModel);

        Task<int> RegisterUser(UserModel userModel);

        Task<List<UserModel>> GetUsers();
    }
}
