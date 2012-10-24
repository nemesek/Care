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
        private IQuestionGenerator questionGen;
        
        //public TestController(ICareUow uow, IQuestionGenerator questionGenerator)
        public TestController(IQuestionGenerator questionGenerator)
        {
            //_uow = uow;
            questionGen = questionGenerator;
        }

        public ActionResult StartSysr()
        {
            return View();
        }

        public ActionResult Question(int? id, FormCollection formCollection)
        {
            //Read form values
            string testIdValue = ParseFormValue(formCollection, "testId");
            string answerValue = ParseFormValue(formCollection, "ratings");
            string  studentIdValue = ParseFormValue(formCollection, "studentId");
            string testType = ParseFormValue(formCollection, "testType");
            int testId = 0;
            int studentId = 0;
            if (testIdValue != null)
            {
                 testId = ConvertStringToInt(testIdValue);
            }

            if (studentIdValue != null && studentIdValue != "")
            {
                studentId = ConvertStringToInt(studentIdValue);
            }

            ViewBag.TestId = testId;
            ViewBag.StudentId = studentId;           
          

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
           
            Question question = questionGen.GetNextQuestion(prevQuestion, new Answer());
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
                    //break;
                    default:
                        return View(question);
                    //break;
                }
            }
            else
            {
                return View("TestComplete");
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
