using Register.Helper.Helpers;
using Register.Models.Context;
using Register.Models.Models;
using Register.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Repositories.Services
{
    
    public class UserServices : IUserInterface
    {
        Pooja326MVCEntities entities = new Pooja326MVCEntities();

        public int DeleteUser(int Id)
        {
            try
            {
                User user = entities.User.FirstOrDefault(m => m.Id == Id);
                if(user != null)
                {
                    user.IsDeleted = true;
                    entities.Entry(user).State = System.Data.Entity.EntityState.Modified;
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

        public List<UserModel> DisplayUser()
        {
            try
            {
                List<User> userList = entities.User.Where(m => m.IsDeleted == false).ToList();
                List<UserModel> userModelList = UserHelper.BindUserModelListToUserList(userList);
                if (userModelList != null && userModelList.Count() > 0)
                {
                    return userModelList;
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
                if (user != null)
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
                    return 0;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public UserModel UpdateUser(int Id)
        {
            try
            {
                User user = entities.User.Find(Id);
                UserModel userModel = UserHelper.BindUserModelToUser(user);
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

        public int UpdateUser(UserModel userModel)
        {
            User user = UserHelper.BindUserToUserModel(userModel);
            if(user != null)
            {
                entities.Entry(user).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
