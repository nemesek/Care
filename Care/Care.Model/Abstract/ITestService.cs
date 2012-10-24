using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Domain.Abstract
{
    public interface ITestService
    {
        Question GetNextQuestion(Test test, Question prevQuestion);
        void SaveAnswer(Test test, Answer answer);
        Test GetTest(int? testId);
        Student GetStudent(int? studentId);
        Test CreateTest(string testType);

    }
}
