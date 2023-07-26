using EmployeeDataWeb.Model.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataWeb.Services.Company
{
    public interface ICompanyServices
    {
        Task<List<CompanyModel>> GetAllCompanies();
    }
}
