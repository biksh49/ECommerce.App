using ECommerce.App.Service;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.App.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult PlaceOrder(int productID,int deliveryAddressID,DateTime EstimatedDelivery)
        {
            _orderService.PlaceOrder(productID,deliveryAddressID, EstimatedDelivery);
            return View();
        }
    }
}
