using Final_Api_Project.DAL.Repositories.Carts;
using Final_Api_Project.BL.Dtos.Carts;
using Final_Api_Project.DAL;
using System.Linq;
using Final_Api_Project.DAL.Data.Models.Carts;
using Final_Api_Project.BL.Dtos.Users;

namespace Final_Api_Project.BL.Managers.Carts
{
    public class CartManager : ICartManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public void ClearCart(int cartId)
        {
            _unitOfWork.CartRepository.ClearCart(cartId);
            _unitOfWork.SaveChanges();
        }

        public CartDto GetCartByUserId(int userId)
        {
            var cart = _unitOfWork.CartRepository.GetCartByUserId(userId);
            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                CreatedDate = cart.CreatedDate,
                CartItems = cart.CartItems.Select(ci => new CartItemDTO
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity,
                    Price = ci.Product.Price
                }).ToList()
            };
        }


        public List<CartItemDetails> GetCartItems(int cartId)
        {
            var cartItems = _unitOfWork.CartRepository.GetCartItems(cartId);

            var cartItemDetailsList = cartItems.Select(ci => new CartItemDetails
            {
                Id = ci.Id,
                CartId = ci.CartId,
                ProductId = ci.ProductId,
                UnitPrice = ci.UnitPrice,
                Quantity = ci.Quantity
            }).ToList();

            return cartItemDetailsList;
        }

        public CartDto GetCartById(int cartId)
        {
            var cart = _unitOfWork.CartRepository.GetCartById(cartId);
            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                CreatedDate = cart.CreatedDate,
                CartItems = cart.CartItems.Select(ci => new CartItemDTO
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity,
                    Price = ci.Product.Price
                }).ToList()
            };
        }

        public void AddCart(CartDto cartDto)
        {
            var cart = new Cart
            {
                UserId= cartDto.UserId,
                CreatedDate= DateTime.Now,
                CartItems= cartDto.CartItems.Select(ci => new CartItem
                {
                    ProductId = ci.ProductId,
                    UnitPrice = ci.Price,
                    Quantity = ci.Quantity
                }).ToList(),
               
            };

            _unitOfWork.CartRepository.AddCart(cart);
        }
    } 

 
    
}
