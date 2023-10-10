namespace ECommerce.App.Models
{

    public class ProductViewModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public List<Category> Category { get; set; }
        public int Shipping { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }

    }

}
