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
    public class SubjectController : Controller
    {
        HttpClient client = new HttpClient();

        private ISubjectInterface subInterface;

        public SubjectController(ISubjectInterface subInterface)
        {
            this.subInterface = subInterface;
        }
        // GET: Subject
        public ActionResult GetSubjects(int id=1)
        {
            try
            {
                List<Subject> subList = new List<Subject>();
                client.BaseAddress = new Uri("http://localhost:61138/api/SubjectApi");
                var response = client.GetAsync("SubjectApi");
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<List<Subject>>();
                    display.Wait();
                    subList = display.Result;
                }

                const int pageSize = 5;

                int recsCount = subList.Count();
                var pager = new Pager(recsCount, id, pageSize);
                int recSkip = (id - 1) * pageSize;
                var data = subList.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;

                return View(subList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult GetSubjectDetails(int SubId)
        {
            try
            {
                SubjectModel sub = null;
                client.BaseAddress = new Uri("http://localhost:61138/api/SubjectApi");
                var response = client.GetAsync("SubjectApi?SubId=" + SubId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<SubjectModel>();
                    display.Wait();
                    sub = display.Result;
                }
                return View(sub);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(SubjectModel subModel)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:61138/api/SubjectApi");
                var response = client.PostAsJsonAsync<SubjectModel>("SubjectApi", subModel);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
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

        public ActionResult UpdateSubject(int SubId)
        {
            try
            {
                SubjectModel sub = null;
                client.BaseAddress = new Uri("http://localhost:61138/api/SubjectApi");
                var response = client.GetAsync("SubjectApi?SubId=" + SubId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    var display = test.Content.ReadAsAsync<SubjectModel>();
                    display.Wait();
                    sub = display.Result;
                }
                return View(sub);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult UpdateSubject(SubjectModel subModel)
        {
            try
            {
               
                client.BaseAddress = new Uri("http://localhost:61138/api/SubjectApi");
                var response = client.PutAsJsonAsync<SubjectModel>("SubjectApi", subModel);
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
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

        public ActionResult DeleteSubject(int SubId)
        {
            try
            {
                SubjectModel sub = null;
                client.BaseAddress = new Uri("http://localhost:61138/api/SubjectApi");
                var response = client.DeleteAsync("SubjectApi?SubId=" + SubId.ToString());
                response.Wait();
                var test = response.Result;
                if (test.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetSubjects");
                }
                else
                {
                    return View(sub);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}