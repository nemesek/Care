using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Domain.Abstract
{
    public interface ITestLogic
    {
        int GetQuestionId(Test test, Question prevQuestion, ICareUow uow);

    }
}
