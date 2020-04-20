using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearningRazorPages.Data;
using LearningRazorPages.Models;

namespace LearningRazorPages.Pages.Tests
{
    public class EditModel : PageModel
    {
        private readonly LearningRazorPages.Data.LearningRazorPagesContext _context;

        public EditModel(LearningRazorPages.Data.LearningRazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Test).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(Test.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TestExists(int id)
        {
            return _context.Test.Any(e => e.ID == id);
        }
    }
}
