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
        public ActionResult GetStates(int id=1)
        {

            try
            {
                List<State> stList = new List<State>();
                client.BaseAddress = new Uri("http://localhost:61138/api/StateApi");
                var response = client.GetAsync("StateApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<State>>();
                    display.Wait();
                    stList = display.Result;
                }


                const int pageSize = 5;

                int recsCount = stList.Count();
                var pager = new Pager(recsCount, id, pageSize);
                int recSkip = (id - 1) * pageSize;
                var data = stList.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;

                return View(data);
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
                client.BaseAddress = new Uri("http://localhost:61138/api/StateApi");
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
                client.BaseAddress = new Uri("http://localhost:61138/api/StateApi");
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
                client.BaseAddress = new Uri("http://localhost:61138/api/StateApi");
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
                client.BaseAddress = new Uri("http://localhost:61138/api/StateApi");
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
                StateModel st = null;
                client.BaseAddress = new Uri("http://localhost:61138/api/StateApi");
                var response = client.DeleteAsync("StateApi?StId=" + StId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetStates");
                }
                else
                {
                    return View(st);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}