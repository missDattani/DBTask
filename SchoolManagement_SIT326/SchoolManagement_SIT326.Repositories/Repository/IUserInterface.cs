using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Repositories.Repository
{
    public interface IUserInterface
    {
        List<UserModel> GetUsers();
        Users DisplayUserById(int? Id);
        int SignUp(UserModel userM,int? Id);
        string SignIn(UserModel userM);
        int RemoveUser(int Id);

    }
}
