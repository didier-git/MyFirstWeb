using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstWeb.Context;
using MyFirstWeb.Models;


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
                var corseStuden = context.courseStudents
                    .Where(x=> x.curso == courseInstance.id)
                    .Select(x=>x.estudiante).ToList();
                var listStudent = context.students
                    .Where(x => x.grado == courseInstance.grado)
                    .Select(x => new { 
                        id=x.id,
                        nombre=x.nombre,
                        isInCourse= corseStuden.Contains(x.id)
                    }).ToList();

                //var newList = listStudent.Where(x => !corseStuden.Contains(x.id)).ToList();



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
        public JsonResult SaveStudentByCourse(List<CourseStudent> students, int loquesea)
        {
            try
            {
                context.courseStudents.AddRange(students);
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