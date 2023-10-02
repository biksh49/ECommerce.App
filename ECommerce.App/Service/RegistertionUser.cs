using Dapper;
using ECommerce.App.Models;
using System;
using System.Data.SqlClient;

namespace ECommerce.App.Service
{
    public class RegistrationUser : IUserService
    {
        public bool RegisterUser(string Name, string Address, string Email, string Password, int? ContactNumber, int? Age, string DOB)
        {
            // Implement user registration logic here
            // For example, you can insert the user data into the database
            // Make sure to validate and hash the password before storing it in the database

            using (var connection = new SqlConnection("Server=desktop-33ojo2e\\sqlexpress;Database=dbECommerce;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True"))
            {
                try
                {
                    // Insert user data into the database
                    string insertSql = @"
                        INSERT INTO tblUser (Name, Address, Email, Password, ContactNumber, Age, DOB)
                        VALUES (@Name, @Address, @Email, @Password, @ContactNumber, @Age, @DOB)";

                    var parameters = new
                    {
                        Name,
                        Address,
                        Email,
                        Password,
                        ContactNumber,
                        Age,
                        DOB
                    };
                    connection.Execute(insertSql, parameters);
                    return true; // Registration successful
                }
                catch (Exception)
                {
                    // Handle any exceptions (e.g., database errors) and return false
                    return false; // Registration failed
                }
            }
        }

        public bool RegisterUser(tblUser newUser)
        {
            throw new NotImplementedException();
        }
    }
}
