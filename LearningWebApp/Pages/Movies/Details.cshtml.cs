using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LearnignRazorPages.Models;
using LearningRazorPages.Data;

namespace LearningRazorPages.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly LearningRazorPages.Data.LearningRazorPagesContext _context;

        public DetailsModel(LearningRazorPages.Data.LearningRazorPagesContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
