using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAllOverTopics.Model.ViewModel;

namespace WebApplicationAllOverTopics.Data.DBRepository
{
    public interface IUserRepository
    {
        Task<int> AddEditUser(UserModel userModel);

        Task<UserModel> UserLogin(LoginModel loginModel);

        Task<List<UserModel>> GetUsers();
    }
}

