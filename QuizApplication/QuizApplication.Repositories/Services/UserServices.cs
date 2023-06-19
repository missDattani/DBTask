using QuizApplication.Models.Context;
using QuizApplication.Models.Models;
using QuizApplication.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Repositories.Services
{
    public class UserServices : IUserInterface
    {
        Pooja326MVCEntities entities = new Pooja326MVCEntities(); 
        public int SignIn(UserModel userModel)
        {
            try
            {
                if (entities.Users.Any(m => m.EMAIL == userModel.EMAIL))
                {
                    if (entities.Users.Any(m => m.EMAIL == userModel.EMAIL && m.PASSWORD == userModel.PASSWORD))
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 3;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
