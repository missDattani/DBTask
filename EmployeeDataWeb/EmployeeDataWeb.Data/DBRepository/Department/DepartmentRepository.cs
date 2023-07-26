using Dapper;
using EmployeeDataWeb.Common.Helpers;
using EmployeeDataWeb.Model.Config;
using EmployeeDataWeb.Model.ViewModels.Department;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Data.DBRepository.Department
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        #region Fields
        public IConfiguration configuration;
        #endregion

        #region Constructor
        public DepartmentRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig, configuration)
        {
            this.configuration = configuration;
        }
        #endregion
        public async Task<List<DepartmentModel>> GetDeptByCompanyId(int CompanyId)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@CompanyId", CompanyId);
            IEnumerable<DepartmentModel> deptList = await QueryAsync<DepartmentModel>(StoredProcedures.GetDeptByCompanyId, parameter,commandType:CommandType.StoredProcedure);
            return deptList.ToList();
        }
    }
}
