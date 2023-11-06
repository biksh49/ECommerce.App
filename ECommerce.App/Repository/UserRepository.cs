using Dapper;
using ECommerce.App.Models;
using System.Data.SqlClient;

namespace ECommerce.App.Repository
{
    public class UserRepository : IUserRepository
    {



        public List<User> GetAllUsers()
        {
            try
            {
                var sql = "select * from tblUsers";
                var users = new List<User>();
                using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
                {
                    users = connection.Query<User>(sql).ToList();
                    return users;

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public User GetUserByID(int userID)
        {
            var sql = $"select * from tblUsers where userID={userID}";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                var user = connection.QueryFirstOrDefault<User>(sql);
                return user;

            }
        }

        public void RegisterUser(User user)
        {
            // sequence of datashould be maintaince in this formate of   SQL Qurery//
            var sql = $"Insert into tblUser values ('{user.Name}',{user.Age},'{user.Email}',{user.ContactNumber},'{user.PostCode}','{user.Password}','{user.StateID}','{user.DistrictID}','{user.CityID}')";
            using (var connection = new SqlConnection(ECommerce.App.Helper.Constant.ConnectionString_MSSQL))
            {
                connection.Execute(sql);


            }
        }
      


        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}