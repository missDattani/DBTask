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
    public class CountryController : Controller
    {
        public readonly ICountryInterface coInterface;

        public CountryController(ICountryInterface coInterface)
        {
            this.coInterface = coInterface;
        }
        // GET: Country
        public ActionResult GetCountries()
        {
            try
            {
                List<CountryModel> coModel = coInterface.DisplayCountries();
                return View(coModel);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetCountryById(int CoId)
        {
           
            CountryModel coModel = coInterface.DisplayCountryById(CoId);
            if (coModel != null)
            {
                return View(coModel);
            }
            else
            {
                TempData["Country"] = "Country Not Found";
                return View();
            }
        }

        public ActionResult AddCountry(int? CoId)
        {
            try
            {
                if (CoId == 0)
                {
                    return View();
                }
                else
                {
                    
                    CountryModel coModel = coInterface.DisplayCountryById(CoId);
                    return View(coModel);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        [HttpPost]
        public ActionResult AddCountry(CountryModel countryM,int? CoId)
        {
            try
            {
              
                    if (CoId == null)
                    {
                        int co = coInterface.InsCountries(countryM, 0);
                        if (co == 1)
                        {
                            TempData["Success"] = "Country Added Successfully";
                            return RedirectToAction("GetCountries");
                        }
                        else
                        {
                            TempData["Error"] = "Country Already Exists";
                            return View();
                        }

                    }
                    else
                    {
                       int coE = coInterface.InsCountries(countryM, CoId);
                        if (coE == 1)
                        {
                            TempData["Success"] = "Country Edited Successfully";
                            return RedirectToAction("GetCountries");
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

        public ActionResult DeleteCountry(int CoId)
        {
            try
            {
                int res = coInterface.RemoveCountry(CoId);
                if (res == 1)
                {
                    TempData["Success"] = "Country Deleted Successfully";
                    return RedirectToAction("GetCountries");
                }
                else
                {
                    TempData["Error"] = "Country Is In Use";
                    return RedirectToAction("GetCountries");
                }
            }
            catch 
            {

                TempData["Error"] = "Country Is In Use";
                return RedirectToAction("GetCountries");
            }
        }
    }
}