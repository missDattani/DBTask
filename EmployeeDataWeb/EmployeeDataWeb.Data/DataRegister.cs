using EmployeeDataWeb.Data.DBRepository.Company;
using EmployeeDataWeb.Data.DBRepository.Department;
using EmployeeDataWeb.Data.DBRepository.Employee;
using EmployeeDataWeb.Data.DBRepository.JobRole;
using EmployeeDataWeb.Data.DBRepository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Data
{
    public class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var serviceDictionary = new Dictionary<Type, Type>()
            {
                {typeof(IUserRepository), typeof(UserRepository)},
                {typeof(IEmployeeRepository),typeof(EmployeeRepository)},
                {typeof(IDepartmentRepository),typeof(DepartmentRepository)},
                {typeof(IJobRoleRepository),typeof(JobRoleRepository)},
                {typeof(ICompanyRepository),typeof(CompanyRepository)},
            };
            return serviceDictionary;
        }
    }
}
