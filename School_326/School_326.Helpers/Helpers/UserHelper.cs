using School_326.Models.Context;
using School_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Helpers.Helpers
{
    public class UserHelper
    {
        public static User ConvertUser(UserModel userM)
        {
            User u = new User();
            u.Id = userM.Id;
            u.FirstName = userM.FirstName;
            u.LastName = userM.LastName;
            u.Email = userM.Email;
            u.PassWord = userM.PassWord;
            return u;
        }
    }
}
