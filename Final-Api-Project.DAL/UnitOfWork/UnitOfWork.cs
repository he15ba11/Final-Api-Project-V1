using Final_Api_Project.DAL.Data.Context;
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
    public class UnitOfWork: IUnitOfWork
    {
        private readonly E_CommerceContext _context;


        public ICartRepository CartRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IUserRepository UserRepository { get; }
        public IAuthenticationRepository AuthenticationRepository {  get; }

        public UnitOfWork(ICartRepository cartRepository,
            ICartItemRepository cartItemRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            ICategoryRepository categoryRepository,
            IAuthenticationRepository authenticationRepository,
            IUserRepository userRepository,
            E_CommerceContext context)
        {
            CartRepository = cartRepository;
            CartItemRepository = cartItemRepository;
            ProductRepository = productRepository;
            OrderRepository = orderRepository;
            CategoryRepository =categoryRepository;
            UserRepository = userRepository;
            AuthenticationRepository = authenticationRepository;
            _context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
