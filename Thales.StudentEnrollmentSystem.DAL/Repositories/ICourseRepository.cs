using Thales.StudentEnrollmentSystem.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thales.StudentEnrollmentSystem.DAL.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
    }
}
