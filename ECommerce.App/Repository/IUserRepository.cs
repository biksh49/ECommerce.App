using ECommerce.App.Models;

namespace ECommerce.App.Repository
{
    public interface IUserRepository
    {
        public User GetUserByID(int userID);
        public List<User> GetAllUsers();
        public User UpdateUser(User user);
        public void RegisterUser(User user);
    }
}
