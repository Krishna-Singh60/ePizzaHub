using ePizzaHub.core.Entities;
using ePizzaHub.Model;


namespace ePizzaHub.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        bool CreateUser(User user, string Role);
        UserModel ValidateUser (string email, string password);
    }
}
