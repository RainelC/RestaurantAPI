using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantAPI.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Application.Mappings;
using RestaurantAPI.Core.Application.Services;
using RestaurantAPI.Infrastructure.Persistence.Repositories;

namespace RestaurantAPI.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration config)
        {

            if (config.GetValue<bool>("UseDatabaseinMemory"))
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                services.AddDbContext<AppDbContext>(opt =>
                                    opt.UseInMemoryDatabase("AppDb"));
            }
            else
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                services.AddDbContext<AppDbContext>(opt =>
                                    opt.UseSqlServer(connectionString,
                                    m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                                    ));
            }

            // AutoMapper
            //services.AddAutoMapper(typeof(GeneralProfile));

            // Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IDishRepository, DishRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ITableRepository, TableRepository>();

            // Services
        }
    }
}
