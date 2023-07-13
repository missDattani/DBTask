using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCoreRepos.Services.JwtAuthentication;
using WebApiCoreRepos.Services.User;

namespace WebApiCoreRepos.Services
{
    public class ServiceRegister
    {
        public static Dictionary<Type,Type> GetTypes()
        {
            var serviceDictionary = new Dictionary<Type, Type>() 
            {
                {typeof(IUserServices), typeof(UserServices)},
                {typeof(IJWTAuthServices), typeof(JWTAuthServices)},
            };
            return serviceDictionary;
        }
    }
}
