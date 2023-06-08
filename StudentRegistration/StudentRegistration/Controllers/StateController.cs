using StudentRegistration.Context;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class StateController : Controller
    {
        PD326Entities entities = new PD326Entities();
        // GET: State
        public ActionResult StateIndex()
        {
            try
            {
                List<StateModel> stlist = Functions.ConvertState(entities.SStates.ToList());
                return View(stlist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AddState()
        {
            ViewBag.CountryList = new SelectList(StudentController.GetCountryList(), "CountryId", "CountryName");
            return View();
        }
        [HttpPost]
        public ActionResult AddState(StateModel state)
        {
            try
            {
                ViewBag.CountryList = new SelectList(StudentController.GetCountryList(), "CountryId", "CountryName");
            
                    entities.SStates.Add(new SState
                    {
                        StateId = state.StateId,
                        StateName = state.StateName,
                        CountryId = state.CountryId
                    });
                    entities.SaveChanges();
                    return RedirectToAction("StateIndex");
         
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateState(int Sid)
        {
            try
            {
                ViewBag.CountryList = new SelectList(StudentController.GetCountryList(), "CountryId", "CountryName");
                SState SObj = entities.SStates.Where(x => x.StateId == Sid).FirstOrDefault();
                if (SObj != null)
                {
                    StateModel st = new StateModel();
                    st.StateId = SObj.StateId;
                    st.StateName = SObj.StateName;
                    st.CountryId = Convert.ToInt32(SObj.CountryId);
                    return View(st);
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
        public ActionResult UpdateState(StateModel st)
        {
            try
            {
                ViewBag.CountryList = new SelectList(StudentController.GetCountryList(), "CountryId", "CountryName");
                SState SObj = entities.SStates.Where(x => x.StateId == st.StateId).FirstOrDefault();
                if (SObj != null)
                {
                    SObj.StateId = st.StateId;
                    SObj.StateName = st.StateName;
                    SObj.CountryId = Convert.ToInt32(st.CountryId);

                    entities.SaveChanges();
                }
                return RedirectToAction("StateIndex");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteState(int Sid)
        {
            try
            {
                //List<SState> SList = entities.SStates.ToList();
                SState SObj = entities.SStates.Where(x => x.StateId == Sid).FirstOrDefault();
                //entities.SStates.Remove(SObj);
                int check = entities.sp_DeleteState(Sid);
                entities.SaveChanges();
                if (check == 1)
                {
                    TempData["success"] = "Deleted successfully";
                }
                else
                {
                    TempData["fail"] = "Delete fail";
                }
                return RedirectToAction("StateIndex");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}