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

        //public TestService(ICareUow uow, TestLogicFactory factory, IQuestionGenerator questionGenerator)
        public TestService(ICareUow uow, TestLogicFactory factory)
        {
            //this.qGen = questionGenerator;
            this.factory = factory;
            this.uow = uow;
            //this.tLogic = tLogic;
            
        }

        public Test CreateTest(string testType, Student student)
        {
            if (testType != null && student != null)
            {
                Test test = new Test();
                test.Type = testType;
                test.Student = student;
                uow.Tests.Add(test);
                uow.Commit();
                return test;
            }
            return null;
        }

        public Question GetQuestion(int id)
        {
            return uow.Questions.GetById(id);
        }

        public Question GetNextQuestion(Test test, Question prevQuestion)
        {
            if (test.Type != null)
            {
                //this.tLogic = logic;
                tLogic = this.factory.CreateTestLogicInstance(test.Type);
                int qId = tLogic.GetQuestionId(test, prevQuestion, uow);
                Question q = uow.Questions.GetById(qId);
                return q;
            }

            return null;
            //if (test != null)
            //{

            //    string testType = test.Type;
            //    if (testType != null)
            //    {
            //        tLogic = this.factory.CreateTestLogicInstance(testType);
            //        return qGen.GetNextQuestion(test, prevQuestion, tLogic);
            //    }
            //}

            //return null;            
        }

        public void SaveAnswer(Test test, Answer answer, Question question)
        {
            if (answer != null && test != null && question != null)
            {
                answer.Question = question;
                answer.Test = test;
                uow.Answers.Add(answer);
                uow.Commit();
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
