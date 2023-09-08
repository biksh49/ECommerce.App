using ECommerce.App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

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
        public IActionResult Authenticate([FromBody]AuthenticateUser authenticateUser)
        {
            //StreamWriter sw = new StreamWriter("users.json");
            //string students = string.Empty;
            //students = "kshitiz";
            //students += "anuj";
            //sw.WriteLine("Hi Everyone!!!");
            //sw.Close();

            //StreamReader sr = new StreamReader("user.json");
            //string line=sr.ReadLine();
            //string lines = sr.ReadToEnd();
            //sr.Close();


            string json = @"{
                                'userName': 'h@gmail.com',
                                'password': 'dsahufdhsf',
                           }";

           
            AuthenticateUser databaseUser= JsonConvert.DeserializeObject<AuthenticateUser>(json);
            if(databaseUser.UserName==authenticateUser.UserName && databaseUser.Password == authenticateUser.Password)
            {
                return View(authenticateUser);
            }
            else
            {
                return View ("~/Views/Home/Unauthorized.cshtml");
            }

          
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}