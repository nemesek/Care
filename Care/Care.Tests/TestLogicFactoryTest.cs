using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Care.Domain.Concrete;
using Care.Domain.Abstract;

namespace Care.Tests
{
    [TestClass]
    public class TestLogicFactoryTest
    {
        [TestMethod]
        public void TestLogicFactory_Can_CreateTestLogicInstance()
        {
            //Arrange
            //method args = string testType
            bool result = false;
            string sysrTestType = "Sysr";
            string mapsTestType = "Maps";

            TestLogicFactory target = new TestLogicFactory();

            //Act
            ITestLogic testLogic1 = target.CreateTestLogicInstance(sysrTestType);
            ITestLogic testLogic2 = target.CreateTestLogicInstance(mapsTestType);
            if (testLogic1 is SysrTestLogic)
            {
                if (testLogic2 is MapsTestLogic)
                {
                    result = true;
                }                
            }

            //Assert
            Assert.IsTrue(result);
        }
    }
}
