namespace ECommerce.App.Service
{
    public interface IOrderService
    {
        public void PlaceOrder(int productID, int deliveryAddressID, DateTime EstimatedDelivery);
    }
}
