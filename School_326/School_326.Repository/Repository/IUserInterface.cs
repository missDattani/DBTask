using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Repository.Repository
{
    public interface IUserInterface
    {
        string SignUp(UserModel user);
        string SignIn(UserModel iuser);
    }
}
