using SchoolSystem326.Services.City;
using SchoolSystem326.Services.Country;
using SchoolSystem326.Services.JWTAuthentication;
using SchoolSystem326.Services.State;
using SchoolSystem326.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Services
{
    public class ServiceRegister
    {
        public static Dictionary<Type,Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>() 
            {
                {typeof(IUserServices), typeof(UserServices)},
                {typeof(ICountryServices), typeof(CountryServices)},
                {typeof(IStateServices), typeof(StateServices)},
                {typeof(ICityServices), typeof(CityServices)},
                {typeof(IJWTAuthServices),typeof(JWTAuthServices)},

            };
            return dictionary;
        }
    }
}
