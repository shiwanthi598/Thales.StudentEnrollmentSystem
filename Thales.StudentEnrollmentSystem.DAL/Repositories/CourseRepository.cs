using Microsoft.EntityFrameworkCore;
using Thales.StudentEnrollmentSystem.DAL.Data;
//using Thales.StudentEnrollmentSystem.DAL.Data; // Ensure this is the correct namespace for your DbContext
using Thales.StudentEnrollmentSystem.DAL.Models; // Ensure this matches your project structure
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thales.StudentEnrollmentSystem.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentEnrollmentDbContext _context;

        public CourseRepository(StudentEnrollmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            try
            {
                return await GetCourseByIdAsync(id);
            }
            catch (KeyNotFoundException ex)
            {
                // Handle the not found scenario
                // For example, log the exception or return null
                return null; // Or you can throw a custom exception
            }
        }

        public async Task AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}
