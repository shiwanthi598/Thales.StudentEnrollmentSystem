using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thales.StudentEnrollmentSystem.DAL.Repositories; // Ensure this is correct
using Thales.StudentEnrollmentSystem.DAL.Models;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;

    public CoursesController(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
        var courses = await _courseRepository.GetAllCoursesAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
        var course = await _courseRepository.GetCourseByIdAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<Course>> CreateCourse(Course course)
    {
        await _courseRepository.AddCourseAsync(course);
        return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, course);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(int id, Course course)
    {
        if (id != course.CourseId)
        {
            return BadRequest();
        }
        await _courseRepository.UpdateCourseAsync(course);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        await _courseRepository.DeleteCourseAsync(id);
        return NoContent();
    }
}
