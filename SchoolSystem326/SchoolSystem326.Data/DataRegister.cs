using SchoolSystem326.Data.DBRepository.City;
using SchoolSystem326.Data.DBRepository.Country;
using SchoolSystem326.Data.DBRepository.State;
using SchoolSystem326.Data.DBRepository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem326.Data
{
    public class DataRegister
    {
        public static Dictionary<Type,Type> GetTypes()
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
