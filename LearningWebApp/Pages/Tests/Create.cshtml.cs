using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LearningRazorPages.Data;
using LearningRazorPages.Models;

namespace LearningRazorPages.Pages.Tests
{
    public class CreateModel : PageModel
    {
        private readonly LearningRazorPages.Data.LearningRazorPagesContext _context;

        public CreateModel(LearningRazorPages.Data.LearningRazorPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Test Test { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Test.Add(Test);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
