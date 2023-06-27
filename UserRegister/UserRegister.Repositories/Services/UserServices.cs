using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegister.Helpers.Helpers;
using UserRegister.Models.Context;
using UserRegister.Models.Models;
using UserRegister.Repositories.Repositories;

namespace UserRegister.Repositories.Services
{
    public class UserServices : IUserInterface
    {
        Pooja326MVCEntities entities = new Pooja326MVCEntities();


        public List<UserModel> GetUsers()
        {

            try
            {
                List<User> usersList = entities.User.ToList();
                if (usersList != null && usersList.Count() > 0)
                {
                    List<UserModel> userModels = UserHelper.BindUserListModelToList(usersList);
                    return userModels;
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

        public int InsUser(UserModel userModel)
        {
            try
            {
              User user = UserHelper.BindUserToUserModel(userModel);
               if(userModel.Id == 0)
                {
                    var checkUser = entities.User.Any(m => m.FirstName == userModel.FirstName && m.LastName == userModel.LastName);
                    if (checkUser)
                    {
                        return 0;
                    }
                    else
                    {
                        entities.User.Add(user);
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


        public UserModel EditUser(int Id)
        {
            try
            {
                User user = entities.User.Find(Id);
                UserModel userModel = UserHelper.BindUserModelToUser(user);
                if (userModel != null)
                {
                    //entities.SaveChanges();
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

        public bool DeleteUser(int Id)
        {
            var user = entities.User.FirstOrDefault(m => m.Id == Id);
            
            if(user != null)
            {
                user.IsDeleted = true;
                if(user.IsDeleted == true)
                {
                    entities.User.Remove(user);
                }
                entities.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
