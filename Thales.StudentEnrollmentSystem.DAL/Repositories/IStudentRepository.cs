using Thales.StudentEnrollmentSystem.DAL.Models;

namespace Thales.StudentEnrollmentSystem.DAL.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}
