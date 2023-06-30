using Register.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Repositories.Repositories
{
    public interface IUserInterface
    {
        int InsUser(UserModel userModel);
        List<UserModel> DisplayUser();

        UserModel UpdateUser(int Id);
        int UpdateUser(UserModel userModel);

        int DeleteUser(int Id);
    }
}
