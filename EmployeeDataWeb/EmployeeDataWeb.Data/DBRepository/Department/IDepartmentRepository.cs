using EmployeeDataWeb.Model.ViewModels.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Data.DBRepository.Department
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentModel>> GetDeptByCompanyId(int CompanyId);
    }
}
