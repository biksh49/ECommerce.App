using System;
using ECommerce.App.Models;
using System.Data.SqlClient;
using Dapper;



namespace ECommerce.App.Service
{
    public class AuthService : IAuthService
    {
        private readonly ConnectionStrings _dbContext;

        public AuthService(ConnectionStrings dbContext)
        {
            _dbContext = dbContext;
        }


        public bool AuthenticateUser(string email, string password)
        {
            bool isUserAuthenticated = false;
            var sql = $"select * from tblUser where Email='{email}' And  password='{password}'";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                var user = connection.QueryFirstOrDefault<User>(sql);
                isUserAuthenticated = user != null ? true : false;

            }
            return isUserAuthenticated;

        }
    }
}