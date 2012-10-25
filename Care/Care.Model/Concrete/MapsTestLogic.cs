using Care.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Domain.Concrete
{
    public class MapsTestLogic : ITestLogic
    {
        public int GetQuestionId(Test test, Question prevQuestion, ICareUow uow)
        {
            if (prevQuestion == null)
            {
                return 35;
            }
            int newQuestionId = prevQuestion.Id + 1;
            return newQuestionId;  //TODO actually implement the logic
        }
    }
}
