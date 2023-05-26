using SchoolMgmt_326.Model;
using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using SchoolMgmt_326.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_326.Repositories.Services
{
    public class UserService : IUserInterface
    {
        Pooja_SchoolMgmt_326Entities2 entities = new Pooja_SchoolMgmt_326Entities2();

        public string SignUp(UserModel ruser)
        {
            try
            {
                entities.Users.Add(new User
                {
                    FirstName = ruser.FirstName,
                    LastName = ruser.LastName,
                    Email = ruser.Email,
                    PassWord = ruser.PassWord
                });
                entities.SaveChanges();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;

                //throw e;
            }
        }

        public string Signin(UserModel iuser)
        {
            try
            {

            User userValid = entities.Users.Where(m => m.Email.Equals(iuser.Email) && m.PassWord.Equals(iuser.PassWord)).FirstOrDefault();
            if(userValid != null)
            {
                return  userValid.FirstName + " " + userValid.LastName;
            }
            else
            {
                return "0";
            }
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public int UserCount()
        {
            try { 
            return entities.Users.Count();
            }
            catch(Exception e) { throw e; }
        }

        public int StudentCount()
        {
            try
            {
                return entities.Students.Count();
            }
            catch (Exception e) { throw e; }
        }

        public int TeachersCount()
        {
            try
            {
                return entities.Teachers.Count();
            }
            catch (Exception e) { throw e; }
        }

        public int SubjectCount()
        {
            try
            {
                return entities.Subjects.Count();
            }
            catch (Exception e) { throw e; }
        }

    }
}
