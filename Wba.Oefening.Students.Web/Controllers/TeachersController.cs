using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Students.Core;
using Wba.Oefening.Students.Web.ViewModels;

namespace Wba.Oefening.Students.Web.Controllers
{

    public class TeachersController : Controller
    {

        private readonly TeacherRepository _teacherRepository;
        private readonly CourseRepository _courseRepository;

        public TeachersController()
        {
            _teacherRepository = new TeacherRepository();
            _courseRepository = new CourseRepository();
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ShowTeachers()
        {
            //fetch data

            var teachers = _teacherRepository.Teachers.ToList();
            //instance list detailvm

            if(!teachers.Any())
            {
                return NotFound("Teachers not found");
            }

            TeachersShowTeachersViewModel teachersShowTeachersViewModel = new TeachersShowTeachersViewModel();

                  //map
            foreach (var teacher in teachers)
            {
                var courseForTeachers=teacher.Courses.Select(c => c.Name);

                //instance detailvm
                
                TeachersShowTeacherDetailViewModel showTeacherDetailViewModel =
                    new TeachersShowTeacherDetailViewModel
                    //map en fill
                    {
                        TeacherId = teacher.Id,
                        TeacherName = $"{teacher.FirstName} {teacher.LastName}",
                        CourseNames = courseForTeachers
                    };

                //add to list
                teachersShowTeachersViewModel.GetTeachers.Add(showTeacherDetailViewModel);

            }
           
            //return to view
            return View(teachersShowTeachersViewModel);
        }
        public IActionResult ShowTeacherDetail(long teacherId)
        {
            //fetch data

            var teacher = _teacherRepository.GetTeacherById(teacherId);

            if (teacher==null)
            {
                return NotFound("Teacher not found");
            }

            //instance vm

            TeachersShowTeacherDetailViewModel teachersShowTeacherDetailViewModel = new TeachersShowTeacherDetailViewModel();

            //map vm with data

            //null check

            if (teacher == null)
            {
                return NotFound("Teacher not in list");
            }

            //fill vm

            teachersShowTeacherDetailViewModel.TeacherName = $"{teacher.FirstName} {teacher.LastName}";
            teachersShowTeacherDetailViewModel.CourseNames = teacher.Courses.Select(c => c.Name);

            //traditional
            ////traditional code, without .Select() 
            //var courseNames = new List<string>();
            //foreach (var course in teacher.Courses)
            //{
            //    courseNames.Add(course.Name);
            //}
            //viewModel.Courses = courseNames;


            //giv vm to view

            return View(teachersShowTeacherDetailViewModel);
        }






    }
}
