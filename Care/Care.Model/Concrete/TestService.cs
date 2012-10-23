using Care.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Domain.Concrete
{
    public class TestService : ITestService
    {
        private IQuestionGenerator questionGenerator;
        private ICareUow uow;

        public TestService(ICareUow uow, IQuestionGenerator questionGenerator)
        {
            this.questionGenerator = questionGenerator;
            this.uow = uow;
        }

        public Question GetNextQuestion(Test testId, Question prevQuestion)
        {
            throw new NotImplementedException();
        }

        public void SaveAnswer(Test testId, Answer answer)
        {
            throw new NotImplementedException();
        }

        public Test GetTest(int? testId)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(int? studentId)
        {
            throw new NotImplementedException();
        }
    }
}
