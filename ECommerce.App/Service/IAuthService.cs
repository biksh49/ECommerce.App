
using ECommerce.App.Models;
using System;

namespace ECommerce.App.Service
{
    public interface IAuthService
    {
        public bool AuthenticateUser(string email, string password);
    }
}
