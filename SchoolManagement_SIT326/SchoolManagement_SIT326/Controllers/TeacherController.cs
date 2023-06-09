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
    public class TeacherController : Controller
    {
        public readonly ITeacherInterface tecInterface;
        public readonly ICountryInterface coInterface;
        public readonly ISubjectInterface subInterface;



        public TeacherController(ITeacherInterface tecInterface, ICountryInterface coInterface, ISubjectInterface subInterface)
        {
            this.tecInterface = tecInterface;
            this.coInterface = coInterface;
            this.subInterface = subInterface;
        }
        // GET: Teacher
        public ActionResult GetTeachers()
        {
            try
            {
                List<TeacherModel> tecModel = tecInterface.DisplayTeachers();
                return View(tecModel);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetTeacherById(int TecId)
        {
            try
            {
                TeacherModel tecModel = tecInterface.DisplayTeacherById(TecId);
                if (tecModel != null)
                {
                    return View(tecModel);
                }
                else
                {
                    TempData["Teacher"] = "Teacher Not Found";
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult AddTeacher(int? TecId)
        {
            try
            {
                ViewBag.coList = coInterface.SelectCountry();
                ViewBag.subList = subInterface.SelectSubjects();
                if (TecId == null)
                {
                    return View();
                }
                else
                {
                
                    TeacherModel tecModel = tecInterface.DisplayTeacherById(TecId);
                    return View(tecModel);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public ActionResult AddTeacher(TeacherModel tecModel,int? TecId,FormCollection collection)
        {
            try
            {
                ViewBag.coList = coInterface.SelectCountry();
                ViewBag.subList = subInterface.SelectSubjects();
                tecModel.SubjectId = collection["SubIdC"];
                if (TecId == null)
                {
                    int teacher = tecInterface.InsTeacher(tecModel, 0);
                    if (teacher == 1)
                    {
                        TempData["Success"] = "Teacher Added Successfully";
                        return RedirectToAction("GetTeachers");
                    }
                    else
                    {
                        TempData["Error"] = "Teacher Already Exists";
                        return View();
                    }
                }
                else
                {
                    int teacherE = tecInterface.InsTeacher(tecModel, TecId);
                    if (teacherE == 1)
                    {
                        TempData["Success"] = "Teacher Edited Successfully";
                        return RedirectToAction("GetTeachers");
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

        public ActionResult DeleteTeacher(int TecId)
        {
            try
            {
                int res = tecInterface.RemoveTeacher(TecId);
                if (res == 1)
                {
                    TempData["Success"] = "Teacher Deleted Successfully";
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
    }
}