using ECommerce.App.Helper;
using ECommerce.App.Models;
using ECommerce.App.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using log4net;

namespace ECommerce.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IDbHelper _dbHelper;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly ILog _logger;

        public AccountController(IAuthService authService,IDbHelper dbHelper,IUserService userService,IMailService mailService,ILog logger) 
        {
            _authService = authService;
            _dbHelper = dbHelper;
            _userService = userService;
            _mailService = mailService;
            _logger = logger;
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
        public IActionResult SignOut()
        {
           
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Index","Account");
           
        }

        [AllowAnonymous]
        
        [HttpPost]
        public IActionResult AuthenticateUser([FromBody]AuthenticateUser user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Please fill up the required field!");
                }
                var userDetails = _authService.AuthenticateUser(user.Email, user.Password);
                MailRequest mailRequest = new MailRequest();
                mailRequest.Subject = "Welcome to Ecommerce";
                mailRequest.Body = "You have reccently login in windows";
                mailRequest.ToEmail = "biksh49@gmail.com";
                _mailService.SendEmailAsync(mailRequest);


                if (userDetails != null)
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
            catch (Exception ex)
            {
                IDictionary<string,object> parameters= new Dictionary<string, object>();
                parameters.Add("email", user.Email);
                _logger.Error(ex.Message,ex);
                throw;
            }
           
           
            
        }
        [HttpPost]
        public void RegisterUser([FromBody]User user)
        {
            _userService.CreateUser(user);
            //var userDetails = _userService.GetUserByID(userID);

        }
        public List<District> GetDistrictByStateID([FromQuery]int stateID)
        {
            var districts = _dbHelper.GetDistrictByStateID(stateID);
            return districts.ToList();
        }
    }
}
