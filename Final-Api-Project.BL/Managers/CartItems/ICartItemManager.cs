using Final_Api_Project.BL.Dtos.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Managers.CartItems
{
    public interface ICartItemManager
    {
        void AddToCart(AddCartItemDto addCartItemDto);
        void RemoveFromCart(int cartItemId);
        void UpdateCartItemQuantity(int cartItemId, int quantity);
    }
}
