namespace Wba.Oefening.Students.Web.ViewModels
{
    public class TeachersShowTeacherDetailViewModel
    {
        public long TeacherId { get; set; }
        public string TeacherName { get; set; }
        public IEnumerable<string> CourseNames { get; set; }
    }

}
