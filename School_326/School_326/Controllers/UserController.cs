using School_326.Models.Models;
using School_326.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_326.Controllers
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
            catch (Exception e)
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
            ViewBag.messageIn = userInterface.SignIn(iuser);
            if(ViewBag.messageIn != "0")
            {
                Session["Fullname"] = ViewBag.messageIn;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}