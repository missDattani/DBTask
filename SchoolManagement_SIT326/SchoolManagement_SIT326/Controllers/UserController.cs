using SchoolManagement_SIT326.Context;
using SchoolManagement_SIT326.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_SIT326.Controllers
{
    public class UserController : Controller
    {
        OrderManagementEntities1 entities = new OrderManagementEntities1();
        // GET: User

        public ActionResult Index()
        {
            try
            {
                return View(entities.Users.ToList());
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

            public ActionResult SignIn(UserModel uModel)
            {
            try
            {
                if (string.IsNullOrEmpty(uModel.Email) || string.IsNullOrEmpty(uModel.PassWord))
                { 
                    TempData["Error"] = "Please enter both email and password.";
                    return View();
                }
                var user = entities.Users.FirstOrDefault(m => m.Email == uModel.Email);
                if (user != null)
                {
                    if (user.PassWord == uModel.PassWord)

                    {
                        TempData["Success"] = "Login Successfull";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = "Invalid Password.";
                        return View();
                    }
                }
                else
                {
                    TempData["Error"] = "Invalid Email.";
                    return View();
                }

            }
            catch (Exception ex)

            {
                TempData["Error"] = "An error occurred.";
                throw ex;
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserModel userM)
        {
            try
            {
                var checkUser = entities.Users.Any(m => m.FirstName == userM.FirstName && m.LastName == userM.LastName);
                if(checkUser)
                {
                    TempData["Error"] = "User Already exists";
                    return View();
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        User u = new User();
                        u = BindUserModelToUser(userM);
                        entities.Users.Add(u);
                        entities.SaveChanges();
                        TempData["Success"] = "User Added Successfully";
                        return RedirectToAction("SignIn");
                    }
                    else
                    {
                        return View();
                    }
                  
                }
             
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public static User BindUserModelToUser(UserModel user)
        {
            User users = new User();

            users.Id = user.Id;
            users.FirstName = user.FirstName;
            users.LastName = user.LastName;
            users.Email = user.Email;
            users.PassWord = user.PassWord;
            users.Role = user.Role;
           
            return users;
        }

        public static UserModel BindUserToUserModel(User u)
        {
            UserModel user = new UserModel();
            user.Id = u.Id;
            user.FirstName = u.FirstName;
            user.LastName = u.LastName;
            user.Email = u.Email;
            user.PassWord = u.PassWord;
            user.Role = u.Role;
            user.RoleName = u.Role == 1 ? "Super Admin" : u.Role == 2 ? "Admin" : "Student";
            return user;
        }
    }
}