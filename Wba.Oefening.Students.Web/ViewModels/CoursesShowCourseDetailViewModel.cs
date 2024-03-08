using Wba.Oefening.Students.Core;

namespace Wba.Oefening.Students.Web.ViewModels
{
    public class CoursesShowCourseDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Student> CourseStudents { get; set; }
    }
}
