using Final_Api_Project.BL.Dtos.Carts;
using Final_Api_Project.DAL.Data.Models.Carts;
using Final_Api_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Api_Project.BL.Managers.CartItems
{
    public class CartItemManager :ICartItemManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartItemManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddToCart(AddCartItemDto addCartItemDto)
        {
            var cartItem = _unitOfWork.CartItemRepository.GetCartItemById(addCartItemDto.Id);
            if (cartItem != null)
            {
                // If the item already exists in the cart, update its quantity
                cartItem.Quantity += addCartItemDto.Quantity;
            }
            else
            {
                // If the item doesn't exist in the cart, add it
                cartItem = new CartItem
                {
                   CartId= addCartItemDto.CartId,
                    ProductId = addCartItemDto.ProductId,
                    Quantity = addCartItemDto.Quantity,
                    UnitPrice= addCartItemDto.UnitPrice,
                };
                _unitOfWork.CartItemRepository.AddCartItem(cartItem);
            }
            _unitOfWork.SaveChanges();
        }
        public void RemoveFromCart(int cartItemId)
        {
            _unitOfWork.CartItemRepository.RemoveItemFromCart(cartItemId);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCartItemQuantity(int cartItemId, int quantity)
        {
            var cartItem = _unitOfWork.CartItemRepository.GetCartItemById(cartItemId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                _unitOfWork.SaveChanges();
            }
        }
    }
}
