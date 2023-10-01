using ECommerce.App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.IO;
using ECommerce.App.Helper;
using ECommerce.App.Service;

namespace ECommerce.App.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly IDbHelper _dbHelper;
        private readonly IAuthService _authService;

        public HomeController(ILogger<HomeController> logger, IDbHelper dbHelper, IAuthService authService)
        {
            _logger = logger;
            _dbHelper = dbHelper;
            _authService = authService;
        }


        public IActionResult Index()
        {
            return View();
        }

       
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}