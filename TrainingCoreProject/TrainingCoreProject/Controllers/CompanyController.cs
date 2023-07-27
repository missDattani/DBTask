using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingCoreProject.Model.ViewModels.Company;
using TrainingCoreProject.Services.Company;

namespace TrainingCoreProject.Controllers
{
    public class CompanyController : Controller
    {
        #region Fields
        private readonly IWebHostEnvironment hostEnvironment;
        public readonly ICompanyServices companyServices;
        #endregion

        #region Constructor
        public CompanyController(ICompanyServices companyServices,IWebHostEnvironment hostEnvironment)
        {
            this.companyServices = companyServices;
            this.hostEnvironment = hostEnvironment;
        }
        #endregion

        public async Task<IActionResult> GetCompanyDetails()
        {
            List<CompanyModel> result =await  companyServices.GetAllCompanyDetails();
            return View(result);
        }

        public async Task<IActionResult> AboutCompany(int Id)
        {
            try
            {
                var company = await companyServices.GetCompanyById(Id);
                if (company.Image != null)
                {
                    return View(company);
                }
                else
                {
                    TempData["Login"] = "images.jpg";
                    return View(company);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> AddEditCompany(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["Image"] = "images.jpg";
                    ViewBag.countryList = new SelectList(await companyServices.GetCountries(), "CountryId", "CountryName");
                    ViewBag.companyList = new SelectList(await companyServices.GetAllCompanies(), "CompanyId", "CompanyName");
                    return View();
                }
                else
                {
                    TempData["Id"] = Id;
                    ViewBag.countryList = new SelectList(await companyServices.GetCountries(), "CountryId", "CountryName");
                    ViewBag.companyList = new SelectList(await companyServices.GetAllCompanies(), "CompanyId", "CompanyName");
                    var company = await companyServices.GetCompanyById(Id);
                    return View(company);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEditCompany(CompanyModel company,IFormFile file)
        {
            try
            {
                string exFileName = string.Empty;
                if (file != null)
                {
                    string uploadFolder = Path.Combine(hostEnvironment.WebRootPath, "CompanyLogos");
                    exFileName = file.FileName;

                    string filePath = Path.Combine(uploadFolder, exFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
                company.Image = exFileName;
                await companyServices.AddEditCompanyData(company);
                return RedirectToAction("GetCompanyDetails");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> DeleteCompanyData(int id)
        {
            try
            {
                await companyServices.DeleteCompanyData(id);
                TempData["Message"] = "Data Deleted SuccessFully";
                return RedirectToAction("GetCompanyDetails");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
