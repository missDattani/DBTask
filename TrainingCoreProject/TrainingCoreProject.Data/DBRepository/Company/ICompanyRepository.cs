using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoreProject.Model.ViewModels.Company;

namespace TrainingCoreProject.Data.DBRepository.Company
{
    public interface ICompanyRepository
    {
        Task<List<Country>> GetCountries();

        Task<List<CompanyList>> GetAllCompanies();

        Task<List<CompanyModel>> GetAllCompanyDetails();
    
        Task<CompanyModel> GetCompanyById(int id);

        Task<int> AddEditCompanyDetails(CompanyModel company);

        Task<int> DeleteCompany(int id);
    }
}
