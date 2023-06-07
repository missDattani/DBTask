using SchoolManagement_SIT326.Helpers.GlobalEnum;
using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_SIT326.Helpers.Helpers
{
    public class UserHelper
    {
        public static Users BindUserModelToUser(UserModel uModel)
        {
            try
            {
                Users users = new Users();
                users.Id = uModel.Id;
                users.FirstName = uModel.FirstName;
                users.LastName = uModel.LastName;
                users.Email = uModel.Email;
                users.PassWord = uModel.PassWord;
                users.Role = uModel.Role;
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
                UserModel uModel = new UserModel();
                uModel.Id = users.Id;
                uModel.FirstName = users.FirstName;
                uModel.LastName = users.LastName;
                uModel.Email = users.Email;
                uModel.PassWord = users.PassWord;
                uModel.Role = users.Role;
                uModel.RoleName = GetEnumString(users.Role);
                return uModel;
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

        public static List<UserModel> BindModelListToList(List<Users> users)
        {
            try
            {
                List<UserModel> us = new List<UserModel>();
                foreach (var item in users)
                {
                    UserModel us1 = new UserModel();
                    us1.Id = item.Id;
                    us1.FirstName = item.FirstName;
                    us1.LastName = item.LastName;
                    us1.Email = item.Email;
                    us1.PassWord = item.PassWord;
                    us1.Role = item.Role;
                    us1.RoleName = GetEnumString(item.Role);
                    us.Add(us1);
                }
                return us;
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }
    }
}
