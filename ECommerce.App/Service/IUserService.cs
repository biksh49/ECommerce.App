using ECommerce.App.Models;

namespace ECommerce.App.Service
{
    public interface IUserService
    {
        public User GetUserByID(int id);
        public void CreateUser(User user);
    }
}
