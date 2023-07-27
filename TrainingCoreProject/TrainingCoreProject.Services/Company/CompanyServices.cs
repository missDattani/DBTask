using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoreProject.Data.DBRepository.Company;
using TrainingCoreProject.Model.ViewModels.Company;

namespace TrainingCoreProject.Services.Company
{
    public class CompanyServices : ICompanyServices
    {
        #region Fields
        public ICompanyRepository companyRepository;
        #endregion

        #region Constructor
        public CompanyServices(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<int> AddEditCompanyData(CompanyModel company)
        {
           return await companyRepository.AddEditCompanyDetails(company);
        }

        public async Task<int> DeleteCompanyData(int id)
        {
            return await companyRepository.DeleteCompany(id);
        }
        #endregion
        public async Task<List<CompanyList>> GetAllCompanies()
        {
            return await companyRepository.GetAllCompanies();
        }

        public async Task<List<CompanyModel>> GetAllCompanyDetails()
        {
            return await companyRepository.GetAllCompanyDetails();
        }

        public async Task<CompanyModel> GetCompanyById(int id)
        {
           return await companyRepository.GetCompanyById(id);
        }

        public async Task<List<Country>> GetCountries()
        {
            return await companyRepository.GetCountries();
        }
    }
}
