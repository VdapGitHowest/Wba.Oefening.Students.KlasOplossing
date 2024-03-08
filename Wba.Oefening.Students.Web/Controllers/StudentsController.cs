using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using Wba.Oefening.Students.Core;
using Wba.Oefening.Students.Web.ViewModels;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;

        public StudentsController()
        {
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowStudents()
        {
            var students = _studentRepository.Students.ToList();


            if (students == null)
            {
                return NotFound("Students not found");
            }

            StudentsShowStudentsViewModel studentsShowStudentsViewModel = new StudentsShowStudentsViewModel();
            
            foreach(var student in students)
            {
                StudentsShowStudentDetailViewModel studentDetailViewModel = new StudentsShowStudentDetailViewModel
                {
                    Id = student.Id,
                    StudentName = $"{student.LastName} {student.FirstName}",
                };

                studentsShowStudentsViewModel.Students.Add(studentDetailViewModel);
            }

            return View(studentsShowStudentsViewModel);
        }

        public IActionResult ShowStudentDetail(int id)
        {
            var student = _studentRepository.Students.FirstOrDefault(s=>s.Id == id);

            if (student == null)
            {
                return NotFound("Student not found");
            }


            StudentsShowStudentDetailViewModel studentsShowStudentDetailViewModel =
                new StudentsShowStudentDetailViewModel
                {
                    Id = student.Id,
                    StudentName = $"{student.LastName} {student.FirstName}",
                    CoursesNames = student.Courses.Select(s => s.Name)
                    
                };

            return View(studentsShowStudentDetailViewModel);
        }
    }
}
