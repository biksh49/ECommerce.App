using Dapper;
using ECommerce.App.Helper;
using ECommerce.App.Models;
using System.Data.SqlClient;

public class UserService : IUserService
{
    public void CreateUser(User user)
    {
       
        
            var sql = $"Insert into tblUser values ('{user.Name}',{user.Age},'{user.Email}',null,'{user.PostCode}','{user.Password}','{user.StateID}''{user.DistrictID}''{user.CityID}')";
            using (var connection = new SqlConnection(ECommerce.App.Helper.Constant.ConnectionString_MSSQL))
            {
                connection.Execute(sql);


            }
        
    }

    public User GetUserByID(int id)
    {
        throw new NotImplementedException();
    }
}
