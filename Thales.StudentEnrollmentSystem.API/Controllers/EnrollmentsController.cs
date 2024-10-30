using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thales.StudentEnrollmentSystem.DAL.Repositories; // Ensure this is correct
using Thales.StudentEnrollmentSystem.DAL.Models;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentsController : ControllerBase
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollmentsController(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()
    {
        var enrollments = await _enrollmentRepository.GetAllEnrollmentsAsync();
        return Ok(enrollments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Enrollment>> GetEnrollment(int id)
    {
        var enrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(id);
        if (enrollment == null)
        {
            return NotFound();
        }
        return Ok(enrollment);
    }

    [HttpPost]
    public async Task<ActionResult<Enrollment>> CreateEnrollment(Enrollment enrollment)
    {
        await _enrollmentRepository.AddEnrollmentAsync(enrollment);
        return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.EnrollmentId }, enrollment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEnrollment(int id, Enrollment enrollment)
    {
        if (id != enrollment.EnrollmentId)
        {
            return BadRequest();
        }
        await _enrollmentRepository.UpdateEnrollmentAsync(enrollment);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        await _enrollmentRepository.DeleteEnrollmentAsync(id);
        return NoContent();
    }
}
