namespace ECommerce.App.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SKU { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int DeliveryAddressID { get; set; }
        public string EstimatedDelivery { get; set; }
        public int UserID { get; set; }
        public bool IsDelivered { get; set; }
    }
}
