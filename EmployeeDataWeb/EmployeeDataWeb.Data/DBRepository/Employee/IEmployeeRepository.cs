using EmployeeDataWeb.Model.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Data.DBRepository.Employee
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmployees();

        Task<EmployeeModel> FindEmployeeById(int id);
        Task<int> AddEmployee(EmployeeModel Empmodel);
        Task<int> UpdateEmployee(EmployeeModel Empmodel);
        Task<int> DeleteEmployee(int id);

        Task<List<EmployeeModel>> GetEmployeeDataTable(string sortColumn,string sortDirection,int offSetval,int pageSize,string searchBy);
    }
}
