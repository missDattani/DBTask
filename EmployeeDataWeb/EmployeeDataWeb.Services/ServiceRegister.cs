using EmployeeDataWeb.Services.Company;
using EmployeeDataWeb.Services.Department;
using EmployeeDataWeb.Services.Employee;
using EmployeeDataWeb.Services.JobRole;
using EmployeeDataWeb.Services.JwtAuthenticationServices;
using EmployeeDataWeb.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services
{
    public class ServiceRegister
    {
        public static Dictionary<Type,Type> GetTypes()
        {
            var serviceDictionary = new Dictionary<Type, Type>() 
            {
                {typeof(IUserServices), typeof(UserServices)},
                {typeof(IEmployeeServices),typeof(EmployeeService)},
                {typeof(IDepartmentServices),typeof(DepartmentServices)},
                {typeof(IJobRoleServices),typeof(JobRoleServices)},
                {typeof(ICompanyServices),typeof(CompanyServices)},
             
            };
            return serviceDictionary;
        }
    }
}
