using SchoolMgmtWEB_326.Models.Context;
using SchoolMgmtWEB_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Repository.Repositories
{
    public interface IUserInterface
    {
        Users GetUserByEmail(string email);
        string SignIn(UserModel userModel);

        int UserCount();
        int StudentCount();
        int TeacherCount();
        int SubjectCount();
    }
}
