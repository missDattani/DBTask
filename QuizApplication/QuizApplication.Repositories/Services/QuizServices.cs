using QuizApplication.Models.Context;
using QuizApplication.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Repositories.Services
{
    public class QuizServices : IQuizInterface
    {
        Pooja326MVCEntities entities = new Pooja326MVCEntities();

        public List<Answer> AnswerList()
        {
            List<Answer> answers = entities.Answers.Where(m => m.isactive == true).ToList();
            if(answers != null)
            {
                return answers;
            }
            else
            {
                return null;
            }
        }

        public List<Question> QuestionList()
        {
            try
            {
                List<Question> questions = entities.Questions.Where(m => m.isactive == true).ToList();
                if (questions != null)
                {
                    return questions;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
