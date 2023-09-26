using Dapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using System.Configuration.Provider;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace ECommerce.Helper
{
    public class DBHelper
    {
        public List<SiteUser> GetAllUsers()
        {
            var sql = "Select * from SiteUser";
            var user = new List<SiteUser>();
            using (var connection = new SqlConnection("server=DESKTOP-NVVGDT1;database=Ecommerce;Integrated Security=true;user id=sushang;password=system@123"))

            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    var userRetrievedByDapper = connection.Query<SiteUser>(sql).ToList();
                    return userRetrievedByDapper;
                }
            }

        }
        //public SiteUser CreateUser()
        //{
        //    var sql = "Insert into SiteUser";
        //    var user = new List<SiteUser>();
        //    using(var connection = new SqlConnection("Server=DESKTOP-NVVGDT1;database=Ecommerce;Integrated Security=true;user id=sushang;password=system@123"))
        //    {
        //        connection.Open();
        //        using(var command = new SqlCommand(sql, connection))
        //        {
        //            var userRetrivedByDapper=connection.Query<SiteUser>(sql).ToList();
        //            return userRetrivedByDapper;
        //        }
        //    }
        //}
    }
}
