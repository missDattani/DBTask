using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using SchoolMgmt_326.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_326.Controllers
{
    [LoginAction]
    public class TeachersController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: Teachers
        private ITeacherInterface teInterface;
        private ICountryInterface coInterface;
     
        private ISubjectInterface subInterface;

        public TeachersController(ITeacherInterface teInterface,ICountryInterface coInterface,ISubjectInterface subInterface)
        {
            this.teInterface = teInterface;
            this.coInterface = coInterface;

            this.subInterface = subInterface;
        }

        public ActionResult GetTeachers()
        {
            try
            {
                IEnumerable<SP_GetTeacherDetails1_Result> teachers = new List<SP_GetTeacherDetails1_Result>();
                client.BaseAddress = new Uri("http://localhost:55339/api/TeacherApi");
                var response = client.GetAsync("TeacherApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<IList<SP_GetTeacherDetails1_Result>>();
                    display.Wait();
                    teachers = display.Result;
                }
                return View(teachers);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetTeacherDetails(int TecId)
        {
            try
            {
                TeacherModel tec = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/TeacherApi");
                var response = client.GetAsync("TeacherApi?TecId=" + TecId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<TeacherModel>();
                    display.Wait();
                    tec = display.Result;
                }
                return View(tec);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult AddTeacher()
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.SubList = subInterface.SelectSubject();
                return View();
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult AddTeacher(TeacherModel teacher,FormCollection collection)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.SubList = subInterface.SelectSubject();
                teacher.SubjectId = collection["SubjectId"];
                client.BaseAddress = new Uri("http://localhost:55339/api/TeacherApi");
                var response = client.PostAsJsonAsync<TeacherModel>("TeacherApi", teacher);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetTeachers");
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

        public ActionResult UpdateTeacher(int TecId)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.SubList = subInterface.SelectSubject();
                TeacherModel tec = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/TeacherApi");
                var response = client.GetAsync("TeacherApi?TecId=" + TecId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<TeacherModel>();
                    display.Wait();
                    tec = display.Result;
                }
                return View(tec);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UpdateTeacher(TeacherModel teacher, FormCollection collection)
        {

            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.SubList = subInterface.SelectSubject();
                teacher.SubjectId = collection["SubIdC"];
                client.BaseAddress = new Uri("http://localhost:55339/api/TeacherApi");
                var response = client.PutAsJsonAsync<TeacherModel>("TeacherApi", teacher);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetTeachers");
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

        public ActionResult DeleteTeacher(int TecId)
        {
            try
            {
                TeacherModel tec = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/TeacherApi");
                var response = client.DeleteAsync("TeacherApi?TecId=" + TecId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetTeachers");
                }
                else
                {
                    return View(tec);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}