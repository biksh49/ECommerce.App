using System;
using System.Data.SqlClient;
using Dapper;
using ECommerce.App.Models;

namespace ECommerce.App.Helper
{
    public class DbHelper : IDbHelper
    {
        private readonly ConnectionStrings _dbContext;

        public DbHelper(ConnectionStrings dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<State> GetStates()
        {
            var sql = "select * from tblState";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                var states = connection.Query<State>(sql);
                return states;

            }

        }
        public IEnumerable<District> GetDistricts()
        {
            var sql = "select * from tblDistrict";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                var districts = connection.Query<District>(sql);
                return districts;

            }

        }
        public IEnumerable<City> GetCities()
        {
            var sql = "select * from tblCity";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                var cities = connection.Query<City>(sql);
                return cities;

            }
        }

        public IEnumerable<District> GetDistrictByStateID(int StateID)
        {
            var sql = $"select * from tblDistrict where StateID={StateID}";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                var districts = connection.Query<District>(sql);
                return districts;

            }
        }
        public IEnumerable<City> GetCityByDistricID(int DistrictID)
        {

            var sql = $"select * from tblCity where DistrictID={DistrictID}";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                var cities = connection.Query<City>(sql);
                return cities;

            }
        }

    }
}