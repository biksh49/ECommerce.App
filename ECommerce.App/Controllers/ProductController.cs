using ECommerce.App.Models;
using ECommerce.App.Service;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        public ProductController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }
        public IActionResult GetProductByID(int id)
        {
            try
            {
                var productDetails = _productService.GetProductByID(id);
                return PartialView(productDetails);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IActionResult BuyProductByID(int id)
        {
            BuyViewModel buyViewModel = new BuyViewModel();
            try
            {
                var productDetails = _productService.GetProductByID(id);
                var userID = ((System.Security.Claims.ClaimsIdentity)User.Identity)?.FindFirst("UserId")?.Value;

               
                var delieveryDetails = _userService.GetUserDelieveryAddressByID(int.Parse(userID));
                buyViewModel.DeliveryAddresses=delieveryDetails;
                buyViewModel.ProductViewModel = productDetails;
                return PartialView("ProductDetails", buyViewModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
