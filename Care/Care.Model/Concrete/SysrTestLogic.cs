﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Care.Domain.Abstract;

namespace Care.Domain.Concrete
{
    public class SysrTestLogic : ITestLogic
    {
        public int GetQuestionId(Question prevQuestion, Answer prevAnswer)
        {
            int newQuestionId = prevQuestion.Id + 1;
            return newQuestionId;  //TODO actually implement the logic
        }
    }
}
