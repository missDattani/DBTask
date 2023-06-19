using QuizApplication.Models.Models;
using QuizApplication.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApplication.Controllers
{
    public class UserController : Controller
    {
        IUserInterface userInterface;

        public UserController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            try
            {
                int success = userInterface.SignIn(userModel);
                if (success == 3)
                {
                    TempData["Error"] = "User Not Registered";
                    return View();
                }
                else if (success == 2)
                {
                    TempData["Error"] = "Invalid Password";
                    return View();
                }
                else if (success == 1)
                {
                    Session["Id"] = userModel.USERID;
                    return RedirectToAction("PlayQuiz", "Quiz");
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
    }
}