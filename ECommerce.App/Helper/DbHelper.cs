using System;
using System.Data.SqlClient;
using Dapper;
using ECommerce.App.Models;

namespace ECommerce.App.Helper
{
	public class DbHelper:IDbHelper
    {
        

        public bool DeleteUserByID(int userID)
        {
            bool isDeleted = false;
            var sql = $"select * from tblUsers where userID={userID}";
            using (var connection = new SqlConnection("server=root@localhost:3306; database=Ecommerce; Integrated Security=true;Password=root@1234"))
            {
                var user = connection.QueryFirstOrDefault<User>(sql);
                isDeleted = user != null ? true : false;

                return isDeleted;

            }
        }

        public List<User>GetAllUsers()
		{
            var sql = "select * from tblUsers";
            var users = new List<User>();
            using (var connection = new SqlConnection("server=root@localhost:3306; database=Ecommerce; Integrated Security=true;Password=root@1234"))
            {
                users = connection.Query<User>(sql).ToList();
                return users;
               
            }
        }

        public User GetUserByID(int userID)
        {
            var sql = $"select * from tblUsers where userID={userID}";
            using (var connection = new SqlConnection("server=root@localhost:3306; database=Ecommerce; Integrated Security=true;Password=root@1234"))
            {
                var user = connection.QueryFirstOrDefault<User>(sql);
                return user;

            }
        }

        public User UpdateUserByID(User user)
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

