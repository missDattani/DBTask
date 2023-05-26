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
    public class CityController : Controller
    {
        HttpClient client = new HttpClient();
       
        private ICityInterface ciInterface;
        private ICountryInterface coInterface;

        public CityController(ICityInterface ciInterface,ICountryInterface coInterface)
        {
            this.ciInterface = ciInterface;
            this.coInterface = coInterface;
        }

        // GET: City
        public ActionResult GetCities()
        {
            try
            {
                List<City> ctList = new List<City>();                           
                client.BaseAddress = new Uri("http://localhost:55339/api/CityApi");
                var response = client.GetAsync("CityApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<City>>();
                    display.Wait();
                    ctList = display.Result;
                }

                return View(ctList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetCityDetails(int CiId)
        {
            try
            {
                CityModel ct = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/CityApi");
                var response = client.GetAsync("CityApi?CiId=" + CiId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<CityModel>();
                    display.Wait();
                    ct = display.Result;
                }
                return View(ct);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public JsonResult SelectCityList(int CoId, int StId)
        {
            try { 
            return Json(ciInterface.SelectCity(CoId, StId), JsonRequestBehavior.AllowGet);
            }
            catch(Exception e) { throw e; }
        }

        public ActionResult AddCity()
        {
            try { 
            ViewBag.CoList = coInterface.SelectCountry();
            return View();
            }
            catch(Exception e) { throw e; }
        }



        [HttpPost]
        public ActionResult AddCity(CityModel cityM)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                client.BaseAddress = new Uri("http://localhost:55339/api/CityApi");
                var response = client.PostAsJsonAsync<CityModel>("CityApi", cityM);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCities");
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

        public ActionResult UpdateCity(int CiId)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                CityModel ct = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/CityApi");
                var response = client.GetAsync("CityApi?CiId=" + CiId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<CityModel>();
                    display.Wait();
                    ct = display.Result;
                }
                return View(ct);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UpdateCity(CityModel cityM)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                client.BaseAddress = new Uri("http://localhost:55339/api/CityApi");
                var response = client.PutAsJsonAsync<CityModel>("CityApi", cityM);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCities");
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

        public ActionResult DeleteCity(int CiId)
        {
            try
            {
                
                client.BaseAddress = new Uri("http://localhost:55339/api/CityApi");
                var response = client.DeleteAsync("CityApi?CiId=" + CiId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCities");
                }
                else
                {
                    TempData["Error"] = "City Is In Use";
                }
                return RedirectToAction("GetCities");
            }
            catch (Exception)
            {
                TempData["Error"] = "City Is In Use";
                return RedirectToAction("GetCities");
            }
        }
    }
}