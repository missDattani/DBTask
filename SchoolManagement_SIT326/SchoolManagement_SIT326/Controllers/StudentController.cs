using SchoolManagement_SIT326.Helpers.Helpers;
using SchoolManagement_SIT326.Models.Context;
using SchoolManagement_SIT326.Models.Models;
using SchoolManagement_SIT326.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_SIT326.Controllers
{
    [LoginAction]
    public class StudentController : Controller
    {
        private readonly IStudentInterface stuInterface;
        private readonly ICountryInterface coInterface;
        private readonly ISubjectInterface subInterface;

        public StudentController(IStudentInterface stuInterface, ICountryInterface coInterface, ISubjectInterface subInterface)
        {
            this.stuInterface = stuInterface;
            this.coInterface = coInterface;
            this.subInterface = subInterface;
        }
        // GET: Student
        public ActionResult GetStudents()
        {
            try
            {
                List<StudentModel> stdList = stuInterface.DisplayStudent();
                return View(stdList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetStudentById(int StuId)
        {
            try
            {
                Student std = stuInterface.DisplayStudentById(StuId);
                StudentModel stuModel = StudentHelper.BindStudentToStudentModel(std);
                if (stuModel != null)
                {
                    return View(stuModel);
                }
                else
                {
                    TempData["Student"] = "Student Not Found";
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult AddStudent(int? StuId)
        {
            try
            {
                ViewBag.coList = coInterface.SelectCountry();
                ViewBag.subList = subInterface.SelectSubjects();
                if (StuId == null)
                {
                    return View();
                }
                else
                {
                    Student std = stuInterface.DisplayStudentById(StuId);
                    StudentModel stuModel = StudentHelper.BindStudentToStudentModel(std);
                    return View(stuModel);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public ActionResult AddStudent(StudentModel stModel,int? StuId,FormCollection collection)
        {
            try
            {
                ViewBag.coList = coInterface.SelectCountry();
                ViewBag.subList = subInterface.SelectSubjects();
                stModel.SubjectId = collection["SubIdC"];
                if (StuId == null)
                {
                    int student = stuInterface.InsStudent(stModel, 0);
                    if (student == 1)
                    {
                        TempData["Success"] = "Student Added Successfully";
                        return RedirectToAction("GetStudents");
                    }
                    else
                    {
                        TempData["Error"] = "Student Already Exists";
                        return View();
                    }
                }
                else
                {
                    int studentE = stuInterface.InsStudent(stModel, StuId);
                    if (studentE == 1)
                    {
                        TempData["Success"] = "Student Edited Successfully";
                        return RedirectToAction("GetStudents");
                    }
                    else
                    {
                        TempData["Error"] = "Something Went Wrong";
                        return View();
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult DeleteStudent(int StuId)
        {
            try
            {
                int res = stuInterface.RemoveStudent(StuId);
                if (res == 1)
                {
                    TempData["Success"] = "Student Deleted Successfully";
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
    }
}