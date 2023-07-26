using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAllOverTopics.Model.ViewModel;

namespace WebApplicationAllOverTopics.Services.User
{
    public interface IUserServices
    {
        Task<int> AddEditUser(UserModel userModel);
        Task<UserModel> UserLogin(LoginModel loginModel);

        Task<List<UserModel>> GetUsers();
    }
}
