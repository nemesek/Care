using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Care.Data.Concrete;
using Care.Domain.Concrete;
using Care.Domain;
using Moq;
using Care.Domain.Abstract;


namespace Care.Tests
{
    [TestClass]
    public class TestServiceTest
    {
        [TestMethod]
        public void TestService_Can_Construct()
        {
            //Arrange
            //Constructor args ICareUow uow, TestLogicFactory factory, IQuestionGenerator questionGenerator
            
            RepositoryFactories factory = new RepositoryFactories();
            RepositoryProvider provider = new RepositoryProvider(factory);
            CareUow uow = new CareUow(provider);
            TestLogicFactory tFactory = new TestLogicFactory();
            QuestionGenerator qGenerator = new QuestionGenerator(uow);
            

            //Act
            //TestService target = new TestService(uow, tFactory, qGenerator);
            TestService target = new TestService(uow, tFactory);

            //Assert
            Assert.IsNotNull(target);
        }

        [TestMethod]
        public void TestService_Can_GetNextQuestion()
        {
            //Arrange
            //Constructor args ICareUow uow, TestLogicFactory factory, IQuestionGenerator questionGenerator
            //Method args Test test, Question prevQuestion
            RepositoryFactories factory = new RepositoryFactories();
            RepositoryProvider provider = new RepositoryProvider(factory);
            CareUow uow = new CareUow(provider);
            TestLogicFactory tFactory = new TestLogicFactory();
            QuestionGenerator qGenerator = new QuestionGenerator(uow);
            //TestService target = new TestService(uow, tFactory, qGenerator);
            TestService target = new TestService(uow, tFactory);
            Question q = new Question();
            q.Id = 1;
            Test t = new Test();
            t.Type = "sysr";
            t.Id = 1;

            //Act
            Question next = target.GetNextQuestion(t, q);


            //Assert
            Assert.IsNotNull(next);
            Assert.AreEqual(next.Id, 2);
        }

        [TestMethod]
        public void TestService_Can_GetQuestion()
        {
            //Arrange
            //Constructor args ICareUow uow, TestLogicFactory factory, IQuestionGenerator questionGenerator
            //method int id
            int testId = 35;
            Mock<ICareUow> mockUow = new Mock<ICareUow>();
            mockUow.Setup(m => m.Questions.GetById(testId)).Returns(new Question { Id = testId });
  
            TestLogicFactory tFactory = new TestLogicFactory();
            //Mock<IQuestionGenerator> mockQGenerator = new Mock<IQuestionGenerator>();
            //TestService target = new TestService(mockUow.Object, tFactory, mockQGenerator.Object);
            TestService target = new TestService(mockUow.Object, tFactory);


            //Act
            Question question = target.GetQuestion(testId);

            //Assert
            Assert.AreEqual(question.Id, testId);
            mockUow.Verify(m => m.Questions.GetById(testId), Times.AtLeastOnce());

        }

        [TestMethod]
        public void TestService_Can_GetStudent()
        {
            //Arrange
            //Constructor args ICareUow uow, TestLogicFactory factory, IQuestionGenerator questionGenerator
            //method int? studentId
            RepositoryFactories factory = new RepositoryFactories();
            RepositoryProvider provider = new RepositoryProvider(factory);
            CareUow uow = new CareUow(provider);
            TestLogicFactory tFactory = new TestLogicFactory();
            //QuestionGenerator qGenerator = new QuestionGenerator(uow);
            TestService target = new TestService(uow, tFactory);
            int studentId = 1;

            //Act
            Student student = target.GetStudent(studentId);

            //Assert
            Assert.AreEqual(student.Id, studentId);
        }

        [TestMethod]
        public void TestService_Can_GetStudent_MockUow()
        {
            //Arrange
            //Constructor args ICareUow uow, TestLogicFactory factory, IQuestionGenerator questionGenerator
            //method int? studentId
            int studentId = 41;
            Mock<ICareUow> mockUow = new Mock<ICareUow>();
            mockUow.Setup(m => m.Students.GetById(studentId)).Returns( new Student {Id = studentId});
            mockUow.Setup(m => m.Students.GetAll()).Returns(new Student[] 
            {
                new Student{Id = 55, FirstName="Dan"},
            }.AsQueryable());
            TestLogicFactory tFactory = new TestLogicFactory();
            //Mock<IQuestionGenerator> mockQGenerator = new Mock<IQuestionGenerator>();
            TestService target = new TestService(mockUow.Object, tFactory);
            

            //Act
            Student student = target.GetStudent(studentId);

            //Assert
            Assert.AreEqual(student.Id, studentId);
            mockUow.Verify(m => m.Students.GetById(studentId), Times.AtLeastOnce());
            //mockUow.Verify(m => m.Students.GetAll(), Times.AtLeastOnce());
            
        }

        [TestMethod]
        public void TestService_Can_SaveAnswer_MockUow()
        {
            //Arrange
            //Constructor args ICareUow uow, TestLogicFactory factory, IQuestionGenerator questionGenerator
            //method Answer answer
            Answer answer = new Answer();
            Test test = new Test();
            answer.Test = test;
            answer.Value = "Blah Blah";
            Mock<ICareUow> mockUow = new Mock<ICareUow>();
            mockUow.Setup(m => m.Answers.Add(answer));
            TestLogicFactory tFactory = new TestLogicFactory();
            //Mock<IQuestionGenerator> mockQGenerator = new Mock<IQuestionGenerator>();
            TestService target = new TestService(mockUow.Object, tFactory);
            Question question = new Question();

            //Act
            target.SaveAnswer(test, answer, question);

            //Assert
            mockUow.Verify(m => m.Answers.Add(answer), Times.AtLeastOnce());

        }

        [TestMethod]
        public void TestService_Can_CreateTest()
        {
            //Arrange
            //Constructor args ICareUow uow, TestLogicFactory factory, IQuestionGenerator questionGenerator
            //method string testType
            string testType = "Sysr";
            Test t = new Test();
            Mock<ICareUow> mockUow = new Mock<ICareUow>();
            mockUow.Setup(m => m.Tests.Add(t));
            TestLogicFactory tFactory = new TestLogicFactory();
            //Mock<IQuestionGenerator> mockQGenerator = new Mock<IQuestionGenerator>();
            TestService target = new TestService(mockUow.Object, tFactory);
            Student student = new Student();
            

            //Act
            Test test = target.CreateTest(testType, student);

            //Assert
            Assert.IsNotNull(test);
            Assert.IsTrue(test.Type.ToString().Contains(testType));

        }

        [TestMethod]
        public void TestService_Can_GetTest()
        {
            //Arrange
            //Constructor args ICareUow uow, TestLogicFactory factory, IQuestionGenerator questionGenerator
            //method int testId
            int testId = 1;
            Mock<ICareUow> mockUow = new Mock<ICareUow>();
            mockUow.Setup(m => m.Tests.GetById(testId)).Returns(new Test { Id = testId });
            TestLogicFactory tFactory = new TestLogicFactory();
            //Mock<IQuestionGenerator> mockQGenerator = new Mock<IQuestionGenerator>();
            TestService target = new TestService(mockUow.Object, tFactory);

            //Act
            Test test = target.GetTest(testId);

            //Assert
            Assert.IsNotNull(test);
            Assert.AreEqual(test.Id, testId);
            mockUow.Verify(m => m.Tests.GetById(testId), Times.AtLeastOnce());
        }
    }
}
