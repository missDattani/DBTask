using EmployeeDataWeb.Services.Company;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeDataWeb.Controllers
{
    public class CompanyController : Controller
    {
        #region Fields
        public ICompanyServices companyServices;
        #endregion

        #region Constructor
        public CompanyController(ICompanyServices companyServices) 
        {
            this.companyServices = companyServices;
        }

        #endregion
        public async Task<JsonResult> GetCompanyList()
        {
            try
            {
                var CompanyList = await companyServices.GetAllCompanies();
                var jsonData = JsonConvert.SerializeObject(CompanyList);
                return Json(jsonData);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
