using EmployeeDataWeb.Data.DBRepository.Company;
using EmployeeDataWeb.Model.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.Company
{
    public class CompanyServices : ICompanyServices
    {
        #region Fields
        public readonly ICompanyRepository companyRepository;
        #endregion

        #region Constructor
        public CompanyServices(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        #endregion
        public async Task<List<CompanyModel>> GetAllCompanies()
        {
            return await companyRepository.GetCompanyList();
        }
    }
}
