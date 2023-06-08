using StudentRegistration.Context;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {
        PD326Entities entities = new PD326Entities();
        // GET: Student
        public ActionResult Index()
        {
            try
            {
                List<StudentModel> slist = Functions.Converter(entities.Students.ToList());
                return View(slist);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<SCountry> GetCountryList()
        {
            PD326Entities entities = new PD326Entities();
            List<SCountry> countries = entities.SCountries.ToList();
            return countries;
        }

        public ActionResult GetStateList(int CountryId)
        {
            List<SState> statelist = entities.SStates.Where(x => x.CountryId == CountryId).ToList();
            ViewBag.Slist = new SelectList(statelist, "StateId", "StateName");
            return PartialView("DisplayStates");
        }

        public ActionResult GetCityList(int StateId)
        {
            List<SCity> citylist = entities.SCities.Where(x => x.StateId == StateId).ToList();
            ViewBag.Clist = new SelectList(citylist, "CityId", "CityName");
            return PartialView("DisplayCity");
        }

        public ActionResult AddStudent()
        {
            ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentModel std)
        {
            try
            {
                ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");
                if (ModelState.IsValid)
                {
                    entities.Students.Add(new Student
                    {
                        FirstName = std.FirstName,
                        LastName = std.LastName,
                        Address = std.Address,
                        Contact = std.Contact,
                        Email = std.Email,
                        Gender = std.Gender,
                        CountryId = std.CountryId,
                        StateId = std.StateId,
                        CityId = std.CityId
                    });

                    entities.SaveChanges();
                    return RedirectToAction("Index");
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

        public ActionResult UpdateStudent(int id)
        {
            try
            {
                ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");
                Student stdObj = entities.Students.Where(x => x.SId == id).FirstOrDefault();
                if (stdObj != null)
                {
                    StudentModel st = new StudentModel();
                    st.SId = stdObj.SId;
                    st.FirstName = stdObj.FirstName;
                    st.LastName = stdObj.LastName;
                    st.Address = stdObj.Address;
                    st.Contact = stdObj.Contact;
                    st.Email = stdObj.Email;
                    st.Gender = stdObj.Gender;
                    st.CountryId = Convert.ToInt32(stdObj.CountryId);
                    st.StateId = Convert.ToInt32(stdObj.StateId);
                    st.CityId = Convert.ToInt32(stdObj.CityId);
                    return View(st);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult UpdateStudent(StudentModel st)
        {
            try
            {
                ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");
                Student StObj = entities.Students.Where(x => x.SId == st.SId).FirstOrDefault();
                if (StObj != null)
                {
                    StObj.FirstName = st.FirstName;
                    StObj.LastName = st.LastName;
                    StObj.Address = st.Address;
                    StObj.Contact = st.Contact;
                    StObj.Email = st.Email;
                    StObj.Gender = st.Gender;
                    StObj.CountryId = st.CountryId;
                    StObj.StateId = st.StateId;
                    StObj.CityId = st.CityId;

                    entities.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult DeleteStudent(int id)
        {
            try
            {
                List<Student> SList = entities.Students.ToList();
                Student sObj = entities.Students.Where(x => x.SId == id).FirstOrDefault();
                entities.Students.Remove(sObj);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ActionResult Logout()
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("SignIn", "Home");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}