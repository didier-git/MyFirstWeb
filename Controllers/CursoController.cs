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
                    success = true,
                    curso = curso
                });
            }
            catch (Exception ex) {
                return Json(new
                {
                    success = false,
                    mensaje = ex.Message
                });
            }
        }
    }
}