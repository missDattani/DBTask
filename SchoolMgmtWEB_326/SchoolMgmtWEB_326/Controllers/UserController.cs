using SchoolMgmtWEB_326.Models.Context;
using SchoolMgmtWEB_326.Models.Models;
using SchoolMgmtWEB_326.Repository.Repositories;
using SchoolMgmtWEB_326.SessionHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolMgmtWEB_326.Controllers
{
    public class UserController : Controller
    {
        HttpClient client = new HttpClient();
        IUserInterface uInterface;
        public UserController(IUserInterface uInterface)
        {
            this.uInterface = uInterface;
        }
        // GET: User
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                List<UserModel> userList = new List<UserModel>();
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response =await client.GetAsync("UserAPI/DisplayUsers");
                //response.Wait();
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<List<UserModel>>();
                    // display.Wait();
                    userList = display;
                }
                else
                {
                    userList = null;
                    ModelState.AddModelError(string.Empty, "Server Error , Please Contact Administrator");
                }

                return View(userList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ActionResult> GetUserDetail(int? Id)
        {
            try
            {
                UserModel userModel = null;
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.GetAsync("UserAPI?Id=" + Id);
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<UserModel>();
                    userModel = display;
                }
                else
                {
                    userModel = null;
                    ModelState.AddModelError(string.Empty, "Server Error,Please Contact Administration");
                }
                return View(userModel);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<ActionResult> SignUp(int? Id)
        {
            try
            {
                if (Id == 0 || Id == null)
                {
                    return View();
                }
                else
                {
                    UserModel userModel = null;
                    client.BaseAddress = new Uri("http://localhost:55932/api/UserAPI");
                    var response = await client.GetAsync("UserAPI?Id=" + Id.ToString());
                    var test = response.EnsureSuccessStatusCode();
                    if (test.IsSuccessStatusCode)
                    {
                        var display = await test.Content.ReadAsAsync<UserModel>();
                        userModel = display;
                    }
                    else
                    {
                        userModel = null;
                        ModelState.AddModelError(string.Empty, "Server Error,Please Contact Administration");
                    }
                    return View(userModel);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public async Task<ActionResult> SignUp(UserModel userModel)
        {

            try
            {
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.PostAsJsonAsync<UserModel>("UserAPI/AddEditUser", userModel);
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    TempData["Success"] = "Registration Successfull";
                    return RedirectToAction("GetUsers");
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

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]

        public ActionResult SignIn(UserModel userModel)
        {
            try
            {
                string user = uInterface.SignIn(userModel);
                if (user == "Invalid Email" || user == "Invalid Password" || user == "Invalid Email & Password")
                {
                    TempData["Error"] = user;
                    return View();

                }
                else
                {
                    Users users = uInterface.GetUserByEmail(user);
                    Session["Email"] = users.Email;
                    GetAllData.Email = users.Email;
                    Session["Fullname"] = users.FirstName + " " + users.LastName;
                    GetAllData.FirstName = users.FirstName;
                    GetAllData.LastName = users.LastName;
                    //SessionHelper.Email = user;
                    TempData["Success"] = "Login Successfull";
                    //FormsAuthentication.SetAuthCookie(userM.Email, false);
                    return RedirectToAction("GetUsers");
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<ActionResult> DeleteUser(int Id)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.DeleteAsync("UserAPI?Id=" + Id.ToString());
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    TempData["Success"] = "User Deleted Successfully";
                    return RedirectToAction("GetUsers");
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

        public ActionResult DashBoard()
        {
            ViewBag.UserCount = uInterface.UserCount();
            ViewBag.StudentCount = uInterface.StudentCount();
            ViewBag.TeacherCount = uInterface.TeacherCount();
            ViewBag.SubjectCount = uInterface.SubjectCount();

            return View();
        }

    }
}