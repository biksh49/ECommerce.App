using GearVentures.Models;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text;
using Org.BouncyCastle.Crypto.EC;
using Org.BouncyCastle.Asn1.X509;

namespace GearVentures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Shop(int? page)
        {
            const int pageSize = 6;

            IQueryable<ProductRecordViewModel> products = _context.Products;

            if (TempData.ContainsKey("SearchQuery"))
            {
                var searchQuery = TempData["SearchQuery"].ToString();
                var allProducts = _context.Products.ToList();
                products = products.Where(p => p.Name.Contains(searchQuery));
                TempData.Remove("SearchQuery");
            }

            var paginatedProducts = PaginatedList<ProductRecordViewModel>.Create(products.AsQueryable(), page ?? 1, pageSize);

            return View(paginatedProducts);
        }


        [HttpGet]
        public IActionResult Search(string searchQuery)
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                TempData["SearchQuery"] = searchQuery;
                return RedirectToAction("Shop");
            }
            var allProducts = _context.Products.ToList();
            return View("Shop", PaginatedList<ProductRecordViewModel>.Create(allProducts.AsQueryable(), 1, 6));
        }

        [HttpPost]
        public IActionResult AddToCart(string productName, string price, string photoUrl)
        {
            var cartItem = new CartItem
            {
                ProductName = productName,
                Price = price,
                PhotoUrl = photoUrl
            };

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();

            return RedirectToAction("Shop");
        }


        public IActionResult ViewCart()
        {
            var cartItems = _context.CartItems.ToList();
            var cartViewModel = new CartViewModel 
            { 
                CartItems = cartItems 
            };
            return PartialView("_CartPartial", cartViewModel);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int cartItemId)
        {
            var cartItemToRemove = _context.CartItems.Find(cartItemId);

            if (cartItemToRemove != null)
            {
                _context.CartItems.Remove(cartItemToRemove);
                _context.SaveChanges();
            }

            return RedirectToAction("Shop");
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var initialmodel = new OrderModel
            {
                OrderId = 1,
                Name = "Default Name",
                Email = "abc@gmail.com",
                Number = "12345678",
                Address = "Kathmandu Nepal",
                Notes = "Hello hi"
            };

            var cartItems = _context.CartItems.ToList();
            var cartViewModel = new OrderModel
            {
                CartItems = cartItems
            };

            return View("Checkout", cartViewModel);
        }

        [HttpPost]
        public IActionResult Checkout(OrderModel order)
        {
                OrderModel neworder = new OrderModel
                {
                    OrderId = order.OrderId,
                    Name = order.Name,
                    Email = order.Email,
                    Number = order.Number,
                    Address = order.Address,
                    Notes = order.Notes
                };

                _context.Details.Add(neworder);
                _context.SaveChanges();

                ClearCart();
                TempData["SuccessMessage"] = "Order placed successfully!";
                return View("Checkout", order);

        }

        private void ClearCart()
        {
            var cartItems = _context.CartItems.ToList();
            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

    }
}

