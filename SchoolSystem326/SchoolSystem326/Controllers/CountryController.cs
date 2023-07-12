using Microsoft.AspNetCore.Mvc;
using SchoolSystem326.Filter;
using SchoolSystem326.Model.ViewModels;
using SchoolSystem326.Services.Country;

namespace SchoolSystem326.Controllers
{
    [TypeFilter(typeof(JwtTokenFilter))]
    public class CountryController : Controller
    {
        #region Fields
        public ICountryServices countryServices;
        #endregion

        #region Constructor
        public CountryController(ICountryServices countryServices) 
        {
            this.countryServices = countryServices;
        }
        #endregion

        #region Methods

        public async Task<IActionResult> GetCountries()
        {
            List<CountryModel> countries = await countryServices.GetAllCountry();
            return View(countries);
        }
        public IActionResult AddEditCountry(int Id)
        {
            try
            {
                if (Id == 0)
                {

                    return View();
                }
                else
                {
                    var country = countryServices.GetCountryById(Id);
                    return View(country);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEditCountry(CountryModel countryModel)
        {
            try
            {
                await countryServices.AddEditCountry(countryModel);
                return View(countryModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
