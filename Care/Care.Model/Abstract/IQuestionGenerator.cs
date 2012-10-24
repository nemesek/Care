using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Domain.Abstract
{
    public interface IQuestionGenerator
    {
        Question GetNextQuestion(Test test, Question prevQuestion, ITestLogic logic);
    }
}
