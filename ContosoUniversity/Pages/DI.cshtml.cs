using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models.Injection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoUniversity.Pages
{
    public class DIModel : PageModel
    {
        private readonly IMyDependency myDependency;

        public DIModel(IMyDependency myDependency)
        {
            this.myDependency = myDependency;
        }

        public async Task OnGetAsync()
        {
            //ViewData["Message"] = 


            ViewData["Message"] = await myDependency.WriteMessage(
                "IndexModel.OnGetAsync created this message.");
        }
    }
}