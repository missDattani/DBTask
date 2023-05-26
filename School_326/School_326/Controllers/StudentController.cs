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
    public class StudentController : Controller
    {
        HttpClient client = new HttpClient();
         private IStudentInterface stdInterface;
        private ICountryInterface coInterface;
        private ITeacherInterface tecInterface;


        public StudentController(IStudentInterface stdInterface, ICountryInterface coInterface, ITeacherInterface tecInterface)
        {
            this.stdInterface = stdInterface;
            this.coInterface = coInterface;
            this.tecInterface = tecInterface;

        }
        // GET: Student
        public ActionResult GetStudents(int id=1)
        {
            try
            {
                List<Student> stud = new List<Student>();
                client.BaseAddress = new Uri("http://localhost:61138/api/StudentApi");
                var response = client.GetAsync("StudentApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<Student>>();
                    display.Wait();
                    stud = display.Result;
                }

                const int pageSize = 5;

                int recsCount = stud.Count();
                var pager = new Pager(recsCount, id, pageSize);
                int recSkip = (id - 1) * pageSize;
                var data = stud.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;

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
                client.BaseAddress = new Uri("http://localhost:61138/api/StudentApi");
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
            ViewBag.CoList = coInterface.SelectCountry();
            ViewBag.TecList = tecInterface.SelectTeachers();
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentModel student,FormCollection collection)
        {
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.TecList = tecInterface.SelectTeachers();
                student.TeacherId = collection["TeacherId"];
                client.BaseAddress = new Uri("http://localhost:61138/api/StudentApi");
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
                ViewBag.TecList = tecInterface.SelectTeachers();
                StudentModel std = null;
                client.BaseAddress = new Uri("http://localhost:61138/api/StudentApi");
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
        public ActionResult UpdateStudent(StudentModel student,FormCollection collection)
        {
           
            try
            {
                ViewBag.CoList = coInterface.SelectCountry();
                ViewBag.TecList = tecInterface.SelectTeachers();
                student.TeacherId = collection["TecIdC"];
                client.BaseAddress = new Uri("http://localhost:61138/api/StudentApi");
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
                client.BaseAddress = new Uri("http://localhost:61138/api/StudentApi");
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