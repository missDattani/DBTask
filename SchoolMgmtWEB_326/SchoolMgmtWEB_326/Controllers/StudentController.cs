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
    public class StudentController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: Student
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                List<StudentModel> studentModelList = new List<StudentModel>();
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.GetAsync("StudentAPI/DisplayStudents");
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<List<StudentModel>>();
                    studentModelList = display;
                }
                else
                {
                    studentModelList = null;
                    ModelState.AddModelError(string.Empty, "Server Error,Please Contact Administration");
                }
                return View(studentModelList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}