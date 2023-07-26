using EmployeeDataWeb.Model.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.Employee
{
    public interface IEmployeeServices
    {
        Task<int> AddEmployee(EmployeeModel EmpModel);
        Task<int> UpdateEmployee(EmployeeModel EmpModel);

        Task<int> DeleteEmployee(int EmployeeId);

        Task<EmployeeModel> GetEmployeeById(int id);

        Task<List<EmployeeModel>> GetAllEmployees();
        Task<List<EmployeeModel>> GetEmployeeDataTable(string sortColumn, string sortDirection, int offSetval, int pageSize, string searchBy);
    }
}
