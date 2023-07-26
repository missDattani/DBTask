using EmployeeDataWeb.Data.DBRepository.JobRole;
using EmployeeDataWeb.Model.ViewModels.JobRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.JobRole
{
    public class JobRoleServices : IJobRoleServices
    {
        #region Fields
        public IJobRoleRepository jobRole;
        #endregion

        #region Constructor
        public JobRoleServices(IJobRoleRepository jobRole)
        {
            this.jobRole = jobRole;
        }
        #endregion
        public async Task<List<JobRoleModel>> GetJobRoleByDeptId(int deptId)
        {
            return await jobRole.GetJobRoleByDeptId(deptId);
        }
    }
}
