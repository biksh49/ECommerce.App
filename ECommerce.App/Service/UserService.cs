using Dapper;
using ECommerce.App.Models;
using ECommerce.App.Repository;
using System.Data.SqlClient;
using System.Security.Principal;

namespace ECommerce.App.Service
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        private readonly IUserRepository _userRepository;

        public  void CreateUser(User user)
        {
            
           _userRepository.RegisterUser(user);

        }

        public User GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<DeliveryAddress> GetUserDelieveryAddressByID(int userID)
        {
            var deliveryAddress=_userRepository.GetDeliveryAddressByID(userID);
            return deliveryAddress;
        }
    }
}
