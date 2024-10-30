using Microsoft.AspNetCore.Mvc.RazorPages;
using Thales.StudentEnrollmentSystem.DAL.Repositories;
using Thales.StudentEnrollmentSystem.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Thales.StudentEnrollmentSystem.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public IndexModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> Students { get; set; }

        public async Task OnGetAsync()
        {
            Students = await _studentRepository.GetStudents();
        }
    }
}
