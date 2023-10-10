using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.IO;
using ECommerce.App.Helper;
using ECommerce.App.Service;
using ECommerce.App.Models;

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
            //  ViewBag.States = _dbHelper.GetStates();
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

        public IActionResult Authenticate([FromForm] AuthenticateUser user)
        {

            var userDetails = _authService.AuthenticateUser(user.UserName, user.Password);
            if (userDetails)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //return RedirectToAction("Index", "Home");
                return PartialView("UnAuthorized");
            }

        }
        // GET: /Account/Register
        //public IActionResult Register()
        //{
        //    var viewModel = new SignUpViewModel();
        //    // You can populate dropdown lists or other properties of viewModel if needed.
        //    return View(viewModel);
        //}


        // POST: /Account/Register
        //[HttpPost]        
        //public IActionResult Register([FromBody] SignUpViewModel user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Map the SignUpViewModel to a tblUser object
        //            var tblUser = new tblUser
        //            {
        //                Name = user.Name,
        //                Age = user.Age,
        //                Email = user.Email,
        //                ContactNumber = user.ContactNumber,
        //                PostCode = user.Postcode,
        //                Password = user.Password,
        //                StateID = user.SelectedStateID,
        //                DistrictID = user.SelectedDistrictID,
        //                CityID = user.SelectedCityID
        //            };

        //            // Call the UserService to create the user
        //            _userService.CreateUser(tblUser);

        //            // Redirect to a success page or login page
        //            return RedirectToAction("Login", "Account");
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log the exception or handle it as needed
        //            ModelState.AddModelError(string.Empty, "An error occurred while registering. Please try again later.");
        //        }
        //    }

        //    // If ModelState is not valid, return the registration form with validation errors
        //    return View(user);

        //}


        [HttpPost]
        public void RegisterUser([FromBody] tblUser user)
        {
            _userService.CreateUser(user);
            //var userDetails = _userService.GetUserByID(userID);

        }



    }
}
