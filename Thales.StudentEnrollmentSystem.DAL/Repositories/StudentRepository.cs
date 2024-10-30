using Microsoft.EntityFrameworkCore;
using Thales.StudentEnrollmentSystem.DAL.Data;
using Thales.StudentEnrollmentSystem.DAL.Models;

namespace Thales.StudentEnrollmentSystem.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentEnrollmentDbContext _context;

        public StudentRepository(StudentEnrollmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            //return await _context.Students.FindAsync(id);
            if (id <= 0)
    {
        throw new ArgumentException("Invalid student ID.", nameof(id));
    }

    // Attempt to find the student by ID
    var student = await _context.Students.FindAsync(id);

    // Check if the student was found
    if (student == null)
    {
        throw new KeyNotFoundException($"Student with ID {id} not found.");
    }

    return student;
        }

        public async Task AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
