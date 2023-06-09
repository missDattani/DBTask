using Newtonsoft.Json;
using SchoolManagement_SIT326.Helpers.Helpers;
using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using SchoolManagement_SIT326.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_SIT326.Controllers
{
    [LoginAction]
    public class CityController : Controller
    {
        public readonly ICityInterface ctInterface;
        public readonly ICountryInterface coInterface;


        public CityController(ICityInterface ctInterface, ICountryInterface coInterface)
        {
            this.ctInterface = ctInterface;
            this.coInterface = coInterface;

        }
        // GET: City
        public ActionResult GetCities()
        {
            try
            {
                List<CityModel> ctList = ctInterface.DisplayCities();
                return View(ctList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetCityById(int CtId)
        {
            try
            {
                CityModel city = ctInterface.DisplayCityById(CtId);
        
                if (city != null)
                {
                    return View(city);
                }
                else
                {
                    TempData["City"] = "City Not Found";
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public ActionResult AddCity(int? CtId)
        {
            try
            {
                ViewBag.coList = coInterface.SelectCountry();
                if (CtId == null)
                {
                    return View();
                }
                else
                {
                    CityModel ctM = ctInterface.DisplayCityById(CtId);
                
                    return View(ctM);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        [HttpPost]
        public ActionResult AddCity(CityModel ctModel, int? CtId)
        {

            try
            {
                ViewBag.coList = coInterface.SelectCountry();
                if (CtId == null)
                {
                    int city = ctInterface.InsCity(ctModel, 0);
                    if (city == 1)
                    {
                        TempData["Success"] = "City Added Successfully";
                        return RedirectToAction("GetCities");
                    }
                    else
                    {
                        TempData["Error"] = "City Already Exists";
                        return View();
                    }
                }
                else
                {
                    int cityE = ctInterface.InsCity(ctModel, CtId);
                    if (cityE == 1)
                    {
                        TempData["Success"] = "City Edited Successfully";
                        return RedirectToAction("GetCities");
                    }
                    else
                    {
                        TempData["Error"] = "Something Went Wrong";
                        return View();
                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        public ActionResult DeleteCity(int CtId)
        {
            try
            {
                int res = ctInterface.RemoveCity(CtId);
                if (res == 1)
                {
                    TempData["Success"] = "City Deleted Successfully";
                    return RedirectToAction("GetCities");
                }
                else
                {
                    TempData["Error"] = "City Is In Use";
                    return RedirectToAction("GetCities");
                }
            }
            catch 
            {

                TempData["Error"] = "City Is In Use";
                return RedirectToAction("GetCities");
            }
        }

        public JsonResult SelectCityList(int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(ctInterface.SelectCity(id));
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}