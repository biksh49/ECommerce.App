using ECommerce.App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.IO;
using ECommerce.App.Helper;

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
        [HttpPost]
        public IActionResult Authenticate([FromForm]AuthenticateUser authenticateUser)
        {
            //StreamWriter sw = new StreamWriter("users.json");
            //string students = string.Empty;
            //students = "kshitiz";
            //students += "anuj";
            //sw.WriteLine("Hi Everyone!!!");
            //sw.Close();

            StreamReader sr = new StreamReader("user.json");

            string lines = sr.ReadToEnd();
            sr.Close();



            //string json = @"{
            //                    'userName': 'h@gmail.com',
            //                    'password': 'dsahufdhsf',
            //               }";

            //// Specify the path to your JSON file
            //string filePath = "user.json";
            // using FileStream stream = File.OpenRead(filePath);
            //return await JsonSerializer.DeserializeAsync<T>(stream);
            //// Read the JSON file into a string
            //string jsonString =File.ReadAllText(filePath);
            //// Deserialize the JSON string into an object
            //List<AuthenticateUser> databaseUser = JsonSerializer.Deserialize<List<AuthenticateUser>>(jsonString);


            //List<AuthenticateUser> databaseUser= JsonConvert.DeserializeObject<List<AuthenticateUser>>(lines);

            // foreach (var user in databaseUser)
            // {
            //     if (user.UserName == authenticateUser.UserName && user.Password == authenticateUser.Password)
            //     {
            //         return View(authenticateUser);
            //     }
            //     else
            //     {
            //         return View("~/Views/Home/Unauthorized.cshtml");
            //     }
            // }

            DbHelper dbHelper = new DbHelper();
            var users=dbHelper.GetAllUsers();
           
            return View();
          
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}