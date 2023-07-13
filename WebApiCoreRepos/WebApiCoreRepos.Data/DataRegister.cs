using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCoreRepos.Data.DBRpository;

namespace WebApiCoreRepos.Data
{
    public class DataRegister
    {
        public static Dictionary<Type,Type> GetTypes()
        {
            var serviceDictionary = new Dictionary<Type, Type>()
            {
                {typeof(IUserRepository), typeof(UserRepository)},
            };
            return serviceDictionary;
        }
    }
}
