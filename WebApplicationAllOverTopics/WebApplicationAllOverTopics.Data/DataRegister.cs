using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAllOverTopics.Data.DBRepository;
using WebApplicationAllOverTopics.Data.DBRepository.Country;

namespace WebApplicationAllOverTopics.Data
{
    public class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var serviceDictionary = new Dictionary<Type, Type>()
            {
                {typeof(IUserRepository),typeof(UserRepository) },
                {typeof(ICountryRepository),typeof(CountryRepository) }
            };
            return serviceDictionary;
        }
    }
}
