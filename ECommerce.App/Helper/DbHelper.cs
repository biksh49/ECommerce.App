using System;
using System.Data.SqlClient;
using Dapper;
using ECommerce.App.Models;

namespace ECommerce.App.Helper
{
	public class DbHelper
	{
		public List<User>GetAllUsers()
		{
            var sql = "select * from tblUsers";
            var users = new List<User>();
            using (var connection = new SqlConnection("server=root@localhost:3306; database=Ecommerce; Integrated Security=true;Password=root@1234"))
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //var product = new User
                        //{
                        //    ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                        //    ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                        //    SupplierId = reader.GetInt32(reader.GetOrdinal("SupplierId")),
                        //    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoryId")),
                        //    QuantityPerUnit = reader.GetString(reader.GetOrdinal("QuantityPerUnit")),
                        //    UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                        //    UnitsInStock = reader.GetInt16(reader.GetOrdinal("UnitsInStock")),
                        //    UnitsOnOrder = reader.GetInt16(reader.GetOrdinal("UnitsOnOrder")),
                        //    ReorderLevel = reader.GetInt16(reader.GetOrdinal("ReorderLevel")),
                        //    Discontinued = reader.GetBoolean(reader.GetOrdinal("Discontinued")),
                        //    DiscontinuedDate = reader.GetDateTime(reader.GetOrdinal("DiscontinuedDate"))
                        //};
                        //users.Add(product);
                        var usersRetrievedByDapper = connection.Query<User>(sql).ToList();
                        return usersRetrievedByDapper;
                    }
                }
            }
        }
	}
}

