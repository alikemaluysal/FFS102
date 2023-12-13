using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Data = "Ali Kemal";
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            Console.WriteLine(name);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
