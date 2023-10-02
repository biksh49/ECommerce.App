
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
        
        private readonly IUserService _userService;
        public AccountController(ILogger<HomeController> logger, IDbHelper dbHelper, IAuthService authService, IUserService userService)
        {
            _logger = logger;
            _dbHelper = dbHelper;
            _authService = authService;
            _userService = userService;
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
        [HttpPost]
        public IActionResult SignUp(RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {
                var newUser = new tblUser
                {
                    Name = registerUser.Name,
                    Address = registerUser.Address,
                    Email = registerUser.Email,
                    Password = registerUser.Password,
                    ContactNumber = registerUser.ContactNumber,
                    Age = registerUser.Age,
                    DOB = registerUser.DOB
                };

                bool isRegistered = _userService.RegisterUser(newUser);

                if (isRegistered)
                {
                    // Redirect to a success page, login page, or other appropriate action
                    return RedirectToAction("SignIn");
                }
                else
                {
                    // Handle the case where registration failed (e.g., display an error message)
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                }
            }

            // If the model state is not valid, return to the sign-up view with validation errors
            return View(registerUser);
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
                return View(authenticateUser);
            }
            else
            {
                return View("Unauthorized");
            }

        }
       

    }
       
    
}
