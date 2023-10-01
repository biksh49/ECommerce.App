using System;
using System.Data.SqlClient;
using Dapper;
using ECommerce.App.Models;

namespace ECommerce.App.Helper
{
    public class DbHelper : IDbHelper
    {


        public bool DeletetblUserByID(int userID)
        {
            bool isDeleted = false;
            var sql = $"select * from tblUser where userID={userID}";
            using (var connection = new SqlConnection("Server=desktop-33ojo2e\\sqlexpress;Database=dbECommerce;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True"))
            {
                var user = connection.QueryFirstOrDefault<tblUser>(sql);
                isDeleted = user != null ? true : false;

                return isDeleted;

            }
        }

        public List<tblUser> GetAlltblUsers()
        {
            var sql = "select * from tblUser";
            var users = new List<tblUser>();
            using (var connection = new SqlConnection("Server=desktop-33ojo2e\\sqlexpress;Database=dbECommerce;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True"))
            {
                users = connection.Query<tblUser>(sql).ToList();
                return users;

            }
        }

        public tblUser GettblUserByID(int userID)
        {
            var sql = $"select * from tblUser where userID={userID}";
            using (var connection = new SqlConnection("Server=desktop-33ojo2e\\sqlexpress;Database=dbECommerce;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True"))
            {
                var user = connection.QueryFirstOrDefault<tblUser>(sql);
                return user;

            }
        }

        public tblUser UpdatetblUserByID(tblUser user)
        {
            return null;
            //var sql = $"select * from tblUsers where userID={userID}";
            //using (var connection = new SqlConnection("server=root@localhost:3306; database=Ecommerce; Integrated Security=true;Password=root@1234"))
            //{
            //    var user = connection.QueryFirstOrDefault<User>(sql);
            //    return user;

            //}
        }
    }
}
