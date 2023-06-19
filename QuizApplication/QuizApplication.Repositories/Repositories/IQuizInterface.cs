using QuizApplication.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Repositories.Repositories
{
    public interface IQuizInterface
    {
        List<Question> QuestionList();
        List<Answer> AnswerList();

    }
}
