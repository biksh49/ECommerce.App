using GearVentures.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GearVentures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() 
        { 
            return View();
        }

        public IActionResult Shop() 
        { 
            return View();
        }

        public IActionResult Contact() 
        { 
            return View();
        }
    }
}