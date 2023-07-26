using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SchoolMgmt_System.Filter;
using SchoolMgmt_System.Model.ViewModels;
using SchoolMgmt_System.Services.City;
using SchoolMgmt_System.Services.Country;
using SchoolMgmt_System.Services.State;

namespace SchoolMgmt_System.Controllers
{
    [TypeFilter(typeof(JwtTokenFilter))]
    public class CityController : Controller
    {
        #region Fields
        public ICityServices cityService;
        public ICountryServices countryService;
        public IStateServices stateService;
        #endregion

        #region Constructor
        public CityController(ICityServices cityService, ICountryServices countryService, IStateServices stateService) 
        { 
            this.cityService = cityService;
            this.countryService = countryService;
            this.stateService = stateService;
        }
        #endregion
        public async Task<IActionResult> CityList()
        {
            try
            {

                List<CityModel> citylist = await cityService.GetAllCity();
                return View(citylist);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> GetCityById(int Id)
        {
            try
            {
                CityModel cityModel = await cityService.GetCityById(Id);
                return View(cityModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> AddEditCity(int Id)
        {
            if (Id == 0)
            {
                ViewBag.ID = Id;
                ViewBag.stateList = new SelectList(await stateService.GetAllStates(),"StId","StateName");
                ViewBag.countryList = new SelectList(await countryService.GetAllCountries(), "CoId", "CountryName");
                return View();
            }
            else
            {
                ViewBag.ID = Id;
                var city = await cityService.GetCityById(Id);
                ViewBag.stateList = new SelectList(await cityService.GetStateByCountry(city.CoId), "StId", "StateName");
                ViewBag.countryList = new SelectList(await countryService.GetAllCountries(), "CoId", "CountryName");
                return View(city);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEditCity(CityModel cityModel)
        {
            try
            {
                var City = await cityService.AddEditCity(cityModel);
                if (City == 0 && cityModel.CiId == 0)
                {
                    TempData["Available"] = "City Already Exists";
                    return RedirectToAction("AddEditCity");
                }
                else if (cityModel.CiId == 0 && City != 0)
                {
                    TempData["Register"] = "City added Successfully";
                    return RedirectToAction("CityList");
                }
                else if (cityModel.CiId != 0 && City != 0)
                {
                    TempData["Update"] = "City Updated Successfully";
                    return RedirectToAction("CityList");
                }
                else
                {
                    return RedirectToAction("CityList");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<JsonResult> GetStatesByCountyId(int Id)
        {
            try
            {
                List<StateModel> stateData = await cityService.GetStateByCountry(Id);
                var state = from s in stateData select new { StateName = s.StateName, StId = s.StId };
                var JsonString = JsonConvert.SerializeObject(state);
                return Json(JsonString);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
