using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.Extensions.Configuration;

namespace ContosoUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly SchoolContext _context;
        private readonly IConfiguration configRoot;

        public DetailsModel(SchoolContext context, IConfiguration configRoot)
        {
            _context = context;
            this.configRoot = configRoot;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                    .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }

            ViewData["xxx"] = configRoot.GetConnectionString("SchoolContext");

            return Page();
        }
    }
}
