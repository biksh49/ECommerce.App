using System;
using ECommerce.App.Models;

namespace ECommerce.App.Helper
{
    public interface IDbHelper
    {
        //here operation is done for all Users to retrive the data from database
        public IEnumerable<State> GetStates();
        public IEnumerable<City> GetCities();
        public IEnumerable<District> GetDistricts();
        public IEnumerable<District> GetDistrictByStateID(int StateID);
        public IEnumerable<City> GetCityByDistricID(int DistrictID);



    }
    
}
