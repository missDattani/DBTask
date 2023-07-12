using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using SchoolSystem326.Filter;
using SchoolSystem326.Model.ViewModels;
using SchoolSystem326.Services.Country;
using SchoolSystem326.Services.JWTAuthentication;
using SchoolSystem326.Services.State;

namespace SchoolSystem326.Controllers
{
    [TypeFilter(typeof(JwtTokenFilter))]
    public class StateController : Controller
    {
        #region Fields
        public IStateServices stateServices;
        public ICountryServices countryServices;
      
        #endregion

        #region Constructor
        public StateController(IStateServices stateServices,ICountryServices countryServices)
        {
            this.stateServices = stateServices;
            this.countryServices = countryServices;
         
        }
        #endregion
        public async Task<IActionResult> GetAllStates()
        {
            try
            {
                List<StateModel> stateModels = await stateServices.GetAllStates();
                return View(stateModels);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IActionResult> AddEditState(int Id) 
        {
            try
            {
                ViewBag.countryList = new SelectList(await countryServices.GetAllCountry(),"CountryId","CountryName");
                if (Id == 0)
                {
                    return View();
                }
                else
                {
                    var state = await stateServices.GetStateById(Id);
                    return View(state);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEditState(StateModel stateModel)
        {
            try
            {
                await stateServices.AddEditState(stateModel);
                return RedirectToAction("GetAllStates");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
