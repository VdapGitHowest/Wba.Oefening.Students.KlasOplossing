using Wba.Oefening.Students.Core;

namespace Wba.Oefening.Students.Web.ViewModels
{
    public class StudentsShowStudentDetailViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public IEnumerable<String> CoursesNames { get; set; }
    }
}
