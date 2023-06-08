using StudentRegistration.Context;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class CountryController : Controller
    {
        PD326Entities entities = new PD326Entities();
        // GET: Country
        public ActionResult CountryIndex()
        {
            try
            {
                List<CountryModel> colist = Functions.ConvertCountry(entities.SCountries.ToList());
                return View(colist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCountry(CountryModel cm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entities.SCountries.Add(new SCountry
                    {
                        CountryId = cm.CountryId,
                        CountryName = cm.CountryName
                    });
                    entities.SaveChanges();
                    return RedirectToAction("CountryIndex");
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

        public ActionResult UpdateCountry(int Cid)
        {
            try
            {
                SCountry CoObj = entities.SCountries.Where(x => x.CountryId == Cid).FirstOrDefault();
                if (CoObj != null)
                {
                    CountryModel cot = new CountryModel();
                    cot.CountryId = CoObj.CountryId;
                    cot.CountryName = CoObj.CountryName;
                    return View(cot);
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
        public ActionResult UpdateCountry(CountryModel cot)
        {
            try
            {
                SCountry CoObj = entities.SCountries.Where(x => x.CountryId == cot.CountryId).FirstOrDefault();
                if (CoObj != null)
                {
                    CoObj.CountryId = cot.CountryId;
                    CoObj.CountryName = cot.CountryName;


                    entities.SaveChanges();
                }
                return RedirectToAction("CountryIndex");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteCountry(int Did)
        {
            try
            {
                //List<SCountry> CoList = entities.SCountries.ToList();
                SCountry CoObj = entities.SCountries.Where(x => x.CountryId == Did).FirstOrDefault();
                //entities.SCountries.Remove(CoObj);
                int check = entities.sp_DeleteCountry(Did);
                entities.SaveChanges();
                if (check == 1)
                {
                    TempData["success"] = "Deleted successfully";
                }
                else
                {
                    TempData["fail"] = "Delete fail";
                }
               
                return RedirectToAction("CountryIndex");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}