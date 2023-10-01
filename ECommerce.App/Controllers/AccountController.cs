using ECommerce.App.Models;
using ECommerce.App.Service;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService) 
        {
            _authService = authService;
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
        public IActionResult AuthenticateUser(AuthenticateUser user)
        {
            bool isUserAuthenticated = _authService.AuthenticateUser(user.Email, user.Password);
            if (isUserAuthenticated)
            {
                return View();
            }
            else
            {
                return View("Unauthorized");
            }
            return View();
        }
    }
}
