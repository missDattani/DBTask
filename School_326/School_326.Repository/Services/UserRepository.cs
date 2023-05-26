using School_326.Helpers.Helpers;
using School_326.Models.Context;
using School_326.Models.Models;
using School_326.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_326.Repository.Services
{
    public class UserRepository : IUserInterface
    {
        DBTempEntitiesNew entities = new DBTempEntitiesNew();

        public string SignUp(UserModel user)
        {

                var CheckU = entities.Users.Any(m => m.FirstName == user.FirstName && m.LastName == user.LastName);
                if (CheckU)
                {
                    return "0";
                }
                else
                {
                    User us = UserHelper.ConvertUser(user);
                    entities.Users.Add(us);
                    entities.SaveChanges();
                    return "1";
                }
        }

        public string SignIn(UserModel iuser)
        {
            var CheckLog = entities.Users.Where(m => m.Email == iuser.Email && m.PassWord == iuser.PassWord).FirstOrDefault();
            if(CheckLog != null)
            {
                return CheckLog.FirstName + " " + CheckLog.LastName;
            }
            else
            {
                return "0";
            }

        }
    }
}
