using Care.Domain;
using Care.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Care.ViewModels;

namespace Care.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        //private ICareUow _uow;
        private ITestService service;
        
        //public TestController(ICareUow uow, IQuestionGenerator questionGenerator)
        public TestController(ITestService testService)
        {
            //_uow = uow;
            this.service = testService;
        }

        public ActionResult StartSysr()
        {
            return View();
        }

        public ActionResult Question(int? id, FormCollection formCollection)
        {
            //Read form values
            string testIdValue = ParseFormValue(formCollection, "testId");
            string answerValue = ParseFormValue(formCollection, "answer");
            string  studentIdValue = ParseFormValue(formCollection, "studentId");
            string testType = ParseFormValue(formCollection, "testType");
            int testId = 0;
            int studentId = 0;

            if (studentIdValue != null && studentIdValue != "")
            {
                studentId = ConvertStringToInt(studentIdValue);
            }
            else
            {
                return View("Error");
            }

            if (testIdValue != null)
            {
                testId = ConvertStringToInt(testIdValue);
            }
            else
            {
                //Get new TestId by passing studentId, testType to TestService
                testId = 0;
            }

            ViewBag.TestId = testId;
            ViewBag.StudentId = studentId;
            ViewBag.TestType = testType;
          

            if (answerValue != null)
            {
                //string x = "not implemented"; //TODO Save Answer -- ? Move if logic to Service Layer
                Answer answer = new Answer();
                answer.Value = answerValue;
                
            }        
            
            Question prevQuestion = new Question();   //TODO ? move if else logic to Service Layer
            if (id.HasValue)
            {
                prevQuestion.Id = id.Value;
            }
            else
            {
                //prevQuestion.Id = 0;
                prevQuestion.Id = 35;
            }

            Test test = new Test();  //TODO change this stuff
            test.Id = testId;
            test.Type = testType;
            //Question question = questionGen.GetNextQuestion(new Test(), prevQuestion, new Answer());
            Question question = service.GetNextQuestion(test, prevQuestion);
            if (question != null)
            {
                switch (question.Type)
                {
                    case "Radio6":
                        ViewBag.Partial = "Radio6Partial";
                        return View(question);
                    //break;
                    case "Radio2":
                        ViewBag.Partial = "Radio2Partial";
                        return View(question);
                    case "Radio5":
                        ViewBag.Partial = "Radio5Partial";
                        return View(question);
                    //break;
                    case "InputText":
                        ViewBag.Partial = "InputTextPartial";
                        return View(question);
                    default:
                        return View("Error");
                    //break;
                }
            }
            else
            {
                return View("Complete");
            }

        }

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

        private string ParseFormValue(FormCollection collection, string key )
        {
            if (collection[key] != null)
            {
                return collection[key];
            }

            return null;
        }

        private int ConvertStringToInt(string num)
        {
            int retId;
            bool result = Int32.TryParse(num, out retId);
            if (result)
            {
                return retId;

            }
            return 0;
        }
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
