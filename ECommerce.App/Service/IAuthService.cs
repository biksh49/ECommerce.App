
using ECommerce.App.Models;
using System;

namespace ECommerce.App.Service
{
    public interface IAuthService
    {
        public User AuthenticateUser(string email, string password);
    }
}
