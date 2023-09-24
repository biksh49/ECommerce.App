using ECommerce.App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ECommerce.App.Controllers
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
        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Authenticate([FromBody]AuthenticateUser authenticateuser)
        {
            //StreamWriter sw = new StreamWriter("user.json");
            //sw.WriteLine("Hi Everyone!!");
            //sw.Close();

            StreamReader sr = new StreamReader("User.json");
            string lines = sr.ReadToEnd();
            sr.Close();

            ViewBag.User = "GoodMorning";
            //string json = @"{
            //                     'Email':'dahalsujan643@gmail.com',
            //                     'Password' : 'qwerty123'
            //             }";
            List<AuthenticateUser> databaseUser = JsonConvert.DeserializeObject<List<AuthenticateUser>>(lines);
            foreach (AuthenticateUser user in databaseUser)
            {

                if (user.Email == authenticateuser.Email && user.Password == authenticateuser.Password)
                {
                    return View(authenticateuser);

                }
                else
                {
                    return View("~/Views/Home/Unauthorized.cshtml");
                }
               
            }
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}