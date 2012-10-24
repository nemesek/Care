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
            if (testType != null)
            {
                string test = testType.ToUpper();
                switch (test)
                {
                    case "SYSR":
                        return new SysrTestLogic();
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
