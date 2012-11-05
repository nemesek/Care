using Care.Domain;
using Care.Domain.Abstract;
using System.Web.Mvc;
using Care.ViewModels;

namespace Care.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        private readonly ITestService _service;
                
        public TestController(ITestService testService)
        {
            _service = testService;
        }
        [Authorize]
        public ActionResult StartSysr()
        {
            return View();
        }

        [Authorize]
        public ActionResult Question( QuestionViewModel qvm) 
        {
            //if (!ModelState.IsValid)
            //    return View("Error");
           
            Test test = null;
            Question prevQuestion = null;
            Question nextQuestion = null;

            if (qvm.StudentId == 0)
                return View("Error");

            test = GetTest(qvm);

            //Get current question
            if (qvm.QuestionId > 0)
            {
                prevQuestion = _service.GetQuestion(qvm.QuestionId);
            }

            //Save answer
            SaveAnswer(qvm, prevQuestion, test);

            //Get next question
            nextQuestion = _service.GetNextQuestion(test, prevQuestion);

            //Check if Test is completed -- If not update model values
            if (nextQuestion == null)
            {
                return View("TestComplete");
            }
            else
            {
                qvm.QuestionId = nextQuestion.Id;
                qvm.QuestionValue = nextQuestion.Value;
                qvm.TestId = test.Id;
                ModelState.Remove("QuestionId");
            }

            //Figure out which PartialView to render
            ViewBag.Partial = GetViewName(nextQuestion);
            if (ViewBag.Partial == "Error")
            {
                return View("Error");
            }
            return View(qvm);
        }




        //public ActionResult Question(int? id, FormCollection formCollection)  //TODO - Do ModelBinding rather than using FormCollection
        //{
        //    //Read form values
        //    string testIdValue = ParseFormValue(formCollection, "testId");
        //    string answerValue = ParseFormValue(formCollection, "answer");
        //    string  studentIdValue = ParseFormValue(formCollection, "studentId");
        //    string testType = ParseFormValue(formCollection, "testType");
        //    int testId = 0;
        //    int studentId = 0;
        //    Question prevQuestion = null;
        //    Question nextQuestion = null;
        //    Test test = null;

        //    studentId = ConvertStringToInt(studentIdValue);

        //    if (studentId == 0)
        //        return View("Error");

        //    testId = ConvertStringToInt(testIdValue);

        //    //Get Test 
        //    test = GetTest(testType, ref testId, studentId);            

        //    //Update ViewBag
        //    UpdateViewBag(testType, testId, studentId);

        //    //Get current question
        //    if (id.HasValue)
        //    {
        //        prevQuestion = _service.GetQuestion(id.Value);                
        //    }     

        //    //Save answer
        //    //test = service.GetTest(testId);
        //    SaveAnswer(answerValue, testId, prevQuestion, test);
 
        //    //Get next question
        //    nextQuestion= _service.GetNextQuestion(test, prevQuestion);

        //    //Check if Test is completed
        //    if (nextQuestion == null)
        //    {
        //        return View("TestComplete");
        //    }

        //    //Figure out which PartialView to render
        //    ViewBag.Partial = GetViewName(nextQuestion);
        //    if (ViewBag.Partial == "Error")
        //    {
        //        return View("Error");
        //    }

        //    return View(nextQuestion);
        //}



        //
        // GET: /Test/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Test/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Test/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Test/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Test/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Test/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Test/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private string GetViewName(Question q)
        {
            if (q != null)
            {
                switch (q.Type)
                {
                    case "Radio6":
                        return "Radio6Partial";
                    case "Radio2":
                        return "Radio2Partial";
                    case "Radio5":
                        return "Radio5Partial";
                    case "InputText":
                        return "InputTextPartial";
                    default:
                        return "Error";
                }
            }
            return "Complete";
        }

        private void SaveAnswer(QuestionViewModel qvm, Question prevQuestion, Test test)
        {
            if (qvm.AnswerValue != null && prevQuestion != null)
            {
                Answer answer = new Answer();
                answer.Value = qvm.AnswerValue;
                //test = service.GetTest(testId);
                _service.SaveAnswer(test, answer, prevQuestion);
            }
        }
        private Test GetTest(QuestionViewModel qvm)
        {
            ////Get new TestId by passing studentId, testType to TestService
            Test t;
            Student student = _service.GetStudent(qvm.StudentId);
            if (qvm.TestId == 0)
            {
                t = _service.CreateTest(qvm.TestType, student);
                //testId = t.Id;
            }
            else
            {
                t = _service.GetTest(qvm.TestId);
            }

            return t;
        }


        //private string ParseFormValue(FormCollection collection, string key )
        //{
        //    if (collection[key] != null)
        //    {
        //        return collection[key];
        //    }

        //    return null;
        //}

        //private void SaveAnswer(string answerValue, int testId, Question prevQuestion, Test test)
        //{
        //    if (answerValue != null && prevQuestion != null)
        //    {
        //        Answer answer = new Answer();
        //        answer.Value = answerValue;
        //        //test = service.GetTest(testId);
        //        _service.SaveAnswer(test, answer, prevQuestion);
        //    }
        //    //return test;
        //}

        //private Test GetTest(string testType, ref int testId, int studentId)
        //{
        //    ////Get new TestId by passing studentId, testType to TestService
        //    Test t;
        //    Student student = _service.GetStudent(studentId);
        //    if (testId == 0)
        //    {
        //        t = _service.CreateTest(testType, student);
        //        testId = t.Id;
        //    }
        //    else
        //    {
        //        t = _service.GetTest(testId);
        //    }
        
        //    return t;
        //}

        //private void UpdateViewBag(string testType, int testId, int studentId)
        //{
        //    ViewBag.TestId = testId;
        //    ViewBag.StudentId = studentId;
        //    ViewBag.TestType = testType;
        //}

        //private int ConvertStringToInt(string num)
        //{
        //    if (!string.IsNullOrEmpty(num))
        //    {
        //        int retId;
        //        bool result = Int32.TryParse(num, out retId);
        //        if (result)
        //        {
        //            return retId;

        //        }
        //    }

        //    return 0;
        //}   
 
    }
}


//Administrator admin = new Administrator();
//admin.FirstName = "Dan";
//admin.LastName = "Nemesek";
//_uow.Administrators.Add(admin);
////Administrator admin = _uow.Administrators.GetById(1);
//for (int i = 0; i < 5; i++)
//{
//    Student student = new Student();
//    student.FirstName = "Charlie" + i.ToString();
//    student.LastName = "Brown" + i.ToString();
//    student.Administrator = admin;
//    _uow.Students.Add(student);
//}
//_uow.Commit();
////var students = _uow.Students.GetAll().FirstOrDefault(s => s.Administrator.Id == admin.Id);
//var students = _uow.Students.GetAll().Where(s => s.Administrator.Id == admin.Id);
