using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWeb.Context;
using MyFirstWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWeb.Controllers
{
    public class StudentController : Controller
    {
        public DbPrueba context { get; set; }
        public StudentController()
        {
            this.context = new DbPrueba();
        }
        // GET: StudentController
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Details/5
        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Students()
        {
            var students = context.students.ToList();
            return View(students);
        }

    
        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                context.students.Add(student);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        [HttpGet]
        public JsonResult Edit(int id)
        {
            var student = context.students.Find(id);
            return Json(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        public JsonResult Edit(Student student)
        {
            try
            {
                context.students.Update(student);
                context.SaveChanges();

                return Json(new
                {
                    success = true
                });
            }
            catch
            {
                return Json(new
                {
                    success = false
                });
            }
        }

        // GET: StudentController/Delete/5
        public JsonResult Delete(int id)
        {
            var student = context.students.Find(id);
            context.students.Remove(student);
            context.SaveChanges();
            return Json(new
            {
                success = true,
            }) ;

        }
        
        //public ActionResult Delete(int id)
        //{
        //    var student = context.students.Find(id);
        //    context.students.Remove(student);
        //    context.SaveChanges();
        //    var students = context.students.ToList();
        //    return View("Students", students);

        //}

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
     
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
