using Dapper;
using EmployeeDataWeb.Common.Helpers;
using EmployeeDataWeb.Model.Config;
using EmployeeDataWeb.Model.ViewModels.JobRole;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmployeeDataWeb.Data.DBRepository.JobRole
{
    public class JobRoleRepository : BaseRepository, IJobRoleRepository
    {
        #region Fields
        public IConfiguration configuration;
        #endregion

        #region Constructor
        public JobRoleRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig, configuration)
        {
            this.configuration = configuration;
        }
        #endregion
        public async Task<List<JobRoleModel>> GetJobRoleByDeptId(int deptId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@DeptId", deptId);
           IEnumerable<JobRoleModel> JobList = await QueryAsync<JobRoleModel>(StoredProcedures.GetJobRoleByDeptId, parameter,commandType:CommandType.StoredProcedure);
            return JobList.ToList();
        }
    }
}
