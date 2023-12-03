namespace ECommerce.App.Models
{

    public class ProductViewModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal? Price { get; set; }
        public List<Category> Category { get; set; }
        public decimal? Shipping { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }

    }

}
