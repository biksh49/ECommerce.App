using System;
using ECommerce.App.Models;

namespace ECommerce.App.Helper
{
	public interface IDbHelper
	{
		
		public IEnumerable<State> GetStates();
		public IEnumerable<District> GetDistricts();
        //public User AuthenticateUser(string userEmail,string password);
    }
}

