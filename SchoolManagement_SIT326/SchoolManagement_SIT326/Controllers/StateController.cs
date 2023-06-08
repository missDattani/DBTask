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
    public class StateController : Controller
    {
        public readonly IStateInterface stInterface;
        public readonly ICountryInterface coInterface;


        public StateController(IStateInterface stInterface, ICountryInterface coInterface)
        {
            this.stInterface = stInterface;
            this.coInterface = coInterface;
        }
        // GET: State
        public ActionResult GetStates()
        {
            try
            {
                List<StateModel> stList = stInterface.DisplayStates();
                return View(stList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetStateById(int StId)
        {
            try
            {
                
                StateModel sModel = stInterface.DisplayStateById(StId);
                if (sModel != null)
                {
                    return View(sModel);
                }
                else
                {
                    TempData["State"] = "State Not Found";
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult AddState(int? StId)
        {
            ViewBag.coList = coInterface.SelectCountry();
            if (StId == null)
            {
                return View();
            }
            else
            {
              
                StateModel sModel = stInterface.DisplayStateById(StId);
                return View(sModel);
             
            }
           
        }

        [HttpPost]
        public ActionResult AddState(StateModel stModel, int? StId)
        {
            try
            {
                ViewBag.coList = coInterface.SelectCountry();
                if(StId == null)
                {
                    int state = stInterface.InsStates(stModel,0);
                    if (state == 1)
                    {
                        TempData["Success"] = "State Added Successfully";
                        return RedirectToAction("GetStates");
                    }
                    else
                    {
                        TempData["Error"] = "State Already Exists";
                        return View();
                    }
                }
                else
                {
                    int stateE = stInterface.InsStates(stModel, StId);
                    if (stateE == 1)
                    {
                        TempData["Success"] = "State Edited Successfully";
                        return RedirectToAction("GetStates");
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

        public ActionResult DeleteState(int StId)
        {
            try
            {
                int res = stInterface.RemoveState(StId);
                if (res == 1)
                {
                    TempData["Success"] = "State Deleted Successfully";
                    return RedirectToAction("GetStates");
                }
                else
                {
                    TempData["Error"] = "State Is In Use";
                    return RedirectToAction("GetStates");
                }
            }
            catch 
            {

                TempData["Error"] = "State Is In Use";
                return RedirectToAction("GetStates");
            }
        }

        public JsonResult SelectStateList(int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(stInterface.SelectStates(id));
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}