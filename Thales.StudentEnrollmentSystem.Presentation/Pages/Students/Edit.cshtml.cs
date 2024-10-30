using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Thales.StudentEnrollmentSystem.DAL.Repositories;
//using Thales.StudentEnrollmentSystem.DAL.Repositories;
using Thales.StudentEnrollmentSystem.DAL.Models;
using System.Threading.Tasks;

namespace Thales.StudentEnrollmentSystem.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public EditModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await _studentRepository.GetStudent(id);

            if (Student == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _studentRepository.UpdateStudent(Student);
            return RedirectToPage("Index");
        }
    }
}
