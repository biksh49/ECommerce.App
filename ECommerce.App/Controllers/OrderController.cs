using Microsoft.AspNetCore.Mvc;

namespace ECommerce.App.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult PlaceOrder(int productID,int deliveryAddressID,DateTime EstimatedDelivery)
        {
            return View();
        }
    }
}
