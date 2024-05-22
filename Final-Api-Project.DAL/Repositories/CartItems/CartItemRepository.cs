using Final_Api_Project.DAL.Data.Context;
using Final_Api_Project.DAL.Data.Models.Carts;
using Final_Api_Project.DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Repositories.CartItems
{
    public class CartItemRepository: GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(E_CommerceContext context) : base(context)
        {
        }

        public void AddCartItem(CartItem cartItem)
        {
            var existingCartItem = _context.CartItems.FirstOrDefault(ci => ci.CartId == cartItem.CartId && ci.ProductId == cartItem.ProductId);
            if (existingCartItem != null)
            {
                // If the item already exists in the cart, update its quantity
                existingCartItem.Quantity += cartItem.Quantity;
            }
            else
            {
                // If the item doesn't exist in the cart, add it
                _context.CartItems.Add(cartItem);
            }

            // Save changes only once
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(int cartItemId)
        {
            var cartItem = _context.CartItems.Find(cartItemId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }
        }

        public void UpdateCartItemQuantity(int cartItemId, int quantity)
        {
            var cartItem = _context.CartItems.Find(cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                _context.SaveChanges();
            }
        }

        public CartItem GetCartItemById(int cartItemId)
        {
            return _context.CartItems.FirstOrDefault(c => c.Id == cartItemId);
        }
    }
}
