using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using SchoolMgmt_326.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_326.Controllers
{
    [LoginAction]
    public class CountryController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: Country
        private ICountryInterface coInterface;

        public CountryController(ICountryInterface coInterface)
        {
            this.coInterface = coInterface;
        }

        public ActionResult GetCountries()
        {
            try
            {
                IEnumerable<Country> coList = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/CountryApi");
                var response = client.GetAsync("CountryApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                
                    var display = test.Content.ReadAsAsync<IList<Country>>();
                    display.Wait();
                    coList = display.Result;
                }
                    return View(coList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetCountryDetails(int CoId)
        {
            try
            {
                CountryModel co = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/CountryApi");
                var response = client.GetAsync("CountryApi?CoId=" + CoId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<CountryModel>();
                    display.Wait();
                    co = display.Result;
                }
                return View(co);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCountry(CountryModel country)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:55339/api/CountryApi");
                var response = client.PostAsJsonAsync<CountryModel>("CountryApi", country);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCountries");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult UpdateCountry(int CoId)
        {
            try
            {
                CountryModel co = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/CountryApi");
                var response = client.GetAsync("CountryApi?CoId=" + CoId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<CountryModel>();
                    display.Wait();
                    co = display.Result;
                }
                return View(co);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult UpdateCountry(CountryModel country)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:55339/api/CountryApi");
                var response = client.PutAsJsonAsync<CountryModel>("CountryApi", country);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCountries");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult DeleteCountry(int CoId)
        {
            try
            {
                //CountryModel co = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/CountryApi");
                var response = client.DeleteAsync("CountryApi?CoId=" + CoId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCountries");
                }
                else
                {
                    TempData["Error"] = "Country Is In Use";
                }
                return RedirectToAction("GetCountries");
            }
            catch (Exception e)
            {
                TempData["Error"] = "Country Is In Use";
                throw e;
            }
        }
    }
}