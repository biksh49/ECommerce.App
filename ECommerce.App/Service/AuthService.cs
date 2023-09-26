using System;
using ECommerce.App.Models;
using System.Data.SqlClient;
using Dapper;
using MySqlConnector;

namespace ECommerce.App.Service
{
	public class AuthService:IAuthService
	{
		public AuthService()
		{
		}

        public bool AuthenticateUser(string email, string password)
        {
            bool isUserAuthenticated = false;
            var sql = $"select * from tblUsers where Email={email} and password={password}";
            using (var connection = new MySqlConnection("server=root@localhost:3306;database=Ecommerce;Password=root@1234"))
            {
                var user = connection.QueryFirstOrDefault<User>(sql);
                isUserAuthenticated = user != null ? true : false;

            }
            return isUserAuthenticated;
            
        }
    }
}

