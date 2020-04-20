using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnignMVC.Controllers
{
    public class FirstController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int counter)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = counter;

            return View();
        }
    }
}
