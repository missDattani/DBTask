using SchoolMgmtWEB_326.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SchoolMgmtWEB_326.Controllers
{
    public class TeacherController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: Teacher
        public async Task<ActionResult> GetTeachers()
        {
            try
            {
                List<TeacherModel> teacherModelList = new List<TeacherModel>();
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.GetAsync("TeacherAPI/DisplayTeachers");
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<List<TeacherModel>>();
                    teacherModelList = display;
                }
                else
                {
                    teacherModelList = null;
                    ModelState.AddModelError(string.Empty, "Server Error,Please Contact Administration");
                }
                return View(teacherModelList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}