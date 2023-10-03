using ECommerce.App.Helper;
using ECommerce.App.Models;
using ECommerce.App.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IDbHelper _dbHelper;

        public AccountController(IAuthService authService,IDbHelper dbHelper) 
        {
            _authService = authService;
            _dbHelper = dbHelper;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            //var states=_dbHelper.GetStates();
            ViewBag.States=_dbHelper.GetStates();
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AuthenticateUser([FromBody]AuthenticateUser user)
        {
            bool isUserAuthenticated = _authService.AuthenticateUser(user.Email, user.Password);
            if (isUserAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
                //return Unauthorized("It seem's user is not authorized!!!");
            }
            return View();
        }
    }
}
