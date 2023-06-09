using SchoolManagement_SIT326.Helpers.Helpers;
using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using SchoolManagement_SIT326.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolManagement_SIT326.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserInterface uInterface;

        public UserController(IUserInterface uInterface)
        {
            this.uInterface = uInterface;
        }
        [LoginAction]
        public ActionResult GetUsers()
        {
            try
            {
                List<UserModel> uModel = uInterface.GetUsers();
                return View(uModel);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [LoginAction]
        public ActionResult GetUserById(int Id)
        {
            try
            {
              
                UserModel UModel = uInterface.DisplayUserById(Id);

                if (UModel != null)
                {
                    return View(UModel);
                }
                else
                {
                    TempData["User"] = "User Not Found";
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
 
        public ActionResult SignUp(int? Id)
        {
            try
            {
                if (Id == null)
                {
                    return View();
                }
                else
                {
                 
                    UserModel UModel = uInterface.DisplayUserById(Id);
                    return View(UModel);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        [HttpPost]
        public ActionResult SignUp(UserModel uModel,int? Id)
        {
            try
            {
                
                    if (Id == null)
                    {
                        int user = uInterface.SignUp(uModel, 0);
                        if (user == 1)
                        {
                            TempData["Success"] = "User Added Successfully";
                            return RedirectToAction("SignIn");
                        }
                        else
                        {
                            TempData["Error"] = user;
                            return View();
                        }

                    }
                    else
                    {
                        int userE = uInterface.SignUp(uModel, Id);
                        if (userE == 1)
                        {
                            TempData["Success"] = "User Edited Successfully";
                            return RedirectToAction("SignIn");
                        }
                        else
                        {
                            TempData["Error"] = userE;
                            return View();
                        }
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
        public ActionResult SignIn(UserModel userM)
        {
            try
            {
                string user = uInterface.SignIn(userM);
                if (user == "Invalid Email" || user == "Invalid Password" || user == "Invalid Email & Password")
                {
                    TempData["Error"] = user;
                    return View();
               
                }
                else
                {
                    Session["FullName"] = user;
                    TempData["Success"] = "Login Successfull";
                    FormsAuthentication.SetAuthCookie(userM.Email, false);
                    return RedirectToAction("GetUsers");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        
        public ActionResult DeleteUser(int Id)
        {
            try
            {
                int res = uInterface.RemoveUser(Id);
                if (res == 1)
                {
                    TempData["Success"] = "User Deleted Successfully";
                    return RedirectToAction("GetUsers");
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

        public ActionResult Logout()
        {
            try
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                return RedirectToAction("SignIn");
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}