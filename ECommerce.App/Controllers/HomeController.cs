//using e_commerce.Models;
using ECommerce.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace e_commerce.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Signin()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Authenticate(AuthenticateUser authenticateUser)
        {
            ViewBag.Users = "GoodMorning";
            return View(authenticateUser);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}