using Final_Api_Project.BL.Managers.CartItems;
using Final_Api_Project.BL.Managers.Carts;
using Final_Api_Project.BL.Managers.Categories;
using Final_Api_Project.BL.Managers.Orders;
using Final_Api_Project.BL.Managers.Products;
using Final_Api_Project.BL.Managers.Users;
using Final_Api_Project.DAL.Repositories.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Final_Api_Project.BL
{
    public static class ServicesExtensions
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddScoped<ICartManager, CartManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICartItemManager, CartItemManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IUserManager, UserManager>();
           // services.AddScoped<IAuthenticationManager, Authenticationmanager>();
        }
    }
}
