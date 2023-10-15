using ECommerce.App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.IO;
using ECommerce.App.Helper;
using ECommerce.App.Service;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ConnectionStrings _dbContexts;
        private readonly ILogger<HomeController> _logger;
        private readonly IDbHelper _dbHelper;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly ConnectionStrings _dbContext;
        private readonly ConnectionStrings _conn;

        public HomeController(ConnectionStrings dbContexts, ILogger<HomeController> logger, IDbHelper dbHelper, IAuthService authService, IConfiguration configuration, IOptions<ConnectionStrings> dbContext, ConnectionStrings conn)
        {
            _dbContexts = dbContexts;
            _logger = logger;
            _dbHelper = dbHelper;
            _authService = authService;
            _configuration = configuration;
            _dbContext = dbContext.Value;
            _conn = conn;
        }

        public IActionResult Index()
        {
            return View();
        }

       
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}