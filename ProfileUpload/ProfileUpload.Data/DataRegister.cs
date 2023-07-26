using ProfileUpload.Data.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileUpload.Data
{
    public class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>()
            {
                {typeof(IEmployeeRepository),typeof(EmployeeRepository)}
            };
            return dictionary;
        }
    }
}
