using ePizzaHub.core;
using ePizzaHub.core.Entities;
using ePizzaHub.Repositories.Implementions;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Implemention;
using ePizzaHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePizzaHub.Services
{
    public static class ConfigureDependencies
    {
        public static void RegisterService(IServiceCollection services, IConfiguration configuration)
        {
            //Db Dependency
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

        // Repositories         
            services.AddScoped<IRepository<Item>, Repository<Item>>();
            services.AddScoped<IUserRepository, UserRepository>();

            // services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IItemService, ItemService>();

        }


    }
}
