using System;
using System.Data.SqlClient;
using Dapper;
using ECommerce.App.Models;
using ECommerce.App.Service;

namespace ECommerce.App.Helper
{
    public class DbHelper : IDbHelper
    {

         private readonly ConnectionStrings _dbContext;

            public DbHelper(ConnectionStrings dbContext)
            {
                _dbContext = dbContext;
            }

     

        public bool DeletetblUserByID(int userID)
        {
            bool isDeleted = false;
            var sql = $"select * from tblUser where userID={userID}";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
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
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                users = connection.Query<tblUser>(sql).ToList();
                return users;

            }
        }

        public tblUser GettblUserByID(int userID)
        {
            var sql = $"select * from tblUser where userID={userID}";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
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



        public IEnumerable<tblState> GettblStates()
        {
            var sql = "select * from tblState";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                var states = connection.Query<tblState>(sql);
                return states;

            }
        }

        List<tblUser> IDbHelper.GetAlltblUsers()
        {
            throw new NotImplementedException();
        }

        tblUser IDbHelper.UpdatetblUserByID(tblUser user)
        {
            throw new NotImplementedException();
        }

        bool IDbHelper.DeletetblUserByID(int userID)
        {
            throw new NotImplementedException();
        }

        tblUser IDbHelper.GettblUserByID(int userID)
        {
            throw new NotImplementedException();
        }

        bool IDbHelper.InsertUser(tblUser user)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tblState> IDbHelper.GetAlltblStates()
        {
            throw new NotImplementedException();
        }

        IEnumerable<tblDistrict> IDbHelper.GetAlltblDistricts()
        {
            throw new NotImplementedException();
        }

        IEnumerable<tblCity> IDbHelper.GetAlltblCities()
        {
            throw new NotImplementedException();
        }

        tblState IDbHelper.GettblStateById(int stateId)
        {
            throw new NotImplementedException();
        }

        tblDistrict IDbHelper.GettblDistrictById(int districtId)
        {
            throw new NotImplementedException();
        }

        tblCity IDbHelper.GettblCityById(int cityId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tblUser> IDbHelper.GettblUsersInState(int stateId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tblUser> IDbHelper.GetUserstblInDistrict(int districtId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<tblUser> IDbHelper.GetUserstblInCity(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
