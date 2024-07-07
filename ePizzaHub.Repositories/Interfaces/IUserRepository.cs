using ePizzaHub.core.Entities;
using ePizzaHub.Model;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        bool CreateUser(User user, String Roll);
        UserModel ValidateUser(string email, string passowrd);
    }
}
