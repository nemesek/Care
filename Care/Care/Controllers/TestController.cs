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
        private ITestService service;
                
        public TestController(ITestService testService)
        {
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
            Question prevQuestion = null;
            Question nextQuestion;
            Test test = null;

            studentId = ConvertStringToInt(studentIdValue);

            if (studentId == 0)
                return View("Error");

            testId = ConvertStringToInt(testIdValue);

            //Checks if test is new 
            if (testId == 0)
            {
                ////Get new TestId by passing studentId, testType to TestService
                Student student = service.GetStudent(studentId);
                test = service.CreateTest(testType, student);
                testId = test.Id;
            }

            //Update ViewBag
            ViewBag.TestId = testId;
            ViewBag.StudentId = studentId;
            ViewBag.TestType = testType;


            if (id.HasValue)
            {
                prevQuestion = service.GetQuestion(id.Value);                
            }     

            //Save answer
            if (answerValue != null && prevQuestion != null)
            {
                Answer answer = new Answer();
                answer.Value = answerValue;
                test = service.GetTest(testId);
                service.SaveAnswer(test, answer, prevQuestion);                
            }

 
            //Get next question and figure out which PartialView to render
            nextQuestion= service.GetNextQuestion(test, prevQuestion);

            if (nextQuestion == null)
            {
                return View("Complete");
            }

            ViewBag.Partial = GetViewName(nextQuestion);
            if (ViewBag.Partial == "Error")
            {
                return View("Error");
            }

            return View(nextQuestion);
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
            if (num != null && num != "")
            {
                int retId;
                bool result = Int32.TryParse(num, out retId);
                if (result)
                {
                    return retId;

                }
            }

            return 0;
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
                        return"Radio2Partial";
                    case "Radio5":
                        return "Radio5Partial";
                    case "InputText":
                        return  "InputTextPartial";
                    default:
                        return "Error";
               }
            }
            else
            {
                return "Complete";
            }
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
