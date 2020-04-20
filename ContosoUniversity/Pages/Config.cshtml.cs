using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ContosoUniversity.Pages
{
    public class ConfigModel : PageModel
    {
        public PositionOptions positionOptions { get; private set; }
        private IConfiguration ConfigRoot;

        public ConfigModel(IConfiguration configRoot)
        {
            ConfigRoot = configRoot;         
        }

        //public ContentResult OnGet()
        //{
        //    string str = "";
        //    foreach (var provider in ConfigRoot.Providers.ToList())
        //    {
        //        str += provider.ToString() + "\n";
        //    }

        //    ViewData["Config"] = str;

        //    return Content(str);
        //}

        public void OnGet()
        {
            positionOptions = ConfigRoot.GetSection("Position").Get<PositionOptions>();


            ViewData["Config"] = positionOptions.Name + "              " + positionOptions.Title;

        }

    }

    public class PositionOptions
    {
        public string Title { get; set; }
        public string Name { get; set; }
    }
}