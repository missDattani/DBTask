using SchoolMgmt.Helper.Helpers;
using SchoolMgmt_326.Model.Context;
using SchoolMgmt_326.Model.Model;
using SchoolMgmt_326.Repositories.Repositories;
using SchoolMgmt_326.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
//using static SchoolMgmt.Helper.GlobalEnum.GenderEnum;

namespace SchoolManagement_326.Controllers
{
    [LoginAction]
    public class StudentController : Controller
    {

         HttpClient client = new HttpClient();
        private IStudentInterface studentInterface;
        private ICountryInterface coInterface;
        private IStateInterface stInterface;
        private ICityInterface ctInterface;
        private ITeacherInterface tecInterface;



        public StudentController(IStudentInterface studentInterface, ICountryInterface coInterface, IStateInterface stInterface, ICityInterface ctInterface, ITeacherInterface tecInterface)
        {
            this.studentInterface = studentInterface;
            this.coInterface = coInterface;
            this.stInterface = stInterface;
            this.ctInterface = ctInterface;
            this.tecInterface = tecInterface;

        }

        // GET: Student
        public ActionResult GetStudents()
        {
            try
            {
                IEnumerable<SP_GetStudentDetails1_Result> stud = new List<SP_GetStudentDetails1_Result>();
                client.BaseAddress = new Uri("http://localhost:55339/api/StudentApi");
                var response = client.GetAsync("StudentApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<SP_GetStudentDetails1_Result>>();
                    display.Wait();
                    stud = display.Result;
                }
                return View(stud);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetStudentDetails(int SId)
        {
            try
            {
                StudentModel std = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/StudentApi");
                var response = client.GetAsync("StudentApi?SId=" + SId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<StudentModel>();
                    display.Wait();
                    std = display.Result;
                }
                return View(std);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public ActionResult AddStudent()
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.TeList = tecInterface.SelectTeacher();
                //ViewBag.Gender = from Genders G in Enum.GetValues(typeof(Genders))
                //                 select new
                //                 {
                //                     id = (int)G,
                //                     value = G.ToString()
                //                 };
                return View();
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult AddStudent(StudentModel student, FormCollection collection)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.TeList = tecInterface.SelectTeacher();
                student.TeacherId = collection["TeacherId"];
                //ViewBag.Gender = from Genders G in Enum.GetValues(typeof(Genders))
                //                 select new
                //                 {
                //                     id = (int)G,
                //                     value = G.ToString()
                //                 };
                client.BaseAddress = new Uri("http://localhost:55339/api/StudentApi");
                var response = client.PostAsJsonAsync<StudentModel>("StudentApi", student);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetStudents");
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

        public ActionResult UpdateStudent(int SId)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.TeList = tecInterface.SelectTeacher();
                StudentModel std = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/StudentApi");
                var response = client.GetAsync("StudentApi?SId=" + SId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<StudentModel>();
                    display.Wait();
                    std = display.Result;
                }
                return View(std);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UpdateStudent(StudentModel student, FormCollection collection)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.TeList = tecInterface.SelectTeacher();
                student.TeacherId = collection["TecIdC"];
                client.BaseAddress = new Uri("http://localhost:55339/api/StudentApi");
                var response = client.PutAsJsonAsync<StudentModel>("StudentApi", student);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetStudents");
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

        public ActionResult DeleteStudent(int SId)
        {
            try
            {
                StudentModel std = null;
                client.BaseAddress = new Uri("http://localhost:55339/api/StudentApi");
                var response = client.DeleteAsync("StudentApi?SId=" + SId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetStudents");
                }
                else
                {
                    return View(std);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}