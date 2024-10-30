using Microsoft.AspNetCore.Mvc;
using Thales.StudentEnrollmentSystem.DAL.Repositories;
using Thales.StudentEnrollmentSystem.DAL.Models;

namespace Thales.StudentEnrollmentSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(_studentRepository.GetStudents());
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
            return CreatedAtAction(nameof(GetStudents), new { id = student.StudentId }, student);
        }
    }
}
