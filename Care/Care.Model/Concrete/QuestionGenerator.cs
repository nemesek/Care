using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Care.Domain.Abstract;

namespace Care.Domain.Concrete
{
    public class QuestionGenerator : IQuestionGenerator
    {
        private ITestLogic logic;
        private ICareUow uow;
        public QuestionGenerator(ITestLogic logic, ICareUow uow)
        {
            this.logic = logic;
            this.uow = uow;
        }

        public Question GetNextQuestion(Question prevQuestion, Answer prevAnswer)
        {
            int qId = logic.GetQuestionId(prevQuestion, prevAnswer);
            Question q = uow.Questions.GetById(qId);
            return q;
        }
    }
}
