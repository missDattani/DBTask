using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCoreRepos.Common.Helpers
{
    public class StoredProcedures
    {
        public const string UserLogin = "Sp_UserLoginData";
        public const string UserRegister = "Sp_UserRegistration";
        public const string UserData = "Sp_GetUsersData";
    }
}
