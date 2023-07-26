using EmployeeDataWeb.Model.ViewModels.JobRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.JobRole
{
    public interface IJobRoleServices
    {
        Task<List<JobRoleModel>> GetJobRoleByDeptId(int deptId);
    }
}
