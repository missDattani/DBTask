using SchoolMgmtWEB_326.Models.Models;
using SchoolMgmtWEB_326.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolMgmtWEB_326.Controllers
{
    public class StateController : Controller
    {
        HttpClient client = new HttpClient();
        ICountryInterface countryInterface;
        public StateController(ICountryInterface countryInterface)
        {
            this.countryInterface = countryInterface;
        }
        // GET: State
        public async Task<ActionResult> GetStates()
        {
            try
            {
                List<StateModel> stateModelList = new List<StateModel>();
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.GetAsync("StateAPI/DisplayStates");
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<List<StateModel>>();
                    stateModelList = display;
                }
                else
                {
                    stateModelList = null;
                    ModelState.AddModelError(string.Empty, "Server Error, Please Contact Administration");
                }
                return View(stateModelList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ActionResult> GetStateById(int? StId)
        {
            try
            {
                StateModel stateModel = null;
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.GetAsync("StateAPI?StId=" + StId);
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<StateModel>();
                    stateModel = display;
                }
                else
                {
                    stateModel = null;
                    ModelState.AddModelError(string.Empty, "Server Error,Please Contact Administration");
                }
                return View(stateModel);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ActionResult> AddEditState(int? StId)
        {
            try
            {
                ViewBag.countryList = countryInterface.SelectCountry();
                if (StId == 0 || StId == null)
                {
                    return View();
                }
                else
                {
                    StateModel stateModel = null;
                    client.BaseAddress = new Uri("http://localhost:55932/api/");
                    var response = await client.GetAsync("StateAPI?StId=" + StId);
                    var test = response.EnsureSuccessStatusCode();
                    if (test.IsSuccessStatusCode)
                    {
                        var display = await test.Content.ReadAsAsync<StateModel>();
                        stateModel = display;
                    }
                    else
                    {
                        stateModel = null;
                        ModelState.AddModelError(string.Empty, "Server Error,Please Contact Administration");
                    }
                    return View(stateModel);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddEditState(StateModel stateModel)
        {
            try
            {
                ViewBag.countryList = countryInterface.SelectCountry();

                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.PostAsJsonAsync<StateModel>("StateAPI", stateModel);
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    TempData["Success"] = "State Added Successfully";
                    return RedirectToAction("GetStates");
                }
                else
                {
                    TempData["Error"] = "Something Went Wrong";
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ActionResult> DeleteState(int StId)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.DeleteAsync("StateAPI?StId=" + StId.ToString());
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    TempData["Success"] = "State Deleted Successfully";
                    return RedirectToAction("GetStates");
                }
                else
                {
                    TempData["Error"] = "Something Went Wrong";
                    return RedirectToAction("GetStates");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}