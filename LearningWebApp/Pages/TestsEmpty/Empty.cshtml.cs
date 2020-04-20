using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnignRazorPages.Models;
using LearningRazorPages.Data;
using LearningRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearningRazorPages.Pages.TestsEmpty
{
    public class EmptyModel : PageModel
    {
        private readonly LearningRazorPagesContext context;

        public EmptyModel(LearningRazorPagesContext context)
        {
            this.context = context;
        }

        [BindProperty]
        public TestEmpty Empty { get; set; }

        public void OnGet()
        {
            //this.context.TestEmpty.Add(Empty);
        }
    }
}