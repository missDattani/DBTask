using Newtonsoft.Json;
using SchoolMgmtWEB_326.Models.Models;
using SchoolMgmtWEB_326.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolMgmtWEB_326.Controllers
{
    public class CityController : Controller
    {
        HttpClient client = new HttpClient();
        ICountryInterface countryInterface;
        public CityController(ICountryInterface countryInterface)
        {
            this.countryInterface = countryInterface;
        }
        // GET: City
        public async Task<ActionResult> GetCities()
        {
            try
            {
                List<CityModel> cityModelList = new List<CityModel>();
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.GetAsync("CityAPI/DisplayCities");
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<List<CityModel>>();
                    cityModelList = display;
                }
                else
                {
                    cityModelList = null;
                    ModelState.AddModelError(string.Empty, "Server Error,Please Contact Administrator");
                }
                return View(cityModelList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ActionResult> GetCityById(int? CtId)
        {
            try
            {
                CityModel cityModel = null;
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.GetAsync("CityAPI?CtId=" + CtId);
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<CityModel>();
                    cityModel = display;
                }
                else
                {
                    cityModel = null;
                    ModelState.AddModelError(string.Empty, "Server Error, Please Contact Administration");
                }
                return View(cityModel);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ActionResult> AddEditCity(int ? CtId)
        {
            try
            {
                ViewBag.countryList = new SelectList(countryInterface.SelectCountry(), "CountryId", "CountryName");
                 
                if (CtId == 0 || CtId == null)
                {
                    ViewBag.stateList = new SelectList(countryInterface.GetAllStates(), "StateId", "StateName");
                    return View();
                }
                else
                {
                    CityModel cityModel = null;
                   
                    client.BaseAddress = new Uri("http://localhost:55932/api/");
                    var response = await client.GetAsync("CityAPI?CtId=" + CtId);
                    var test = response.EnsureSuccessStatusCode();
                    if (test.IsSuccessStatusCode)
                    {
                        var display = await test.Content.ReadAsAsync<CityModel>();
                        cityModel = display;
                        ViewBag.stateList = new SelectList(countryInterface.SelectStates((int)cityModel.CountryId), "StateId", "StateName");
                    }
                    else
                    {
                        cityModel = null;
                        ModelState.AddModelError(string.Empty, "Server Error, Please Contact Administration");
                    }
                    return View(cityModel);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddEditCity(CityModel cityModel)
        {
            try
            {
                ViewBag.countryList = new SelectList(countryInterface.SelectCountry(), "CountryId", "CountryName");
                ViewBag.stateList = new SelectList(countryInterface.SelectStates((int)cityModel.CountryId), "StateId", "StateName");
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.PostAsJsonAsync<CityModel>("CityAPI", cityModel);
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    TempData["Success"] = "City Added Successfully";
                    return RedirectToAction("GetCities");
                }
                else
                {
                    TempData["Error"] = "Something Went Wrong";
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ActionResult> DeleteCity(int CtId)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.DeleteAsync("CityAPI?CtId=" + CtId.ToString());
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    TempData["Success"] = "City Deleted Successfully";
                    return RedirectToAction("GetCities");
                }
                else
                {
                    TempData["Error"] = "Something Went Wrong";
                    return RedirectToAction("GetCities");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public JsonResult SelectStateList(int ?CoId)
        {
            try
            {
                var state = JsonConvert.SerializeObject(countryInterface.SelectStates(CoId));
                return Json(state, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}