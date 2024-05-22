using Final_Api_Project.DAL.Data.Context;
using Final_Api_Project.DAL.Data.Models.Authorization;
using Final_Api_Project.DAL.Data.Models.Carts;
using Final_Api_Project.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Final_Api_Project.DAL.Repositories.Carts
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(E_CommerceContext context) : base(context)
        {
        }

        public void AddCart (Cart cart)
        {
             _context.Carts.Add(cart);
            _context.SaveChanges();
        }
        public void ClearCart(int cartId)
        {
            var cartItems = _context.CartItems.Where(ci => ci.CartId == cartId);
            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public Cart? GetCartByUserId(int userId)
        {
            return _context.Carts
                      .Include(c => c.User)
                      .Include(c => c.CartItems)
                      .ThenInclude(ci => ci.Product)
                      .FirstOrDefault(c => c.UserId == userId);

        }

        public List<CartItem> GetCartItems(int cartId)
        {
            return _context.CartItems
                           .Include(ci => ci.Product)
                           .Where(ci => ci.CartId == cartId)
                           .ToList();
        }

        public Cart GetCartById(int cartId)
        {
            return _context.Carts
                       .Include(c => c.CartItems)
                       .ThenInclude(ci => ci.Product)
                       .FirstOrDefault(c => c.Id == cartId);
        }

    }
}
