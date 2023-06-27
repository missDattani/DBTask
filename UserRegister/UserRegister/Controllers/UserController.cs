using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegister.Models.Context;
using UserRegister.Models.Models;
using UserRegister.Repositories.Repositories;

namespace UserRegister.Controllers
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

        //[HttpPost]
        //public ActionResult Index(int currentPageIndex)
        //{
        //    return View(this.NoOfUsers(currentPageIndex));
        //}
        public JsonResult GetUsers()
        {
            try
            {
                List<UserModel> userModelList = userInterface.GetUsers();
                return Json(new {Success = true,data = userModelList }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public JsonResult AddUser(UserModel userModel)
        {
           
                int user = userInterface.InsUser(userModel);
                if (user == 1)
                {
                    
                    return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                }
            else if (!ModelState.IsValid)
            {
                    return Json("", JsonRequestBehavior.AllowGet);
            }
            else
            { 
                    
                    return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult EditUser(int Id)
        {
            try
            {

                UserModel userModel = userInterface.EditUser(Id);
                return Json(userModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = e.Message}, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public JsonResult DeleteUser(int Id)
        {
            bool res = userInterface.DeleteUser(Id);
            if (res)
            {
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        }

        //private UserPageModel NoOfUsers(int currentPage)
        //{
        //    int maxRows = 3;
        //    using (Pooja326MVCEntities entities = new Pooja326MVCEntities())
        //    {
        //        UserPageModel pageModel = new UserPageModel();
        //        pageModel.Users = (from user in entities.User
        //                           select user).OrderBy(user => user.Id).Skip((currentPage - 1) * maxRows).Take(maxRows).ToList();

        //        double pageCount = (double)((decimal)entities.User.Count() / Convert.ToDecimal(maxRows));
        //        pageModel.PageCount = (int)Math.Ceiling(pageCount);
        //        pageModel.CurrentPageIndex = currentPage;
        //        return pageModel;
        //    }
        //}
    }
}