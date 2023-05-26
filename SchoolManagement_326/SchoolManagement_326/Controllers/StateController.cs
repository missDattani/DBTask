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
    public class StateController : Controller
    {
      

        HttpClient client = new HttpClient();
        private IStateInterface stInterface;
        private ICountryInterface coInterface;

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
                List<State> stList = new List<State>();
                client.BaseAddress = new Uri("http://localhost:55339/api/StateApi");
                var response = client.GetAsync("StateApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<State>>();
                    display.Wait();
                    stList = display.Result;
                }

                return View(stList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetStateDetails(int StId)
        {
            try
            {
                StateModel st = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/StateApi");
                var response = client.GetAsync("StateApi?StId=" + StId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<StateModel>();
                    display.Wait();
                    st = display.Result;
                }
                return View(st);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult AddState()
        {
            ViewBag.CoList = coInterface.SelectCountry();
            return View();
        }

        [HttpPost]
        public ActionResult AddState(StateModel stateM)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                client.BaseAddress = new Uri("http://localhost:55339/api/StateApi");
                var response = client.PostAsJsonAsync<StateModel>("StateApi", stateM);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetStates");
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

        public JsonResult SelectStateList(int CoId)
        {
            try
            {
                return Json(stInterface.SelectStates(CoId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult UpdateState(int StId)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                StateModel st = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/StateApi");
                var response = client.GetAsync("StateApi?StId=" + StId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<StateModel>();
                    display.Wait();
                    st = display.Result;
                }
                return View(st);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UpdateState(StateModel stateM)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                client.BaseAddress = new Uri("http://localhost:55339/api/StateApi");
                var response = client.PutAsJsonAsync<StateModel>("StateApi", stateM);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetStates");
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

        public ActionResult DeleteState(int StId)
        {
            try
            {
                //StateModel st = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/StateApi");
                var response = client.DeleteAsync("StateApi?StId=" + StId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetStates");
                }
                else
                {
                    TempData["Error"] = "State Is In Use";
                }

                return RedirectToAction("GetStates");

            }
            catch (Exception)
            {
                TempData["Error"] = "State Is In Use";
                return RedirectToAction("GetStates");
            }
        }
    }
}