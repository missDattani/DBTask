using Newtonsoft.Json;
using QuizApplication.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApplication.Controllers
{
    public class QuizController : Controller
    {
        IQuizInterface quizInterface;
        public QuizController(IQuizInterface quizInterface)
        {
            this.quizInterface = quizInterface;
        }
        // GET: Quiz
        public JsonResult QuestionList()
        {
            var question = quizInterface.QuestionList().ToList();
            var JsonQueData = JsonConvert.SerializeObject(question);
            return Json(JsonQueData,JsonRequestBehavior.AllowGet);
        }

        public JsonResult AnswerList()
        {
            var answer = quizInterface.AnswerList().ToList();
            var JsonAnsData = JsonConvert.SerializeObject(answer);
            return Json(JsonAnsData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PlayQuiz()
        {
            return View();
        }
    }
}