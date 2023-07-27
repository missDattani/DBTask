using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoreProject.Services.Company;
using TrainingCoreProject.Services.User;

namespace TrainingCoreProject.Services
{
    public class ServiceRegister
    {
        public static Dictionary<Type,Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>() 
            {
                {typeof(IUserServices), typeof(UserServices)},
                {typeof(ICompanyServices), typeof(CompanyServices)},
            };
            return dictionary;
        }
    }
}
