using SchoolManagement_SIT326.Context;
using SchoolManagement_SIT326.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_SIT326.Controllers
{
    public class CountryController : Controller
    {
        OrderManagementEntities1 entities = new OrderManagementEntities1();
        // GET: Country
        public ActionResult GetCountries()
        {
            List<Sp_GetCountries_Result> countries = entities.Sp_GetCountries().ToList();
            return View(countries);
        }

        public ActionResult AddEditCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEditCountry(CountryModel countryM)
        {
            try
            {
                var checkCo = entities.Countries.Any(m => m.CountryName == countryM.CountryName);
                if (checkCo)
                {
                    TempData["Error"] = "Country Already exists";
                    return View();
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        Country country = new Country();
                        country = BindCountryModelToCountry(countryM);
                        entities.Countries.Add(country);
                        entities.SaveChanges();
                        return RedirectToAction("GetCountries");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult RemoveCountry(int CoId)
        {
            try
            {
                var res = entities.Countries.Where(m => m.CountryId == CoId).FirstOrDefault();
                bool Check = (entities.States.Any(m => m.CountryId == CoId) && entities.Cities.Any(m => m.CountryId == CoId));
                if (Check)
                {
                    TempData["Error"] = "Country Is In Use";
                    return RedirectToAction("GetCountries");
                }
                else
                {
                    entities.Countries.Remove(res);
                    entities.SaveChanges();
                    return RedirectToAction("GetCountries");
                }
            }
            catch (Exception e)
            {
                TempData["Error"] = "Country Is In Use";
                return RedirectToAction("GetCountries");
            }
        }

        public static Country BindCountryModelToCountry(CountryModel countrym)
        {
            Country co = new Country();
            co.CountryId = countrym.CountryId;
            co.CountryName = countrym.CountryName;
            return co;
        }
    }
}