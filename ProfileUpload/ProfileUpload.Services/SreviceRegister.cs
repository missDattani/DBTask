using ProfileUpload.Services.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileUpload.Services
{
    public class SreviceRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>()
            {
                {typeof(IEmployeeServices),typeof(EmployeeServices)}
            };
            return dictionary;
        }
    }
}
