using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolSystem326.Filter;
using SchoolSystem326.Model.ViewModels;
using SchoolSystem326.Services.City;
using SchoolSystem326.Services.Country;
using SchoolSystem326.Services.State;

namespace SchoolSystem326.Controllers
{
    [TypeFilter(typeof(JwtTokenFilter))]
    public class CityController : Controller
    {
        #region Fields
        public ICityServices cityServices;
        public ICountryServices countryServices;
        public IStateServices stateServices;
        #endregion

        #region Constructor
        public CityController(ICityServices cityServices,ICountryServices countryServices,IStateServices stateServices)
        {
            this.cityServices = cityServices;
            this.countryServices = countryServices;
            this.stateServices = stateServices;
        }
        #endregion

        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                List<CityModel> cityModels = await cityServices.GetAllCities();
                return View(cityModels);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> AddEditCity(int Id)
        {
            try
            {

                if (Id == 0)
                {
                   
                    ViewBag.stateList = new SelectList(await stateServices.GetAllStates(), "StateId", "StateName");
                    ViewBag.countryList = new SelectList(await countryServices.GetAllCountry(), "CountryId", "CountryName");
                    return View();
                }
                else
                {
                  
                    var city = await cityServices.GetCityById(Id);
                    ViewBag.stateList = new SelectList(await cityServices.GetStateByCountryId(city.CountryId), "StateId", "StateName");
                    ViewBag.countryList = new SelectList(await countryServices.GetAllCountry(), "CountryId", "CountryName");
                    return View(city);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEditCity(CityModel cityModel)
        {
            try
            {
                await cityServices.AddEditCity(cityModel);
                return RedirectToAction("GetAllCities");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<JsonResult> GetStatesByCountryId(int Id)
        {
            try
            {
                List<StateModel> stateModels = await cityServices.GetStateByCountryId(Id);
                var state = from s in stateModels select new { StateName = s.StateName, StateId = s.StateId };
                return Json(state);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
