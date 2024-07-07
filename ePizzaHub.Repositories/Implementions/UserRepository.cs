using ePizzaHub.core;
using ePizzaHub.core.Entities;
using ePizzaHub.Model;
using ePizzaHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ePizzaHub.Repositories.Implementions
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        protected readonly AppDbContext _db;
        public UserRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public bool CreateUser(User user, string Role)
        {
            try
            {
                Role role = _db.Roles.FirstOrDefault(r => r.Name == Role);
                if (role != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                    user.Roles.Add(role);
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            return false;
        }


        public UserModel ValidateUser(string email, string passowrd)
        {
            User user = _db.Users.Include(r => r.Roles).Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                bool isValid = BCrypt.Net.BCrypt.Verify(passowrd, user.Password);
                if (isValid)
                {
                    UserModel userModel = new UserModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = email,
                        PhoneNumber = user.PhoneNumber,
                        Roles = user.Roles.Select(r => r.Name).ToArray()
                    };

                    return userModel;

                }
            } return null;
        }



        
    }
}
