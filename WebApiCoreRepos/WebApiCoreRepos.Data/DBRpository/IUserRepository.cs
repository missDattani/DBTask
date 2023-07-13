using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCoreRepos.Model.ViewModel;

namespace WebApiCoreRepos.Data.DBRpository
{
    public interface IUserRepository
    {
        Task<UserModel> LoginUser(LoginModel loginModel);

        Task<int> RegisterUser(UserModel userModel);

        Task<List<UserModel>> GetUsers();
    }
}
