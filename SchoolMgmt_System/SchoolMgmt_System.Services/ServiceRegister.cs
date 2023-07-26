using SchoolMgmt_System.Services.City;
using SchoolMgmt_System.Services.Country;
using SchoolMgmt_System.Services.JWTAuthentication;
using SchoolMgmt_System.Services.State;
using SchoolMgmt_System.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Services
{
    public class ServiceRegister
    {
        public static Dictionary<Type, Type> GetTypes() 
        {
            var ServiceDictionary = new Dictionary<Type, Type>()
            {
                {typeof(IUserServices), typeof(UserServices)},
				 {typeof(ICountryServices), typeof(CountryServices)},
                  {typeof(IStateServices), typeof(StateServices)},
                {typeof(ICityServices), typeof(CityServices)},
                {typeof(IJWTAuthServices),typeof(JWTAuthServices)},
            };
            return ServiceDictionary;
        }
    }
}
