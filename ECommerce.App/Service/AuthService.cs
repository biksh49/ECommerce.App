using System;
using ECommerce.App.Models;
using System.Data.SqlClient;
using Dapper;
using MySqlConnector;
using System.Reflection.Metadata;
using ECommerce.App.Helper;

namespace ECommerce.App.Service
{
	public class AuthService:IAuthService
	{
        private readonly ConnectionStrings _dbContext;

        public AuthService(ConnectionStrings dbContext)
		{
            _dbContext = dbContext;
        }

        public bool AuthenticateUser(string email, string password)
        {
            bool isUserAuthenticated = false;
            var sql = $"select * from tblUsers where Email={email} and password={password}";
            using (var connection = new MySqlConnection(_dbContext.DefaultConnection))
            {
                var user = connection.QueryFirstOrDefault<User>(sql);
                isUserAuthenticated = user != null ? true : false;

            }
            return isUserAuthenticated;
            
        }
    }
}

