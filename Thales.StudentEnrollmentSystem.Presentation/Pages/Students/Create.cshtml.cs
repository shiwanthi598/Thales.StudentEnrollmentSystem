using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Thales.StudentEnrollmentSystem.DAL.Repositories;
using Thales.StudentEnrollmentSystem.DAL.Models;
using System.Threading.Tasks;

namespace Thales.StudentEnrollmentSystem.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public CreateModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [BindProperty]
        public Student Student { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _studentRepository.AddStudent(Student);
            return RedirectToPage("Index");
        }
    }
}
