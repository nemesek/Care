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
        private TestLogicFactory factory;

        public TestService(ICareUow uow, TestLogicFactory factory)
        {
            //this.questionGenerator = questionGenerator;
            this.factory = factory;
            this.uow = uow;
        }

        public Test CreateTest(string testType)
        {
            throw new NotImplementedException();
        }

        public Question GetNextQuestion(Test testId, Question prevQuestion)
        {
            //string testType =     //Grab testType based off of TestId
            //questionGenerator = this.factory.CreateTestLogicInstance(testType);
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
