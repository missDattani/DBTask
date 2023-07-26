using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationAllOverTopics.Common.Helpers
{
    public class StoredProcedures
    {
        public const string AddUser = "Sp_InsertUser";
        public const string LoginUser = "Sp_LoginUser";
        public const string AllUsers = "Sp_GetUsersData";

        public const string AllCountries = "Sp_GetCountryData";
    }
}
