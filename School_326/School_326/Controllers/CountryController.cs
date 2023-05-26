using School_326.Models.Context;
using School_326.Models.Models;
using School_326.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace School_326.Controllers
{
    public class CountryController : Controller
    {
        HttpClient client = new HttpClient();

        // GET: Country
        public ActionResult GetCountries(int id=1)
        {
            try
            {
                List<Country> coList = new List<Country>();
                client.BaseAddress = new Uri("http://localhost:61138/api/CountryApi");
                var response = client.GetAsync("CountryApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<Country>>();
                    display.Wait();
                    coList = display.Result;
                }

                const int pageSize = 5;

                int recsCount = coList.Count();
                var pager = new Pager(recsCount, id, pageSize);
                int recSkip = (id - 1) * pageSize;
                var data = coList.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;

                return View(data);
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
                client.BaseAddress = new Uri("http://localhost:61138/api/CountryApi");
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
                client.BaseAddress = new Uri("http://localhost:61138/api/CountryApi");
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
                client.BaseAddress = new Uri("http://localhost:61138/api/CountryApi");
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
       public ActionResult UpdateCountry(CountryModel countryM)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:61138/api/CountryApi");
                var response = client.PutAsJsonAsync<CountryModel>("CountryApi", countryM);
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
                CountryModel co = null;
                client.BaseAddress = new Uri("http://localhost:61138/api/CountryApi");
                var response = client.DeleteAsync("CountryApi?CoId=" + CoId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCountries");
                }
                else
                {
                    return View(co);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}