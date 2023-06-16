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
    public class SubjectController : Controller
    {
        HttpClient client = new HttpClient();

        // GET: Subject
        public async Task<ActionResult> GetSubjects()
        {
            try
            {
                List<SubjectModel> subjectModelList = new List<SubjectModel>();
                client.BaseAddress = new Uri("http://localhost:55932/api/");
                var response = await client.GetAsync("SubjectAPI/DisplaySubjects");
                var test = response.EnsureSuccessStatusCode();
                if (test.IsSuccessStatusCode)
                {
                    var display = await test.Content.ReadAsAsync<List<SubjectModel>>();
                    subjectModelList = display;
                }
                else
                {
                    subjectModelList = null;
                    ModelState.AddModelError(string.Empty, "Server Error, Please Contact Administration");
                }
                return View(subjectModelList);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}