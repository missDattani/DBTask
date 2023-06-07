using OrderManagement.Models.Models;
using OrderManagement.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class UserController : Controller
    {
        IUserInterface userInterface;

        public UserController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        // GET: User
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserModel user)
        {
            try
            {
                string success = userInterface.SignIn(user);
                if (success == "Invalid Email" || success == "Invalid Password")
                {
                    ViewBag.Error = success;
                    return View();
                }
                else
                {
                    Session["Id"] = success;
                    return RedirectToAction("AddOrder", "Order");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}