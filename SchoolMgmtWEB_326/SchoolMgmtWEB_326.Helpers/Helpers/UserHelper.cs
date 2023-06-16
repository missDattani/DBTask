using SchoolMgmtWEB_326.Helpers.GlobalEnum;
using SchoolMgmtWEB_326.Models.Context;
using SchoolMgmtWEB_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmtWEB_326.Helpers.Helpers
{
    public class UserHelper
    {
        public static List<UserModel> BindUserModelListToList(List<Users> userList)
        {
            try
            {
                List<UserModel> modelList = new List<UserModel>();
                foreach (var item in userList)
                {
                    UserModel userModel = new UserModel();
                    userModel.Id = item.Id;
                    userModel.FirstName = item.FirstName;
                    userModel.LastName = item.LastName;
                    userModel.Email = item.Email;
                    userModel.PassWord = item.PassWord;
                    userModel.Role = item.Role;
                    userModel.RoleName = GetEnumString(item.Role);
                    modelList.Add(userModel);
                }
                return modelList;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static Users BindUserModelToUser(UserModel userModel)
        {
            try
            {
                Users users = new Users();
                users.Id = userModel.Id;
                users.FirstName = userModel.FirstName;
                users.LastName = userModel.LastName;
                users.Email = userModel.Email;
                users.PassWord = userModel.PassWord;
                users.Role = userModel.Role;
                return users;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static UserModel BindUserToUserModel(Users users)
        {
            try
            {
                UserModel userModel = new UserModel();
                userModel.Id = users.Id;
                userModel.FirstName = users.FirstName;
                userModel.LastName = users.LastName;
                userModel.Email = users.Email;
                userModel.PassWord = users.PassWord;
                userModel.Role = users.Role;
                userModel.RoleName = GetEnumString(users.Role);
                return userModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static string GetEnumString(int? RoleType)
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
