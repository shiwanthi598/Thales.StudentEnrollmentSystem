using Microsoft.EntityFrameworkCore;
using Thales.StudentEnrollmentSystem.DAL.Models;

namespace Thales.StudentEnrollmentSystem.DAL.Data
{
    public class StudentEnrollmentDbContext : DbContext
    {
        public StudentEnrollmentDbContext(DbContextOptions<StudentEnrollmentDbContext> options)
            : base(options)
        {
        }

        // Define your DbSets here
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        // Add other DbSets as needed
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
