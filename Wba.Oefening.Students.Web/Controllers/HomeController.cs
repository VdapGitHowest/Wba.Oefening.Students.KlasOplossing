using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Students.Web.Models;
using Wba.Oefening.Students.Core;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly TeacherRepository _teacherRepository;

        public HomeController()
        {
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
            _teacherRepository = new TeacherRepository();
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Student App";
            ViewBag.Message = "Welcome on our Student App";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
