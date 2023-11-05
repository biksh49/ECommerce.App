namespace ECommerce.App.Models
{
    public class BuyViewModel
    {
        public ProductViewModel ProductViewModel { get; set; }
        public List<DeliveryAddress> DeliveryAddresses { get; set; }
    }
}
