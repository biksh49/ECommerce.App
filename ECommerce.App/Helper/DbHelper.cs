using System;
using System.Data.SqlClient;
using Dapper;
using ECommerce.App.Models;

namespace ECommerce.App.Helper
{
	public class DbHelper:IDbHelper
    {
        private readonly ConnectionStrings _dbContext;

        public DbHelper(ConnectionStrings dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<State> GetStates()
        {
            try
            {
                var sql = "select * from tblState";
                using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
                {
                    var states = connection.Query<State>(sql);
                    return states;

                }
            }
            catch (Exception ex)
            {

                throw;
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

        public IEnumerable<District> GetDistrictByStateID(int stateID)
        {
            var sql = $"select * from tblDistrict where stateID={stateID}";
            using (var connection = new SqlConnection(Helper.Constant.ConnectionString_MSSQL))
            {
                var districts = connection.Query<District>(sql);
                return districts;

            }
        }
    } 
}

