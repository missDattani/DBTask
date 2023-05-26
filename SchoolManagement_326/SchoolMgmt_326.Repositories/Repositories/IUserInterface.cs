using SchoolMgmt_326.Model;
using SchoolMgmt_326.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Repositories.Repositories
{
    public interface IUserInterface
    {
        string SignUp(UserModel ruser);

        string Signin(UserModel iuser);

        int UserCount();

        int StudentCount();
        int TeachersCount();
        int SubjectCount();
    }
}
