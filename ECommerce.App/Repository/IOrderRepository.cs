namespace ECommerce.App.Repository
{
    public interface IOrderRepository
    {
        public void AddOrder(int productID, int deliveryAddressID, DateTime estimatedDeliveryDate); 
    }
}
