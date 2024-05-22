using Final_Api_Project.BL.Dtos.Carts;
using Final_Api_Project.DAL.Data.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Managers.Carts
{
    public interface ICartManager
    {
        public List<CartItemDetails> GetCartItems(int cartId);
        public CartDto GetCartByUserId(int userId);
        public void ClearCart(int cartId);
        public CartDto GetCartById(int cartId);
        public void AddCart (CartDto cartDto);

    }
}
