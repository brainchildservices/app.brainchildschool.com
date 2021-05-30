using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Controllers
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


        public IActionResult OurTeam()
        {
            return View();
        }

        public IActionResult CourseDetails()
        {
            return View();
        }

        public IActionResult HireBrainChild()
        {
            return View();
        }
        
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult WorkWithUs()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

         public IActionResult Success()
        {
            return View();
        }
    }
}
