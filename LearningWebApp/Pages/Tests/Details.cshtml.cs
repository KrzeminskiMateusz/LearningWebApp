using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LearningRazorPages.Data;
using LearningRazorPages.Models;

namespace LearningRazorPages.Pages.Tests
{
    public class DetailsModel : PageModel
    {
        private readonly LearningRazorPages.Data.LearningRazorPagesContext _context;

        public DetailsModel(LearningRazorPages.Data.LearningRazorPagesContext context)
        {
            _context = context;
        }

        public Test Test { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Test = await _context.Test.FirstOrDefaultAsync(m => m.ID == id);

            if (Test == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
