using ECommerce.App.Models;

namespace ECommerce.App.Service
{
    public interface IProductService
    {
        public ProductViewModel GetProductByID(int id);
    }
}
