using Final_Api_Project.DAL.Data.Models.Carts;
using Final_Api_Project.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.DAL.Repositories.CartItems
{
    public interface ICartItemRepository:IGenericRepository<CartItem>
    {
        public void AddCartItem(CartItem cartItem);
        public CartItem GetCartItemById(int cartItemId);
        public void RemoveItemFromCart(int cartItemId);
        public void UpdateCartItemQuantity(int cartItemId, int quantity);

    }
}
