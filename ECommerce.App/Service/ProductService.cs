using ECommerce.App.Models;
using Newtonsoft.Json;

namespace ECommerce.App.Service
{
    public class ProductService : IProductService
    {
        public ProductViewModel GetProductByID(int id)
        {
			try
			{
                StreamReader sr = new StreamReader("products.json");
                string products = sr.ReadToEnd();
                sr.Close();
                List<ProductViewModel> listOfProducts = JsonConvert.DeserializeObject<List<ProductViewModel>>(products);
                var product = listOfProducts.ToList().Where(x => x.Sku == id).FirstOrDefault();
                return product;

            }
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
