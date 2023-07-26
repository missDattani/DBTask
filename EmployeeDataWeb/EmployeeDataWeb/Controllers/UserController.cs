using EmployeeDataWeb.Common.Helpers;
using EmployeeDataWeb.Model.JwtTokenAuthModel;
using EmployeeDataWeb.Model.ViewModels.SMTPSettings;
using EmployeeDataWeb.Model.ViewModels.Token;
using EmployeeDataWeb.Model.ViewModels.User;
using EmployeeDataWeb.Services.JwtAuthenticationServices;
using EmployeeDataWeb.Services.User;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace EmployeeDataWeb.Controllers
{
    public class UserController : Controller
    {
        #region Fields
        public IUserServices userServices;
        public IJwtAuthServices jwtAuthServices;
        public SMTPSettings smtpSettings;
        public JwtAuthModel jwtAuthModel;
        #endregion

        #region Constructor
        public UserController(IUserServices userServices,IOptions<SMTPSettings> smtpSettings,IJwtAuthServices jwtAuthServices,IOptions<JwtAuthModel> jwtModel)
        {
            this.userServices = userServices;
            this.jwtAuthServices = jwtAuthServices;
            this.smtpSettings = smtpSettings.Value;
            jwtAuthModel = jwtModel.Value;
        }
        #endregion

        #region Methods
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
                    var user = await userServices.LoginUser(model);
                    if (!string.IsNullOrEmpty(user.Email))
                    {
                        UserTokenData userToken = new UserTokenData();
                        userToken.Email = user.Email;
                        var userData = await userServices.GetUserByEmail(user.Email);
                        userToken.Id = userData.Id;
                        user.Id = userData.Id;
                        userToken.Id = user.Id != 0 ? user.Id : 0;

                        AccessTokenData accessTokenData = new AccessTokenData();
                        string JwtToken = jwtAuthServices.GetJwtToken(user.Email, user.Id.ToString(), jwtAuthModel.SecretKey, jwtAuthModel.ValidateMin);
                        accessTokenData.Token = JwtToken;
                        accessTokenData.Id = user.Id;
                        accessTokenData.ValidityMin = jwtAuthModel.ValidateMin;

                        await userServices.UpdateTokenData(accessTokenData.Token, accessTokenData.Id);

                        if(!string.IsNullOrEmpty(JwtToken))
                        {
                            HttpContext.Session.SetString("userToken", accessTokenData.Token);
                            HttpContext.Session.SetString("userName",user.Email);
                            TempData["Login"] = "Login Successfull";
                            return RedirectToAction("EmployeeList", "Employee");
                        }
                        else
                        {
                            TempData["Error"] = "Something Went Wrong";
                            return View();
                        }
                        
                    }
                    else
                    {
                        TempData["Error"] = "Invalid Email/Password";
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

        public IActionResult ChangePassword()
        {
            if(HttpContext.Session.GetString("_ForgotData") != null)
            {
                return View();
            }
            else
            {
                TempData["Error"] = "Something Went Wrong";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel passwordModel)
        {
            try
            {
                var success = await userServices.UpdatePassword(TempData["Email"]?.ToString(), passwordModel.NewPassword);
                TempData.Keep("Email");

                if (success == 2)
                {
                    HttpContext.Session.Clear();
                    HttpContext.Session.Remove("_ForgotData");
                    TempData["Message"] = "Password Changed Successfully";
                    return RedirectToAction("Login");
                }
                else
                {
                    //TempData["Error"] = "Something Went Wrong";
                    return RedirectToAction("Login");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult AddOTP() 
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
        public async Task<IActionResult> AddOTP(OTPModel model)
        {
            try
            {
                var success = await userServices.VerifyOTP(model.OTP, TempData["Email"].ToString());
                TempData.Keep("Email");

                if (success != 0)
                {
                    HttpContext.Session.SetString("_ForgotData", TempData["Email"].ToString());
                    return RedirectToAction("ChangePassword");
                }
                else
                {
                    TempData["Error"] = "Invalid OTP";
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
        public async Task<IActionResult> ForgotPassword(LoginModel loginModel)
        {
            try
            {
                var userData = await userServices.GetUserByEmail(loginModel.Email);
                if (!string.IsNullOrEmpty(userData.Email))
                {
                    var emailMessage = new MimeMessage();
                    emailMessage.Sender = MailboxAddress.Parse(smtpSettings.FromEmail);
                    emailMessage.To.Add(MailboxAddress.Parse(userData.Email));
                    emailMessage.Subject = "Forgot Id/Password Email";
                    var builder = new BodyBuilder();

                    Random random = new Random();
                    int OTP = random.Next(100000, 999999);

                    await userServices.UpdateOTP(OTP, userData.Id);

                    string filePath = Directory.GetCurrentDirectory() + "\\Templates\\EmailTemplate.html";
                    string emailTemplateText = EmailTemplateHelper.GetEmailTemplateText(filePath);
                    emailTemplateText = string.Format(emailTemplateText, userData.Email, OTP, userData.Name);

                    BodyBuilder emailbodyBuilder = new BodyBuilder();
                    emailbodyBuilder.HtmlBody = emailTemplateText;

                    var image = emailbodyBuilder.LinkedResources.Add(Directory.GetCurrentDirectory() + "\\wwwroot\\assets\\img\\new_logo.png");
                    image.ContentId = "UserLogo";

                    emailMessage.Body = emailbodyBuilder.ToMessageBody();

                    using SmtpClient smtp = new SmtpClient();
                    smtp.Connect(smtpSettings.EmailHostName, Convert.ToInt32(smtpSettings.EmailPort), SecureSocketOptions.StartTls);
                    smtp.Authenticate(smtpSettings.FromEmail, smtpSettings.EmailAppPassword);
                    await smtp.SendAsync(emailMessage);
                    smtp.Disconnect(true);

                    TempData["Email"] = userData.Email;
                    return RedirectToAction("AddOTP");
                }
                else
                {
                    TempData["Error"] = "Email Not Registered";
                    return View();
                }
            }
             catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
