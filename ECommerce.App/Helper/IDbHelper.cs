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
		//public User AuthenticateUser(string userEmail,string password);
	}
}

