using Care.Domain;
using Care.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Radio6(int? id, FormCollection formCollection)
        {
            int testId;
            string answerValue = "";
            foreach (string formData in formCollection)
            {
                if (formData == "ratings")
                {
                    answerValue = formCollection[formData];
                }
                if (formData == "testId") 
                {
                    bool result = Int32.TryParse(formCollection[formData], out testId);
                    if (result)
                    {
                        ViewBag.TestId = testId;

                    }
                    else
                    {
                        ViewBag.TestId = 22;
                    }
                }
            }

            if (answerValue != "")
            {
                //string x = "not implemented"; //TODO Save Answer -- ? Move if logic to Service Layer
                Answer answer = new Answer();
                answer.Value = answerValue;
                
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
                        return View(question);
                    //break;
                    case "Radio2":
                        return View("Radio2", question);
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
    }
}
