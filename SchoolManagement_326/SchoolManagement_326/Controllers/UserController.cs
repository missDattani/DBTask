using SchoolMgmt_326.Model.Model;
using SchoolMgmt_326.Repositories.Repositories;
using SchoolMgmt_326.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolManagement_326.Controllers
{
    public class UserController : Controller
    {
        private IUserInterface userInterface;

        public UserController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }
        // GET: User
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserModel user)
        {
            try
            {

            if (ModelState.IsValid)
            {
             
                ViewBag.message = userInterface.SignUp(user);
                if (ViewBag.message == "1")
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
            }
            catch(Exception e)
            {
                throw e;
            }
          
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserModel iuser)
        {
            try
            {
                    ViewBag.msg = userInterface.Signin(iuser);
                    if (ViewBag.msg != "0")
                    {
                         Session["Fullname"] = ViewBag.msg;
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ViewBag.Error = "Incorrect Email or Password";
                        return View();
                    }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public ActionResult Index()
        {
            try { 
                ViewBag.Users = userInterface.UserCount();
                ViewBag.Students = userInterface.StudentCount();
                ViewBag.Teacher = userInterface.TeachersCount();
                ViewBag.Subjects = userInterface.SubjectCount();
            return View();
            }
            catch(Exception e) { throw e; }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("SignIn");
        }
    }
}