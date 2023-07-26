using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAllOverTopics.Services.Country;
using WebApplicationAllOverTopics.Services.JwtAuthentication;
using WebApplicationAllOverTopics.Services.User;

namespace WebApplicationAllOverTopics.Services
{
    public class ServiceRegister
    {
        public static Dictionary<Type,Type> GetTypes()
        {
            var serviceDictionary = new Dictionary<Type, Type>() 
            {
                {typeof(IUserServices),typeof(UserServices) },
                {typeof(ICountryServices),typeof(CountryServices) },
                {typeof(IJwtAuthServices),typeof(JwtAuthServices) }
            };
            return serviceDictionary;
        }
    }
}
