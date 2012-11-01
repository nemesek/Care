using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Care.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Care.Domain.Abstract;
using Care.Domain.Concrete;
using Care.Domain;
using System.Web.Mvc;
using Care.Controllers;

namespace Care.Tests
{
    [TestClass]
    public class TestControllerTest
    {
        [TestMethod]
        public void TestController_Question_GetNextQuestion()
        {
            //Arrange
            int testId = 1;
            string testAnswer = "TestAnswer";
            string testType = "Sysr";
            int studentId = 1;
            int id = 35;
            int nId = id + 1;
            QuestionViewModel viewModel = new QuestionViewModel();
            viewModel.TestId = testId;
            viewModel.AnswerValue = testAnswer;
            viewModel.StudentId = studentId;
            viewModel.TestType = testType;
            viewModel.QuestionId = id;
            //FormCollection formValues = new FormCollection();
            //formValues.Add("testId", testId.ToString());
            //formValues.Add("answer", testAnswer);
            //formValues.Add("studentId", studentId.ToString());
            //formValues.Add("testType", testType);



            Test mockTest = new Test();
            mockTest.Id = testId;
            mockTest.Type = testType;
            Question mockQuestion = new Question();
            mockQuestion.Id = id;
            mockQuestion.Type = "Radio6";
            Student mockStudent = new Student();
            mockStudent.Id = studentId;
            Answer mockAnswer = new Answer();
            mockAnswer.Value = testAnswer;

            Mock<ITestService> mockTestService = new Mock<ITestService>();

            mockTestService.Setup(m => m.GetTest(mockTest.Id)).Returns(mockTest);
            mockTestService.Setup(m => m.SaveAnswer(mockTest, mockAnswer, mockQuestion));
            mockTestService.Setup(m => m.GetQuestion(id)).Returns(mockQuestion);
            mockTestService.Setup(m => m.GetNextQuestion(mockTest, mockQuestion)).Returns(new Question { Id = nId, Type = "Radio6" });
            TestController target = new TestController(mockTestService.Object);


            //Act
            var result = target.Question(id, viewModel);
            var model = target.ViewData.Model as QuestionViewModel;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.IsTrue(model.QuestionId == nId);
        }
    }
}
