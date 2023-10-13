using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.IO;
using ECommerce.App.Helper;
using ECommerce.App.Service;
using ECommerce.App.Models;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.App.Controllers
{


    public class AccountController : Controller
    {
       
       
        private readonly IAuthService _authService;
        private readonly IDbHelper _dbHelper;
        private readonly IUserService _userService;



        public AccountController(  IAuthService authService, IDbHelper dbHelper, IUserService userService)
        {
            _authService = authService;
            _dbHelper = dbHelper;
           
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
            SignUpViewModel signUpViewModel = new SignUpViewModel();

            var states = _dbHelper.GetStates();
            var districts = _dbHelper.GetDistricts();
            var cities = _dbHelper.GetCities();

            signUpViewModel.State = states;
            signUpViewModel.District = districts;
            signUpViewModel.City= cities;
            
            return View(signUpViewModel);
           
        }
      


        public IActionResult ForgetPassword()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromForm] AuthenticateUser user)
        {

            bool userDetails = _authService.AuthenticateUser(user.UserName, user.Password);
            if (userDetails)
            {
                return View(user);
            }
            else
            {
                return View("Unauthorized");
            }
            //this code is for   Authenticate or not in bool return and shows view page according to the suitation.


        }
        [HttpPost]
        public void RegisterUser([FromBody] User user)
        {
            _userService.CreateUser(user);
            //var userDetails = _userService.GetUserByID(userID);

        }


    }


}
