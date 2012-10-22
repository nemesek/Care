using Care.Domain;
using Care.Domain.Abstract;
using System;
using System.Collections.Generic;
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
        private ICareUow _uow;
        private IQuestionGenerator questionGen;

        public TestController(ICareUow uow, IQuestionGenerator questionGenerator)
        {
            _uow = uow;
            questionGen = questionGenerator;
        }

        public ActionResult Index(int ? id)
        {
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
            //Question prevQuestion = new Question();
            Question prevQuestion = new Question();
            if (id.HasValue)
            {
                //prevQuestion.Id = 18;
                prevQuestion.Id = id.Value;
            }
            else
            {
                prevQuestion.Id = 18;
            }
           
            //prevQuestion.Id = 18;
            Question question = questionGen.GetNextQuestion(prevQuestion, new Answer());         
            return View(question);
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
