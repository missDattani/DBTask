using QuizApplication.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Repositories.Repositories
{
    public interface IUserInterface
    {
        int SignIn(UserModel userModel);
    }
}
