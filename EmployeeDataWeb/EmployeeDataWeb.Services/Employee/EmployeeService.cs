using EmployeeDataWeb.Data.DBRepository.Employee;
using EmployeeDataWeb.Model.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.Employee
{
    public class EmployeeService : IEmployeeServices
    {
        #region Fields
        public readonly IEmployeeRepository employeeRepository;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        #endregion

        #region Methods
        public async Task<int> AddEmployee(EmployeeModel EmpModel)
        {
            return await employeeRepository.AddEmployee(EmpModel);
        }

        public async Task<int> DeleteEmployee(int EmployeeId)
        {
           return await employeeRepository.DeleteEmployee(EmployeeId);
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            return await employeeRepository.GetAllEmployees();
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            return await employeeRepository.FindEmployeeById(id);
        }

        public async Task<List<EmployeeModel>> GetEmployeeDataTable(string sortColumn, string sortDirection, int offSetval, int pageSize, string searchBy)
        {
            return await employeeRepository.GetEmployeeDataTable(sortColumn, sortDirection, offSetval, pageSize, searchBy);
        }

        public async Task<int> UpdateEmployee(EmployeeModel EmpModel)
        {
           return await employeeRepository.UpdateEmployee(EmpModel);
        }
        #endregion
    }
}
