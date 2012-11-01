using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Care.Domain;

namespace Care.ViewModels
{
    public class QuestionViewModel
    {
        public QuestionViewModel() { }
        public int TestId { get; set; }
        public int StudentId { get; set; }
        public string AnswerValue { get; set; }
        public int QuestionId { get; set; }
        public string QuestionValue { get; set; }
        public string TestType { get; set; }

    }
}