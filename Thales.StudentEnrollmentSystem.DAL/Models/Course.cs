namespace Thales.StudentEnrollmentSystem.DAL.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
