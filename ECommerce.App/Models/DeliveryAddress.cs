namespace ECommerce.App.Models
{
    public class DeliveryAddress
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string   MobileNumber { get; set; }
        public string LandMark { get; set; }
        public string StateName { get; set; }
        public string City { get; set; }
        public bool DeliveryOption { get; set; }
        public bool IsDefaultAddress { get; set; }
        public bool IsDefaultBillingAddress { get; set; }
        public int UserID { get; set; }
    }
}
