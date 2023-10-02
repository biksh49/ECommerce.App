using System;
using ECommerce.App.Models;
using System.Data.SqlClient;
using Dapper;



namespace ECommerce.App.Service
{
    public class AuthService : IAuthService
    {
        public AuthService()
        {
        }

        public bool AuthenticateUser(string email, string password)
        {
            bool isUserAuthenticated = false;
            var sql = $"select * from tblUser where Email='{email}' And  password='{password}'";
            using (var connection = new SqlConnection("Server=desktop-33ojo2e\\sqlexpress;Database=dbECommerce;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True"))
            {
                var user = connection.QueryFirstOrDefault<tblUser>(sql);
                isUserAuthenticated = user != null ? true : false;

            }
            return isUserAuthenticated;

        }
    }
}