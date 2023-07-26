using SchoolMgmt_System.Data.DBrepository.City;
using SchoolMgmt_System.Data.DBrepository.Country;
using SchoolMgmt_System.Data.DBrepository.State;
using SchoolMgmt_System.Data.DBrepository.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMgmt_System.Data
{
    public class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>()
            {
                {typeof(IUserRepository), typeof(UserRepository)},
				 {typeof(ICountryRepository), typeof(CountryRepository)},
                  {typeof(IStateRepository), typeof(StateRepository)},
                {typeof(ICityRepository), typeof(CityRepository)},
            };
            return dictionary;
        }
    }
}
