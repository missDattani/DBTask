using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using SchoolSystem326.Filter;
using SchoolSystem326.Model.ViewModels;
using SchoolSystem326.Services.City;
using SchoolSystem326.Services.Country;
using SchoolSystem326.Services.JWTAuthentication;
using SchoolSystem326.Services.State;
using SchoolSystem326.Services.User;

namespace SchoolSystem326.Controllers
{
    public class UserController : Controller
    {
        #region Fields
        public IUserServices userServices;
        public ICityServices cityServices;
        public ICountryServices countryServices;
        public IStateServices stateServices;
        private IJWTAuthServices jWTAuthServices;
        private readonly JWTAuthenticationModel jWTAuthentication;
        
        #endregion

        #region Constructor
        public UserController(IUserServices userServices, ICityServices cityServices, ICountryServices countryServices, IStateServices stateServices, IJWTAuthServices jWTAuthServices, IOptions<JWTAuthenticationModel> options)
        {
            this.userServices = userServices;
            this.cityServices = cityServices;
            this.countryServices = countryServices;
            this.stateServices = stateServices;
            this.jWTAuthServices = jWTAuthServices;
            jWTAuthentication = options.Value;
        }
        #endregion


        [TypeFilter(typeof(JwtTokenFilter))]
        public async Task<IActionResult> GetUsers()
        {
            

            List<UserModel> userList = await userServices.GetAllUsers();
            return View(userList);
            
            
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userServices.LoginUser(loginModel);

                    if (user != null)
                    {
                        string JWTToken = jWTAuthServices.GenerateToken(user.Email, user.Id.ToString(), jWTAuthentication.SecretKey, jWTAuthentication.ValidateMin);

                        if (JWTToken != null)
                        {
                            HttpContext.Session.SetString("userToken", JWTToken);
                            TempData["Login"] = "Login Successful";
                            return RedirectToAction("GetUsers");
                        }
                    }

                    TempData["Error"] = "Invalid Email / Password";
                    return View();
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IActionResult> SignUp(int Id)
        {
            if(Id == 0)
            {
                ViewBag.cityList = new SelectList(await cityServices.GetAllCities(),"CityId","CityName");
                ViewBag.stateList = new SelectList(await stateServices.GetAllStates(), "StateId", "StateName");
                ViewBag.countryList = new SelectList(await countryServices.GetAllCountry(), "CountryId", "CountryName");

                return View();
            }
            else
            {
                var user = await userServices.GetUserById(Id);
                ViewBag.cityList = new SelectList(await cityServices.GetCityByStateId(user.StateId), "CityId", "CityName");
                ViewBag.stateList = new SelectList(await cityServices.GetStateByCountryId(user.CountryId), "StateId", "StateName");
                ViewBag.countryList = new SelectList(await countryServices.GetAllCountry(), "CountryId", "CountryName");
                return View(user);
            }
            
        }

        [HttpPost]
        public  async Task<IActionResult> SignUp(UserModel userModel)
        {
            var userInfo = await userServices.RegisterUser(userModel);
            if(userInfo == 0)
            {
                TempData["Error"] = "User Already Exists";
                return View();
            }
            else if (userInfo == 1)
            {
                TempData["Register"] = "User Registered";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["Error"] = "Something Went Wrong";
                return View();
            }
        }

        public async Task<JsonResult> GetStatesByCountryId(int Id)
        {
            try
            {
                List<StateModel> stateModels = await cityServices.GetStateByCountryId(Id);
                var state = from s in stateModels select new { StateName = s.StateName, StateId = s.StateId };
                return Json(state);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<JsonResult> GetCityByStateId(int Id)
        {
            try
            {
                List<CityModel> cityModels = await cityServices.GetCityByStateId(Id);
                var city = from c in cityModels select new {CityName = c.CityName, CityId = c.CityId};
                return Json(city);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
