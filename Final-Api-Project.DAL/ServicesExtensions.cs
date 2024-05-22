using Final_Api_Project.DAL.Data.Context;
using Final_Api_Project.DAL.Repositories.Carts;
using Final_Api_Project.DAL.Repositories.Orders;
using Final_Api_Project.DAL.Repositories.Products;
using Final_Api_Project.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Final_Api_Project.DAL.Repositories.Authentication;
using Final_Api_Project.DAL.Repositories.CartItems;
using Final_Api_Project.DAL.Repositories.Categories;
using Final_Api_Project.DAL.Repositories.Users;

namespace Final_Api_Project.DAL
{
    public static class ServicesExtensions
    {
        public static void AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("E-commerce");
            services.AddDbContext<E_CommerceContext>(options =>
                options.UseSqlServer(connectionString));

            // Registering IUnitOfWork as Scoped to match its dependencies
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        }

    }
}
