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
    public class CityController : Controller
    {
        HttpClient client = new HttpClient();
        private ICityInterface ctInterface;
        private ICountryInterface coInterface;


        public CityController(ICityInterface ctInterface, ICountryInterface coInterface)
        {
            this.ctInterface = ctInterface;
            this.coInterface = coInterface;

        }
        // GET: City
        public ActionResult GetCities(int id=1)
        {
            try
            {
                List<City> ctList = new List<City>();
                client.BaseAddress = new Uri("http://localhost:61138/api/CityApi");
                var response = client.GetAsync("CityApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<City>>();
                    display.Wait();
                    ctList = display.Result;
                }

                const int pageSize = 5;

                int recsCount = ctList.Count();
                var pager = new Pager(recsCount, id, pageSize);
                int recSkip = (id - 1) * pageSize;
                var data = ctList.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;

                return View(data);

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
                client.BaseAddress = new Uri("http://localhost:61138/api/CityApi");
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

        public ActionResult AddCities()
        {
            ViewBag.CoList = coInterface.SelectCountry();
            return View();
        }

        [HttpPost]
        public ActionResult AddCities(CityModel cityM)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                client.BaseAddress = new Uri("http://localhost:61138/api/CityApi");
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

        public JsonResult SelectCityList(int CoId,int StId)
        {
            try
            {
                return Json(ctInterface.SelectCities(CoId, StId), JsonRequestBehavior.AllowGet);
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
                client.BaseAddress = new Uri("http://localhost:61138/api/CityApi");
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
                client.BaseAddress = new Uri("http://localhost:61138/api/CityApi");
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
                CityModel ct = null;
                client.BaseAddress = new Uri("http://localhost:61138/api/CityApi");
                var response = client.DeleteAsync("CityApi?CiId=" + CiId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCities");
                }
                else
                {
                    return View(ct);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}