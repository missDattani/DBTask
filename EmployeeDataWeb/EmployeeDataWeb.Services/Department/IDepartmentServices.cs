using EmployeeDataWeb.Model.ViewModels.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.Department
{
    public interface IDepartmentServices
    {
        Task<List<DepartmentModel>> GetDepartmentByCompanyId(int id);
    }
}
