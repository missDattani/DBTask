using Register.Models.Models;
using Register.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Register.Controllers
{
    public class UserController : Controller
    {
        IUserInterface userInterface;

        public UserController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddUser(UserModel userModel)
        {
            try
            {
                int user = userInterface.InsUser(userModel);

                if (user == 1)
                {
                    return Json(user, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
         
        }

        public JsonResult GetUser()
        {
            try
            {
                List<UserModel> userModels = userInterface.DisplayUser();
                if (userModels != null)
                {
                    return Json(userModels, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public JsonResult EditUser(int Id)
        {
            try
            {
                UserModel userModel = userInterface.UpdateUser(Id);
                return Json(userModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public JsonResult EditUser(UserModel userModel)
        {
            try
            {
                int user = userInterface.UpdateUser(userModel);
                if (user == 1)
                {
                    return Json(user, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public JsonResult DeleteUser(int Id)
        {
            try
            {
                int user = userInterface.DeleteUser(Id);
                if (user == 1)
                {
                    return Json(user, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}