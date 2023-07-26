using EmployeeDataWeb.Data.DBRepository.Department;
using EmployeeDataWeb.Model.ViewModels.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.Department
{
    public class DepartmentServices : IDepartmentServices
    {
        #region Fields
        public IDepartmentRepository department;
        #endregion

        #region Constructor
        public DepartmentServices(IDepartmentRepository department)
        {
            this.department = department;
        }
        #endregion
        public async Task<List<DepartmentModel>> GetDepartmentByCompanyId(int id)
        {
           return await department.GetDeptByCompanyId(id);
        }
    }
}
