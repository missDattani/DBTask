using EmployeeDataWeb.Common.Helpers;
using EmployeeDataWeb.Model.Config;
using EmployeeDataWeb.Model.ViewModels.Company;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmployeeDataWeb.Data.DBRepository.Company
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        #region Fields
        public IConfiguration configuration;
        #endregion

        #region Constructor
        public CompanyRepository(IConfiguration configuration,IOptions<DataConfig> dataConfig) : base(dataConfig, configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region Methods
        public async Task<List<CompanyModel>> GetCompanyList()
        {
            var data = await QueryAsync<CompanyModel>(StoredProcedures.GetCompanyList, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
        #endregion
    }
}
