using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Wba.Oefening.Students.Core;
using Wba.Oefening.Students.Web.ViewModels;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseRepository _courseRepository;
        private readonly StudentRepository _studentRepository;


        public CoursesController()
        {
            _courseRepository = new CourseRepository();
            _studentRepository = new StudentRepository();

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowCourses()
        {
            var courses = _courseRepository.Courses.ToList();

            if (courses == null)
            {
                return NotFound("Courses not found");
            }

            CoursesShowCoursesViewModel coursesShowCoursesViewModel =
                new CoursesShowCoursesViewModel();

            foreach (var course in courses)
            {
                CoursesShowCourseDetailViewModel showCourseDetailViewModel = new CoursesShowCourseDetailViewModel
                {
                    //nullcoalescing (waardeNull ?? default), for default values for
                    //nullable types
                   // Providing a default value if Course.Id is null
                    Id = course?.Id ?? 0,
                    // Providing a default value if Course.Name is null
                    Name = course?.Name ?? "No Name",
                };
                coursesShowCoursesViewModel.Courses.Add(showCourseDetailViewModel);
            }

            return View(coursesShowCoursesViewModel);
        }


        public IActionResult ShowCourseDetail(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            var students = _studentRepository.GetStudentsInCourseId(id);

            if (course == null)
            {
                return NotFound("Course not found");
            }

            if (students == null)
            {
                return NotFound("Students for Course not found");
            }

            CoursesShowCourseDetailViewModel coursesShowCourseDetailViewModel = new CoursesShowCourseDetailViewModel
            {
                Id = course.Id,
                Name = course.Name,
                CourseStudents = students
            };

            return View(coursesShowCourseDetailViewModel);
        }
    }
}
