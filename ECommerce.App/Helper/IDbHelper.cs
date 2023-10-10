using System;
using ECommerce.App.Models;

namespace ECommerce.App.Helper
{
    public interface IDbHelper
    {

        public List<User> GetAllUsers();
        public User UpdateUserByID(User user);
        public bool DeleteUserByID(int userID);
        public User GetUserByID(int userID);
        public IEnumerable<State> GetStates();
        public IEnumerable<District> GetDistricts();
        public IEnumerable<City> GetCities();

        //// Additional methods for working with tblState, tblDistrict, and tblCity

        //// Retrieve all states
        //public IEnumerable<State> GetAllStates();

        //// Retrieve all districts
        //public IEnumerable<District> GetAllDistricts();

        //// Retrieve all cities
        //public IEnumerable<City> GetAllCities();


    }
    
}
