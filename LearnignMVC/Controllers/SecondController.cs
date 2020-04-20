using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LearnignMVC.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}