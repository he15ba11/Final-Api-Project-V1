using Final_Api_Project.DAL.Data.Models.Carts;
using Final_Api_Project.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;

namespace Final_Api_Project.DAL.Repositories.Carts
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
       public void AddCart (Cart cart);
       public void ClearCart(int cartId);
        public List<CartItem> GetCartItems(int cartId);
       public Cart GetCartByUserId(int userId);
       public Cart GetCartById(int cartId);
    }
}
