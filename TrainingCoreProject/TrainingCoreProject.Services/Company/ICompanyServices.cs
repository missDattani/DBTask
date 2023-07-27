using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCoreProject.Model.ViewModels.Company;

namespace TrainingCoreProject.Services.Company
{
    public interface ICompanyServices
    {
        Task<List<Country>> GetCountries();

        Task<List<CompanyList>> GetAllCompanies();

        Task<List<CompanyModel>> GetAllCompanyDetails();
        Task<CompanyModel> GetCompanyById(int id);

        Task<int> AddEditCompanyData(CompanyModel company);
        Task<int> DeleteCompanyData(int id);
    }
}
