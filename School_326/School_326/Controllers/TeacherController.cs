using School_326.Models.Context;
using School_326.Models.Models;
using School_326.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace School_326.Controllers
{
    public class TeacherController : Controller
    {
        HttpClient client = new HttpClient();

        private ITeacherInterface tecInterface;
        private ICountryInterface coInterface;
        private ISubjectInterface subInterface;



        public TeacherController(ITeacherInterface tecInterface, ICountryInterface coInterface, ISubjectInterface subInterface)
        {
            this.tecInterface = tecInterface;
            this.coInterface = coInterface;
            this.subInterface = subInterface;

        }
        // GET: Teacher
        public ActionResult GetTeachers(int id=1)
        {
            try
            {
                List<Teacher> teachers = new List<Teacher>();
                client.BaseAddress = new Uri("http://localhost:61138/api/TeacherApi");
                var response = client.GetAsync("TeacherApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<Teacher>>();
                    display.Wait();
                    teachers = display.Result;
                }

                const int pageSize = 5;

                int recsCount = teachers.Count();
                var pager = new Pager(recsCount, id, pageSize);
                int recSkip = (id - 1) * pageSize;
                var data = teachers.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;

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
                client.BaseAddress = new Uri("http://localhost:61138/api/TeacherApi");
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
            ViewBag.CoList = coInterface.SelectCountry();
            ViewBag.SubList = subInterface.SelectSubject();
            return View();
        }
        
        [HttpPost]
        public ActionResult AddTeacher(TeacherModel teacherM,FormCollection collection)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.SubList = subInterface.SelectSubject();
                teacherM.SubjectId = collection["SubjectId"];
                client.BaseAddress = new Uri("http://localhost:61138/api/TeacherApi");
                var response = client.PostAsJsonAsync<TeacherModel>("TeacherApi", teacherM);
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
                client.BaseAddress = new Uri("http://localhost:61138/api/TeacherApi");
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
        public ActionResult UpdateTeacher(TeacherModel teacher,FormCollection collection)
        {
            
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.SubList = subInterface.SelectSubject();
                teacher.SubjectId = collection["SubIdC"];
                client.BaseAddress = new Uri("http://localhost:61138/api/TeacherApi");
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
                client.BaseAddress = new Uri("http://localhost:61138/api/TeacherApi");
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