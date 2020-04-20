using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ContosoUniversity.Pages.Students
{
    public class TestGetModel : PageModel
    {
        private readonly IConfiguration configRoot;

        public TestGetModel(IConfiguration configRoot)
        {
            this.configRoot = configRoot;
        }

        public void OnGet()
        {
            ViewData["Config"] = configRoot.GetConnectionString("SchoolContext");
        }
    }
}