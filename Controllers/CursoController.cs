using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstWeb.Context;
using MyFirstWeb.Models;
using Newtonsoft.Json;

namespace MyFirstWeb.Controllers
{
    public class CursoController : Controller
    {
        public DbPrueba context { get; set; }
        public CursoController()
        {
            this.context = new DbPrueba();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Guardar(Curso curso)
        {
            try
            {
                context.cursos.Add(curso);
                context.SaveChanges();

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    mensaje = ex.Message
                });
            }
        }

        public JsonResult showCourses()
        {
            var listCourses = context.cursos.ToList();
            return Json(listCourses);
        }

        [HttpGet]
        public JsonResult getStudentsByGrade(int course)
        {
            try
            {
                var courseInstance = context.cursos.Find(course);
                var listStudent = context.students.Where(x => x.grado == courseInstance.grado).ToList();
                return Json(new
                {
                    success = true,
                    students = listStudent
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public JsonResult SaveStudentByCourse(List<CourseStudent> st,int lqs)
        {
            try
            {
                context.courseStudents.AddRange(st);
                context.SaveChanges();

                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    mensaje = ex.Message
                });
            }
        }

    }
}