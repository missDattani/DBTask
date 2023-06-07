using OrderManagement.Models.Context;
using OrderManagement.Models.Models;
using OrderManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repositories.Services
{
    public class UserRepository : IUserInterface
    {
        OrderManagementEntities entities = new OrderManagementEntities();
        public string SignIn(UserModel user)
        {
            try
            {
                var checkEmail = entities.Users.Where(m => m.Email == user.Email).FirstOrDefault();
                if (checkEmail != null)
                {
                    if (checkEmail.Password.Equals(user.Password))
                    {
                        return checkEmail.Id.ToString();
                    }
                    return "Invalid Password";
                }
                return "Invalid Email";
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
