using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Care.Domain.Abstract;
using Care.Domain;
using Care.Domain.Concrete;

namespace Care.Tests
{
    [TestClass]
    public class QuestionGeneratorTest
    {
        [TestMethod]
        public void QuestionGenerator_Can_GetNextQuestion()
        {
            //Arrange
            //constructor args = ICareUow
            //method args = Test test, Question prevQuestion, ITestLogic logic
            int questionId = 1;
            int nextQuestionId = questionId + 1;
            Test mockTest = new Test();
            Question mockQuestion = new Question();

            Mock<ICareUow> mockUow = new Mock<ICareUow>();
            Mock<ITestLogic> mockTestLogic = new Mock<ITestLogic>();
            
            mockTestLogic.Setup(m => m.GetQuestionId(mockTest, mockQuestion, mockUow.Object)).Returns(nextQuestionId);
            mockUow.Setup(m => m.Questions.GetById(nextQuestionId)).Returns(new Question { Id = nextQuestionId });
            QuestionGenerator target = new QuestionGenerator(mockUow.Object);

            //Act
            Question question = target.GetNextQuestion(mockTest, mockQuestion, mockTestLogic.Object);

            //Assert
            Assert.IsNotNull(question);
            Assert.AreEqual(question.Id, nextQuestionId);
        }
    }
}
