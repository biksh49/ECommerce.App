using Dapper;
using ECommerce.App.Helper;
using ECommerce.App.Models;
using ECommerce.App.Repository;
using System.Data.SqlClient;

public class UserService : IUserService
{
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    private readonly IUserRepository _userRepository;

    public void CreateUser(User user)
    {

        _userRepository.RegisterUser(user);

    }

    public User GetUserByID(int id)
    {
        throw new NotImplementedException();
    }
}
