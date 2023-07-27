using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoreProject.Data.DBRepository.Company;
using TrainingCoreProject.Data.DBRepository.User;

namespace TrainingCoreProject.Data
{
    public class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>()
            {
                {typeof(IUserRepository), typeof(UserRepository)},
                {typeof(ICompanyRepository), typeof(CompanyRepository)},
            };
            return dictionary;
        }
    }
}
