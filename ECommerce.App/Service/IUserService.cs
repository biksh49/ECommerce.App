using ECommerce.App.Models;

public interface IUserService
{
    public User GetUserByID(int id);
    public  void CreateUser(User user);



}
