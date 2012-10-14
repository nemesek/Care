using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Model.Abstract
{
    public interface ITestLogic
    {
        int GetQuestionId(Question prevQuestion, Answer prevAnswer);

    }
}
