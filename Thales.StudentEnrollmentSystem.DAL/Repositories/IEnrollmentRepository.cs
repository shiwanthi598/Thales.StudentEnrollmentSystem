using Thales.StudentEnrollmentSystem.DAL.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;

namespace Thales.StudentEnrollmentSystem.DAL.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();
        Task<Enrollment> GetEnrollmentByIdAsync(int id);
        Task AddEnrollmentAsync(Enrollment enrollment);
        Task UpdateEnrollmentAsync(Enrollment enrollment);
        Task DeleteEnrollmentAsync(int id);
    }
}
