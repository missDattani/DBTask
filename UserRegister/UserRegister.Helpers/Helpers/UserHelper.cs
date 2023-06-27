using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegister.Helpers.GlobalEnum;
using UserRegister.Models.Context;
using UserRegister.Models.Models;

namespace UserRegister.Helpers.Helpers
{
    public class UserHelper
    {
        public static User BindUserToUserModel(UserModel userModel)
        {
            try
            {
                bool delete = false;
                User user = new User();
                user.Id = userModel.Id;
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Address = userModel.Address;
                user.Gender = userModel.Gender;
                user.DOB = userModel.DOB;
                user.Role = userModel.Role;
                user.MobileNo = userModel.MobileNo;
                user.IsDeleted = delete;
                user.Email = userModel.Email;
                user.Password = userModel.Password;
                return user;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static List<UserModel> BindUserListModelToList(List<User> users)
        {
            try
            {
                List<UserModel> userModelList = new List<UserModel>();
                foreach (var item in users)
                {
                    bool delete = false;
                    UserModel userModel = new UserModel();
                    userModel.Id = item.Id;
                    userModel.FirstName = item.FirstName;
                    userModel.LastName = item.LastName;
                    userModel.Address = item.Address;
                    userModel.Gender = item.Gender;
                    userModel.DOB = item.DOB;
                    userModel.Role = item.Role;
                    userModel.MobileNo = item.MobileNo;
                    userModel.IsDeleted = delete;
                    userModel.Email = item.Email;
                    userModel.Password = item.Password;
                    userModel.RoleName = GetRole(item.Role);
                    userModelList.Add(userModel);
                }
                return userModelList;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static UserModel BindUserModelToUser(User user)
        {
            try
            {
                bool delete = false;
                UserModel userModel = new UserModel();
                userModel.Id = user.Id;
                userModel.FirstName = user.FirstName;
                userModel.LastName = user.LastName;
                userModel.Address = user.Address;
                userModel.Gender = user.Gender;
                userModel.DOB = user.DOB;
                userModel.Role = user.Role;
                userModel.MobileNo = user.MobileNo;
                userModel.IsDeleted = delete;
                userModel.Email = user.Email;
                userModel.Password = user.Password;
                userModel.RoleName = GetRole(user.Role);
                return userModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static string GetRole(int? RoleType)
        {
            try
            {
                return Enum.GetName(typeof(UserRoleType), RoleType);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
