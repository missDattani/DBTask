using SchoolMgmtWEB_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolMgmtWEB_326.Controllers
{
    public class CountryController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: Country
        public async Task<ActionResult> GetCountries()
        {
            try
            {
                List<CountryModel> countryModelList = new List<CountryModel>();
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.GetAsync("CountryAPI/DisplayCountry");
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<List<CountryModel>>();
                    countryModelList = display;
                }
                else
                {
                    countryModelList = null;
                    ModelState.AddModelError(string.Empty, "Server Error, Please Contact Administrator");

                }

                return View(countryModelList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ActionResult> GetCountryById(int? CoId)
        {
            try
            {
                CountryModel countryModel = null;
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.GetAsync("CountryAPI?CoId=" + CoId);
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<CountryModel>();
                    countryModel = display;
                }
                else
                {
                    countryModel = null;
                    ModelState.AddModelError(string.Empty, "Server Error,Please Contact Administration");
                }
                return View(countryModel);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ActionResult> AddEditCountry(int? CoId)
        {
            try
            {
                if (CoId == null || CoId == 0)
                {
                    return View();
                }
                else
                {
                    CountryModel countryModel = null;
                    client.BaseAddress = new Uri("http://localhost:55932/api/");
                    var response = await client.GetAsync("CountryAPI?CoId=" + CoId.ToString());
                    var test = response.EnsureSuccessStatusCode();
                    if (test.IsSuccessStatusCode)
                    {
                        var display = await test.Content.ReadAsAsync<CountryModel>();
                        countryModel = display;
                    }
                    else
                    {
                        countryModel = null;
                        ModelState.AddModelError(string.Empty, "Server Error,Please Contact Administration");
                    }
                    return View(countryModel);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddEditCountry(CountryModel countryModel)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.PostAsJsonAsync<CountryModel>("CountryAPI", countryModel);
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Country Added Successfully";
                    return RedirectToAction("GetCountries");
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

        public async Task<ActionResult> DeleteCountry(int CoId)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.DeleteAsync("CountryAPI?CoId=" + CoId.ToString());
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Country Deleted Successfully";
                    return RedirectToAction("GetCountries");
                }
                else
                {
                    TempData["Error"] = "Something Went Wrong";
                    return RedirectToAction("GetCountries");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}