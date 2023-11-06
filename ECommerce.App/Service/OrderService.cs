using ECommerce.App.Repository;

namespace ECommerce.App.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void PlaceOrder(int productID, int deliveryAddressID, DateTime EstimatedDelivery)
        {
            _orderRepository.AddOrder(productID,deliveryAddressID, EstimatedDelivery);
        }
    }
}
