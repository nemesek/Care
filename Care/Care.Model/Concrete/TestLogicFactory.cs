using Care.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Domain.Concrete
{
    public class TestLogicFactory
    {
        public TestLogicFactory() { }
        public virtual ITestLogic CreateTestLogicInstance(string testType)
        {
            return this.GetInstance(testType);
        }

        private ITestLogic GetInstance(string testType)
        {
            switch (testType)
            {
                case "Sysr":
                    return new SysrTestLogic();
                default:
                    return null;
            }
        }
    }
}
