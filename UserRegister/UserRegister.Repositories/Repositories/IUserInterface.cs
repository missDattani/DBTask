using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegister.Models.Models;

namespace UserRegister.Repositories.Repositories
{
    public interface IUserInterface
    {

        int InsUser(UserModel userModel);
        List<UserModel> GetUsers();

        UserModel EditUser(int Id);

        bool DeleteUser(int Id);
    }
}
