using ECommerce.App.Helper;
using ECommerce.App.Models;
using ECommerce.App.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IDbHelper _dbHelper;
        private readonly IUserService _userService;

        public AccountController(IAuthService authService,IDbHelper dbHelper,IUserService userService) 
        {
            _authService = authService;
            _dbHelper = dbHelper;
            _userService = userService;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            SignUpViewModel signUpViewModel = new SignUpViewModel();
            
            var states=_dbHelper.GetStates();
            var districts=_dbHelper.GetDistricts();

            signUpViewModel.State =states;
            signUpViewModel.District =districts;
            //ViewBag.States=_dbHelper.GetStates();
            return View(signUpViewModel);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AuthenticateUser([FromBody]AuthenticateUser user)
        {
            if(!ModelState.IsValid)
            {

            }
            var userDetails = _authService.AuthenticateUser(user.Email, user.Password);
           
            if (userDetails!=null)
            {

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim("UserName",$"{userDetails.Name}"),
                    new Claim("UserId",$"{userDetails.ID}"),
                    new Claim("Email",$"{userDetails.Email}")

                };
                var id = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principles = new ClaimsPrincipal();
                principles.AddIdentity(id);
                HttpContext.SignInAsync("CookieAuthentication", principles, new AuthenticationProperties()
                {
                    ExpiresUtc = DateTime.UtcNow.AddHours(8),
                    IsPersistent = true,
                    AllowRefresh = false,
                });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //return RedirectToAction("Index", "Home");
                return PartialView("UnAuthorized");
            }
            
        }
        [HttpPost]
        public void RegisterUser([FromBody]User user)
        {
            _userService.CreateUser(user);
            //var userDetails = _userService.GetUserByID(userID);

        }
    }
}
