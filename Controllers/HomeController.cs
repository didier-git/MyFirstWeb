using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/Contactenos")]
        public IActionResult ContactUs()
        {
            var contactModel = new ContactModel {
                email = "ditruhoy@gmail.com",
                observation ="Contratenme"
            };
            return View(contactModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateContact(ContactModel contact)
        {
            TempData["data"] = contact.email + " " + contact.observation;
            return View("ContactUs", contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
