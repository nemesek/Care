using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Care.Domain;

namespace Care.ViewModels
{
    public class TestViewModel
    {
        public TestViewModel() { }
        public string TestId { get; set; }
        public string StudentId { get; set; }
        //public string AnswerValue { get; set; }
        public string QuestionId { get; set; }

    }
}