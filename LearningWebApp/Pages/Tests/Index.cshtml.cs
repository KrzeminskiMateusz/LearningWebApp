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
    public class IndexModel : PageModel
    {
        private readonly LearningRazorPages.Data.LearningRazorPagesContext _context;

        public IndexModel(LearningRazorPages.Data.LearningRazorPagesContext context)
        {
            _context = context;
        }

        public IList<Test> Test { get;set; }

        public async Task OnGetAsync()
        {
            Test = await _context.Test.ToListAsync();
        }
    }
}
