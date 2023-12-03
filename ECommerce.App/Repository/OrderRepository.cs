using Dapper;
using ECommerce.App.Models;
using Newtonsoft.Json.Linq;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace ECommerce.App.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(int productID, int deliveryAddressID, DateTime estimatedDeliveryDate)
        {
            try
            {
                //DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("id", 1);
                IDictionary<string,object> parameters = new Dictionary<string, object>();
                parameters.Add("@sku", productID);
                parameters.Add("@deliveryAddressID", deliveryAddressID);
                parameters.Add("@EstimatedDelivery", estimatedDeliveryDate);
                Order order = new Order();
              
                using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
                {
                    var isSuccess=connection.Query("spForAddOrder",parameters, commandType: CommandType.StoredProcedure).ToList();
                    

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
