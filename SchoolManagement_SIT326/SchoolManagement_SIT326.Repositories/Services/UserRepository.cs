using SchoolManagement_SIT326.Helpers.Helpers;
using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using SchoolManagement_SIT326.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Repositories.Services
{
    public class UserRepository : IUserInterface
    {
        private readonly OrderManagementEntities entities = new OrderManagementEntities();


        public List<UserModel> GetUsers()
        {
            try
            {

                List<Users> users = entities.Users.ToList();
                if (users != null && users.Count() > 0)
                {
                    List<UserModel> uModel = UserHelper.BindModelListToList(users);
                    return uModel;
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

        public UserModel DisplayUserById(int? Id)
        {
            try
            {
                Users users = entities.Users.Where(m => m.Id == Id).FirstOrDefault();
                UserModel userModel = UserHelper.BindUserToUserModel(users);
                if (userModel != null)
                {
                 
                    return userModel;
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

        public string SignIn(UserModel userM)
        {
            try
            {
                var checkUser = entities.Users.Where(m => m.Email == userM.Email).FirstOrDefault();
                if (checkUser != null)
                {
                    if (checkUser.PassWord == userM.PassWord)
                    {
                        return checkUser.FirstName + "" + checkUser.LastName;
                    }
                    else
                    {
                        return "Invalid Password";
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

        public int SignUp(UserModel userM,int? Id)
        {
            try
            {
                Users user = UserHelper.BindUserModelToUser(userM);
                if(Id == 0)
                {
                    var checkUs = entities.Users.Any(m => m.FirstName == userM.FirstName && m.LastName == userM.LastName);
                    if (checkUs)
                    {
                        return 0;
                    }
                    else
                    {
                        entities.Users.Add(user);
                        entities.SaveChanges();
                        return 1;
                    }
                }
                else
                {
                    entities.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
       
        }

        public int RemoveUser(int Id)
        {
            try
            {
                var res = entities.Users.Where(m => m.Id == Id).FirstOrDefault();
                if (res != null)
                {
                    entities.Users.Remove(res);
                    entities.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

   
    }
}
