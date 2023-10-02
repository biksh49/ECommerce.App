using System;
using ECommerce.App.Models;

namespace ECommerce.App.Helper
{
    public interface IDbHelper
    {
        public List<tblUser> GetAlltblUsers();
        public tblUser UpdatetblUserByID(tblUser user);
        public bool DeletetblUserByID(int userID);
        public bool InsertUser(tblUser user);
        public tblUser GettblUserByID(int userID);
        //public User AuthenticateUser(string userEmail,string password);
    }
}
