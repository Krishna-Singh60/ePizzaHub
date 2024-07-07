using ePizzaHub.core.Entities;
using ePizzaHub.Model;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;


namespace ePizzaHub.Services.Implemention
{
    public class UserService : Service<User>, IUserService
    {
        IUserRepository _userRepo;
        public UserService(IUserRepository userRepo) :base(userRepo)
        {
            _userRepo = userRepo;
        }


        public bool CreateUser(User user, string Role)
        {
            return _userRepo.CreateUser(user, Role);
        }

        public UserModel ValidateUser(string email, string password)
        {
            return _userRepo.ValidateUser(email, password);
        }
    }
}
