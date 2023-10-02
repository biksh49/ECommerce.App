using ECommerce.App.Models;

namespace ECommerce.App.Service
{
    public interface IUserService
    {
        bool RegisterUser(string Name, string Address, string Email, string Password, int? ContactNumber, int? Age, string DOB);
        bool RegisterUser(tblUser newUser);
    }
}
