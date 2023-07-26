using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using SchoolMgmt_System.Model.ViewModels;
using SchoolMgmt_System.Services.JWTAuthentication;
using SchoolMgmt_System.Services.Users;

namespace SchoolMgmt_System.Controllers
{
    public class UserController : Controller
    {
        #region Fields
        private IUserServices _services;
        private IJWTAuthServices jWTAuthServices;
        private readonly JWTAuthenticationModel _model;


        #endregion

        #region Constructor
        public UserController(IUserServices services,IOptions<JWTAuthenticationModel> model, IJWTAuthServices jWTAuthServices)
        {
            _services = services;
            this.jWTAuthServices = jWTAuthServices;
            _model = model.Value;
        }
        #endregion
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
        public async Task<IActionResult> Login(LoginModel logiinModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _services.LoginUser(logiinModel);
                    if (user != null)
                    {
                        string JWTtoken = jWTAuthServices.GenerateJwtToken(user.Email, user.Id.ToString(), _model.SecretKey, _model.ValidateMin);

                        if(JWTtoken != null)
                        {
                            HttpContext.Session.SetString("userToken",JWTtoken);
                            TempData["Login"] = "Login Successfull";
                            return RedirectToAction("Index", "Home");
                        }
                       
                    }
                   
                        ViewBag.Error = "Invalid Email/Password";
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

        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userInfo = await _services.RegisterUser(userModel);
                    if (userInfo == -1)
                    {
                        ViewBag.Error = "User Already Exists";
                        return View();
                    }
                    else if (userInfo == 1)
                    {
                        TempData["Register"] = "User Registered";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.Error = "Something Went Wrong";
                        return View();
                    }
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

        public IActionResult ForgotPassword() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotData userData)
        {
            ForgotData success = await _services.GetUserDetailsByEmail(userData);
            if(success != null)
            {
                var email = new MimeMessage();
                var buider = new BodyBuilder();
                buider.HtmlBody = $"<h2>FirstName :{success.FirstName} </h2><br><h2>LastName :{success.LastName} </h2><br><h2>Email :{success.Email} </h2><br><h2>Password :{success.Password}</h2><br>";
                email.Body = buider.ToMessageBody();
                
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = "User Not Registered";
                return View();
            }
        }
    }
}
