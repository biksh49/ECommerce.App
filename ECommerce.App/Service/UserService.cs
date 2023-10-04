using Dapper;
using ECommerce.App.Models;
using System.Data.SqlClient;

namespace ECommerce.App.Service
{
    public class UserService : IUserService
    {
        public  void CreateUser(User user)
        {
            var sql = $"Insert into tblUser values ('{user.Name}',{user.Age},'{user.Email}',{user.ContactNumber},'{user.Address}',{user.Password})";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                connection.Execute(sql);
               

            }
        }

        public User GetUserByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
