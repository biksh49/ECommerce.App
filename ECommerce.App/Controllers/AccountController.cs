
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


    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbHelper _dbHelper;
        private readonly IAuthService _authService;
        public AccountController(ILogger<HomeController> logger, IDbHelper dbHelper, IAuthService authService)
        {
            _logger = logger;
            _dbHelper = dbHelper;
            _authService = authService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Authenticate([FromForm] AuthenticateUser authenticateUser)
        {

            bool isUserAuthenticated = _authService.AuthenticateUser(authenticateUser.UserName, authenticateUser.Password);
            if (isUserAuthenticated)
            {
                return View();
            }
            else
            {
                return View("Unauthorized");
            }

        }
    }
       
    
}
