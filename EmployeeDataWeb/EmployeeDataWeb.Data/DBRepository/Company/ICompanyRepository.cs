using EmployeeDataWeb.Model.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Data.DBRepository.Company
{
    public interface ICompanyRepository
    {
        Task<List<CompanyModel>> GetCompanyList();
    }
}
