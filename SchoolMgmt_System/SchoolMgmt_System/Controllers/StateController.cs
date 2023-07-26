using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMgmt_System.Filter;
using SchoolMgmt_System.Model.ViewModels;
using SchoolMgmt_System.Services.Country;
using SchoolMgmt_System.Services.State;

namespace SchoolMgmt_System.Controllers
{
    [TypeFilter(typeof(JwtTokenFilter))]
    public class StateController : Controller
    {
        #region Fields
        public IStateServices stateServices;
        public ICountryServices countryServices;
        #endregion

        #region Constructor
        public StateController(IStateServices stateServices, ICountryServices countryServices)
        {
            this.stateServices = stateServices;
            this.countryServices = countryServices;
        }
        #endregion
        public async Task<IActionResult> StateList()
        
        {
            try
            {
                
                List<StateModel> statelist = await stateServices.GetAllStates();
                return View(statelist);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> GetStateById(int Id)
        {
            try
            {
                StateModel stateModel = await stateServices.GetStateById(Id);
                return View(stateModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> AddEditState(int Id)
        {
            if(Id == 0) 
            {
                ViewBag.countryList = new SelectList(await countryServices.GetAllCountries(), "CoId", "CountryName");
                return View();
            }
            else
            {
                ViewBag.countryList = new SelectList(await countryServices.GetAllCountries(), "CoId", "CountryName");
                var data = await stateServices.GetStateById(Id);
                return View(data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEditState(StateModel stateModel)
        {
            try
            {
                await stateServices.AddEditStates(stateModel);
                return RedirectToAction("StateList");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> DeleteState(int Id)
        {
            try
            {
                var index = await stateServices.DeleteState(Id);
                if (index != 0)
                {
                    ViewBag.Error = "State Is In Use";
                    return RedirectToAction("StateList");
                }
                else
                {
                    return RedirectToAction("StateList");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
