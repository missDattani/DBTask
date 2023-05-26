using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement_326.Controllers
{
    [LoginAction]
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult OpenQuiz()
        {
            return View();
        }
    }
}