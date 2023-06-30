using Register.Helper.GlobalEnum;
using Register.Models.Context;
using Register.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Helper.Helpers
{
    public class UserHelper
    {
        public static User BindUserToUserModel(UserModel userModel)
        {
            try
            {
                bool Deleted = false;
                User user = new User();
                user.Id = userModel.Id;
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName != null ? userModel.LastName : " ";
                user.Address = userModel.Address != null ? userModel.Address : " ";
                user.Gender = userModel.Gender;
                user.DOB = userModel.DOB;
                user.Role = userModel.Role;
                user.MobileNo = userModel.MobileNo;
                user.IsDeleted = Deleted;
                user.Email = userModel.Email;
                user.Password = userModel.Password;
                return user;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static List<UserModel> BindUserModelListToUserList(List<User> userList)
        {
            try
            {
                bool Deleted = false;
                List<UserModel> userModelList = new List<UserModel>();
                foreach (var item in userList)
                {
                    UserModel userModel = new UserModel();
                    userModel.Id = item.Id;
                    userModel.FirstName = item.FirstName;
                    userModel.LastName = item.LastName != null ? item.LastName : " ";
                    userModel.Address = item.Address != null ? item.Address : " ";
                    userModel.Gender = item.Gender;
                    userModel.DOB = item.DOB;
                    userModel.DOBFormat = item.DOB.HasValue && item.DOB != null ? item.DOB.Value.ToString("yyyy-MM-dd") : "";
                    userModel.Role = item.Role;
                    userModel.RoleName = GetRoleName(item.Role);
                    userModel.MobileNo = item.MobileNo;
                    userModel.IsDeleted = Deleted;
                    userModel.Email = item.Email;
                    userModel.Password = item.Password;
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
                bool Deleted = false;
                UserModel userModel = new UserModel();
                userModel.Id = user.Id;
                userModel.FirstName = user.FirstName;
                userModel.LastName = user.LastName != null ? user.LastName : " ";
                userModel.Address = user.Address != null ? user.Address : " "; 
                userModel.Gender = user.Gender;
                userModel.DOB = user.DOB;
                userModel.DOBFormat = user.DOB.HasValue && user.DOB != null ? user.DOB.Value.ToString("yyyy-MM-dd") : "";
                userModel.Role = user.Role;
                userModel.RoleName = GetRoleName(user.Role);
                userModel.MobileNo = user.MobileNo;
                userModel.IsDeleted = Deleted;
                userModel.Email = user.Email;
                userModel.Password = user.Password;
                return userModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static string GetRoleName(int? Role)
        {
            return Enum.GetName(typeof(UserRoleType), Role);
        }
    }
}
