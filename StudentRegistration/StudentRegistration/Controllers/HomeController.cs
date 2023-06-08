using StudentRegistration.Context;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class HomeController : Controller
    {
        PD326Entities entities = new PD326Entities();

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserModel iuser)
        {
            try
            {
                User userValid = entities.Users.Where(model => model.Email.Equals(iuser.Email) && model.Password.Equals(iuser.Password)).FirstOrDefault();
                if (userValid != null)
                {
                    Session["User"] = userValid.UserName;
                    return RedirectToAction("Index","Student");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

                    entities.Users.Add(new User
                    {
                        Email = user.Email,
                        Password = user.Password,
                        UserName = user.UserName
                    });
                    entities.SaveChanges();

                    return RedirectToAction("SignIn");
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

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}