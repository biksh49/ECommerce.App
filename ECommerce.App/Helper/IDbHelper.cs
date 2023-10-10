using System;
using ECommerce.App.Models;

namespace ECommerce.App.Helper
{
    public interface IDbHelper
    {
        public List<tblUser> GetAlltblUsers();


        // Update a user in the database by user ID
        public tblUser UpdatetblUserByID(tblUser user);
        public bool DeletetblUserByID(int userID);

       
        public tblUser GettblUserByID(int userID);


        // Create a new user in the database
        public bool InsertUser(tblUser user);

        // Additional methods for working with tblState, tblDistrict, and tblCity

        // Retrieve all states
        public IEnumerable<tblState> GetAlltblStates();

        // Retrieve all districts
        public IEnumerable<tblDistrict> GetAlltblDistricts();

        // Retrieve all cities
        public IEnumerable<tblCity> GetAlltblCities();

        // Retrieve a state by ID
        public tblState GettblStateById(int stateId);

        // Retrieve a district by ID
        public tblDistrict GettblDistrictById(int districtId);

        // Retrieve a city by ID
        public tblCity GettblCityById(int cityId);

        // Additional methods for specific queries or operations

        // Example: Retrieve all users in a specific state
        public IEnumerable<tblUser> GettblUsersInState(int stateId);

        // Example: Retrieve all users in a specific district
        public IEnumerable<tblUser> GetUserstblInDistrict(int districtId);

        // Example: Retrieve all users in a specific city
        public IEnumerable<tblUser> GetUserstblInCity(int cityId);
    }
    
}
