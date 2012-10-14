using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Care.Model.Abstract;

namespace Care.Model.Concrete
{
    public class SysrTestLogic : ITestLogic
    {
        public int GetQuestionId(Question prevQuestion, Answer prevAnswer)
        {

            return prevQuestion.Id++;  //TODO actually implement the logic
        }
    }
}
