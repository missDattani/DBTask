using StudentRegistration.Context;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class CityController : Controller
    {
        PD326Entities entities = new PD326Entities();
        // GET: City
        public ActionResult CityIndex()
        {
            try
            {
                List<CityModel> ctlist = Functions.ConvertCity(entities.SCities.ToList());
                return View(ctlist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult GetStateList(int CountryId)
        {
            List<SState> statelist = entities.SStates.Where(x => x.CountryId == CountryId).ToList();
            ViewBag.Slist = new SelectList(statelist, "StateId", "StateName");
            return PartialView("DisplayStates");
        }

        public ActionResult AddCity()
        {
            ViewBag.CountryList = new SelectList(StudentController.GetCountryList(), "CountryId", "CountryName");
            return View();
        }

        [HttpPost]
        public ActionResult AddCity(CityModel cm)
        {
            try
            {
                ViewBag.CountryList = new SelectList(StudentController.GetCountryList(), "CountryId", "CountryName");
               
                entities.SCities.Add(new SCity
                    {
                        CityId = cm.CityId,
                        CityName = cm.CityName,
                        StateId = cm.StateId,
                        CountryId = cm.CountryId
                    });
                    entities.SaveChanges();
                    return RedirectToAction("CityIndex");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateCity(int CiId)
        {
            try
            {
                ViewBag.CountryList = new SelectList(StudentController.GetCountryList(), "CountryId", "CountryName");
                SCity CiObj = entities.SCities.Where(x => x.CityId == CiId).FirstOrDefault();
                if (CiObj != null)
                {
                    CityModel city = new CityModel();
                    city.CityId = CiObj.CityId;
                    city.CityName = CiObj.CityName;
                    city.CountryId = Convert.ToInt32(CiObj.CountryId);
                    return View(city);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult UpdateCity(CityModel city)
        {
            try
            {
                ViewBag.CountryList = new SelectList(StudentController.GetCountryList(), "CountryId", "CountryName");
                SCity CiObj = entities.SCities.Where(x => x.CityId == city.CityId).FirstOrDefault();
                if (CiObj != null)
                {
                    CiObj.CityId = city.CityId;
                    CiObj.CityName = city.CityName;
                    CiObj.StateId = Convert.ToInt32(city.StateId);
                    CiObj.CountryId = Convert.ToInt32(city.CountryId);
                    entities.SaveChanges();
                }
                return RedirectToAction("CityIndex");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteCity(int CiId)
        {
            try
            {
                //List<SCity> CiList = entities.SCities.ToList();
                SCity CiObj = entities.SCities.Where(x => x.CityId == CiId).FirstOrDefault();
                //entities.SCities.Remove(CiObj);
                int check = entities.sp_DeleteCity(CiId);
                entities.SaveChanges();
                if (check == 1)
                {
                    TempData["success"] = "Deleted successfully";
                }
                else
                {
                    TempData["fail"] = "Delete fail";
                }
                return RedirectToAction("CityIndex");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}