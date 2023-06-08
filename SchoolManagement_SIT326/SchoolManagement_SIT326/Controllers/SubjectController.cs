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
    public class SubjectController : Controller
    {
        public readonly ISubjectInterface subInterface;

        public SubjectController(ISubjectInterface subInterface)
        {
            this.subInterface = subInterface;
        }
        // GET: Subject
        public ActionResult GetSubjects()
        {
            try
            {
                List<SubjectModel> subModel = subInterface.DisplaySubjects();
                return View(subModel);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetSubjectById(int SubId)
        {
            try
            {
            
                SubjectModel subModel = subInterface.DisplaySubjectById(SubId);
                if (subModel != null)
                {
                    return View(subModel);
                }
                else
                {
                    TempData["Subject"] = "Subject Not Found";
                    return View();
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult AddSubject(int? SubId)
        {
            try
            {

                if (SubId == null)
                {
                    return View();
                }
                else
                {
               
                    SubjectModel subModel = subInterface.DisplaySubjectById(SubId);
                    return View(subModel);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        public ActionResult AddSubject(SubjectModel subModel,int? SubId)
        {
            try
            {
                if (SubId == null)
                {
                    int sub = subInterface.InsSubject(subModel, 0);
                    if (sub == 1)
                    {
                        TempData["Success"] = "Subject Added Successfully";
                        return RedirectToAction("GetSubjects");
                    }
                    else
                    {
                        TempData["Error"] = "Subject Already Exists";
                        return View();
                    }
                }
                else
                {
                    int subE = subInterface.InsSubject(subModel, SubId);
                    if (subE == 1)
                    {
                        TempData["Success"] = "Subject Edited Successfully";
                        return RedirectToAction("GetSubjects");
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

        public ActionResult DeleteSubject(int SubId)
        {
            try
            {
                int res = subInterface.RemoveSubject(SubId);
                if (res == 1)
                {
                    TempData["Success"] = "Subject Deleted Successfully";
                    return RedirectToAction("GetSubjects");
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