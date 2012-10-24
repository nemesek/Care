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
        
        
        public QuestionGenerator(ICareUow uow)
        {
            //this.logic = logic;
            this.uow = uow;
        }

        public Question GetNextQuestion(Test test, Question prevQuestion, ITestLogic logic)
        {
            this.logic = logic;
            int qId = logic.GetQuestionId(test, prevQuestion, uow);
            Question q = uow.Questions.GetById(qId);
            return q;
        }
    }
}
