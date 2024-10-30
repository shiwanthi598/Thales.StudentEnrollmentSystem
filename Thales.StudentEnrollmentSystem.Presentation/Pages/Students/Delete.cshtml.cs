using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Thales.StudentEnrollmentSystem.DAL.Models; // Replace with the correct namespace for your models
using Thales.StudentEnrollmentSystem.DAL.Data;  // Replace with the correct namespace for your DbContext

namespace Thales.StudentEnrollmentSystem.Presentation.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly StudentEnrollmentDbContext _context;

        public DeleteModel(StudentEnrollmentDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        // Get the student details based on the provided id
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Handle the delete operation
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students.FindAsync(id);

            if (Student != null)
            {
                _context.Students.Remove(Student);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
