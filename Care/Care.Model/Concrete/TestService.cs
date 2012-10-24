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
        //private IQuestionGenerator questionGenerator;
        private ICareUow uow;
        private TestLogicFactory factory;
        private ITestLogic tLogic;
        private IQuestionGenerator qGen;

        public TestService(ICareUow uow, TestLogicFactory factory, IQuestionGenerator questionGenerator)
        {
            this.qGen = questionGenerator;
            this.factory = factory;
            this.uow = uow;
            
        }

        public Test CreateTest(string testType)
        {
            if (testType != null)
            {
                Test test = new Test();
                test.Type = testType;
                uow.Tests.Add(test);
                return test;
            }
            return null;
        }

        public Question GetNextQuestion(Test test, Question prevQuestion)
        {
                    
            string testType = test.Type;
            if (testType != null)
            {
                tLogic = this.factory.CreateTestLogicInstance(testType);
                return qGen.GetNextQuestion(test, prevQuestion, tLogic);
            }
            else
                return null;

            
        }

        public void SaveAnswer(Test test, Answer answer)
        {
            if (answer != null)
            {
                uow.Answers.Add(answer);
            }
        }

        public Test GetTest(int? testId)
        {
            if (testId.HasValue)
            {
                Test test = uow.Tests.GetById(testId.Value);
                return test;
            }
            else
                return null;
        }

        public Student GetStudent(int? studentId)
        {
            if (studentId.HasValue)
            {
                return uow.Students.GetById(studentId.Value);
            }
            else
            {
                return null;
            }
        }
    }
}
