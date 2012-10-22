using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Care.Model.Abstract;

namespace Care.Model.Concrete
{
    public class QuestionGenerator : IQuestionGenerator
    {
        private ITestLogic logic;
        public QuestionGenerator(ITestLogic logic)
        {
            this.logic = logic;
        }

        public Question GetNextQuestion(Question prevQuestion, Answer prevAnswer)
        {
            int qId = logic.GetQuestionId(prevQuestion, prevAnswer);
            Question q = new Question();
            q.Id = qId;
            return q;
        }
    }
}
