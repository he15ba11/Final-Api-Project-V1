using Final_Api_Project.DAL.Repositories.Authentication;
using Final_Api_Project.DAL.Repositories.CartItems;
using Final_Api_Project.DAL.Repositories.Carts;
using Final_Api_Project.DAL.Repositories.Categories;
using Final_Api_Project.DAL.Repositories.Orders;
using Final_Api_Project.DAL.Repositories.Products;
using Final_Api_Project.DAL.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL
{
    public interface IUnitOfWork
    {
        public ICartRepository CartRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IUserRepository UserRepository { get; }
        public IAuthenticationRepository AuthenticationRepository { get; }
        void SaveChanges();
    }
}
