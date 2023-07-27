using Microsoft.AspNetCore.Mvc;
using TrainingCoreProject.Model.ViewModels.User;
using TrainingCoreProject.Services.User;

namespace TrainingCoreProject.Controllers
{
    public class UserController : Controller
    {
        #region Fields
        public readonly IUserServices userServices;
        #endregion

        #region Constructor
        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await userServices.LoginUser(model);

                    if (result != null)
                    {
                        TempData["Message"] = "Login SuccessFull";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = "Invalid Email/Password";
                        return View();
                    }
                }
                else
                {
                    TempData["Error"] = "Something went wrong";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Register()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await userServices.RegisterUser(userModel);
                    if (result == 1)
                    {
                        TempData["Message"] = "User Registered";
                        return RedirectToAction("Login");
                    }
                    else if (result == 0)
                    {
                        TempData["Error"] = "User Already Exists";
                        return View();
                    }
                    else
                    {
                        TempData["Error"] = "Something went wrong";
                        return View();
                    }
                }
                else
                {
                    TempData["Error"] = "Something went wrong";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
