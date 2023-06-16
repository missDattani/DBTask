using SchoolMgmtWEB_326.Models.Context;
using SchoolMgmtWEB_326.Models.Models;
using SchoolMgmtWEB_326.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Repository.Services
{
    public class UserServices : IUserInterface
    {
        OrderManagementEntities entities = new OrderManagementEntities();
        public Users GetUserByEmail(string email)
        {
            try
            {
                Users users = entities.Users.Where(m => m.Email.ToLower() == email.ToLower()).FirstOrDefault();
                if (users != null)
                {
                    return users;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public string SignIn(UserModel userModel)
        {
            try
            {
                var checkUser = entities.Users.Where(m => m.Email == userModel.Email).FirstOrDefault();
                var checkPass = entities.Users.Where(m => m.PassWord == userModel.PassWord).FirstOrDefault();
                if (checkUser == null && checkPass == null)
                {
                    return "Invalid Email & Password";
                }
                else if (checkUser != null)
                {
                    if (checkUser.PassWord != userModel.PassWord)
                    {
                        return "Invalid Password";
                    }
                    else
                    {
                        return checkUser.Email;

                    }
                }
                else
                {
                    return "Invalid Email";
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int StudentCount()
        {
            return entities.Student.Count();
        }

        public int SubjectCount()
        {
            return entities.Subjects.Count();
        }

        public int TeacherCount()
        {
            return entities.Teachers.Count();
        }

        public int UserCount()
        {
            return entities.Users.Count();
        }
    }
}

