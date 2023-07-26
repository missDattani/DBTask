using Dapper;
using EmployeeDataWeb.Common.Helpers;
using EmployeeDataWeb.Model.Config;
using EmployeeDataWeb.Model.ViewModels.Employee;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection.Emit;

namespace EmployeeDataWeb.Data.DBRepository.Employee
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        #region Fields
        private readonly IConfiguration configuration;
        #endregion

        #region Constructor
        public EmployeeRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig, configuration) 
        {
            this.configuration = configuration;
        }
        #endregion

        #region Methods
        public async Task<int> AddEmployee(EmployeeModel Empmodel)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EmpId", 0);
            parameter.Add("@EmpName", Empmodel.EmployeeName);
            parameter.Add("@Email", Empmodel.Email);
            parameter.Add("@Location", Empmodel.Location);
            parameter.Add("@DeptId", Empmodel.DeptId);
            parameter.Add("@JobId", Empmodel.JobRoleId);
            parameter.Add("@EmpCode", Empmodel.EmployeeCode);
            parameter.Add("@CompanyId", Empmodel.CompanyId);
            var data = await ExecuteAsync<int>(StoredProcedures.AddEditEmployee, parameter,commandType:CommandType.StoredProcedure);
            return data;
        }

        public async Task<int> DeleteEmployee(int id)
        {
           var parameter = new DynamicParameters();
            parameter.Add("@EmpId", id);
            var data = await QueryFirstOrDefaultAsync<int>(StoredProcedures.DeleteEmployee, parameter,commandType:CommandType.StoredProcedure);
            return data;
        }

        public async Task<EmployeeModel> FindEmployeeById(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EmpId", id);
            var data = await QueryFirstOrDefaultAsync<EmployeeModel>(StoredProcedures.GetEmployeeById, parameter,commandType:CommandType.StoredProcedure);  
            return data;
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var data = await QueryAsync<EmployeeModel>(StoredProcedures.AllEmployees, commandType:CommandType.StoredProcedure);
            return data.ToList();
        }

        public async Task<List<EmployeeModel>> GetEmployeeDataTable(string sortColumn, string sortDirection, int offSetval, int pageSize, string searchBy)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@sortColumn", sortColumn);
            parameter.Add("@sortOrder", sortDirection);
            parameter.Add("@offSetValue", offSetval);
            parameter.Add("@pageSize", pageSize);
            parameter.Add("@searchText", searchBy);
            var data = await QueryAsync<EmployeeModel>(StoredProcedures.GetEmpDataTable, parameter, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }

        public async Task<int> UpdateEmployee(EmployeeModel Empmodel)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@EmpId", Empmodel.EmployeeId);
            parameter.Add("@EmpName", Empmodel.EmployeeName);
            parameter.Add("@Email", Empmodel.Email);
            parameter.Add("@Location", Empmodel.Location);
            parameter.Add("@DeptId", Empmodel.DeptId);
            parameter.Add("@JobId", Empmodel.JobRoleId);
            parameter.Add("@EmpCode", Empmodel.EmployeeCode);
            parameter.Add("@CompanyId", Empmodel.CompanyId);
            var data = await ExecuteAsync<int>(StoredProcedures.AddEditEmployee, parameter, commandType: CommandType.StoredProcedure);
            return data;
        }
        #endregion
    }
}
