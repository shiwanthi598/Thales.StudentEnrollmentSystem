using Microsoft.EntityFrameworkCore;
using Thales.StudentEnrollmentSystem.DAL.Models;
using Thales.StudentEnrollmentSystem.DAL.Data;
using Thales.StudentEnrollmentSystem.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Thales.StudentEnrollmentSystem.DAL.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly StudentEnrollmentDbContext _context;

        public EnrollmentRepository(StudentEnrollmentDbContext context)
        {
            _context = context;
        }

        // Get all enrollments asynchronously
        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _context.Enrollments.ToListAsync();
        }

        // Get enrollment by ID asynchronously
        public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            //return await _context.Enrollments.FindAsync(id);
             if (id <= 0)
    {
        throw new ArgumentException("Invalid enrollment ID.", nameof(id));
    }

    // Use FindAsync to fetch the enrollment by ID
    var enrollment = await _context.Enrollments.FindAsync(id);

    // Return null if not found
                if (enrollment == null)
                {
                    // Optionally, you can throw an exception or return a special value indicating not found
                    throw new KeyNotFoundException($"Enrollment with ID {id} not found.");
                }

                return enrollment;
                    }

        // Add a new enrollment asynchronously
        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
        }

        // Update an existing enrollment asynchronously
        public async Task UpdateEnrollmentAsync(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
        }

        // Delete an enrollment by ID asynchronously
        public async Task DeleteEnrollmentAsync(int id)
        {
            var enrollment = await GetEnrollmentByIdAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }
        }
    }
}