using Final_Api_Project.BL.Managers.Carts;
using Final_Api_Project.BL.Managers.Orders;
using Final_Api_Project.BL.Managers.Products;
using Final_Api_Project.BL.Dtos.Carts;
using Final_Api_Project.BL.Dtos.Orders;
using Final_Api_Project.BL.Dtos.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Final_Api_Project.DAL.Data.Models.Carts;

namespace Final_Api_Project.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartManager _cartManager;

        public CartsController(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }

        [HttpDelete("{cartId}")]
        public ActionResult ClearCart(int cartId)
        {
            _cartManager.ClearCart(cartId);
            return NoContent();
        }
        
        
        [HttpGet("{cartId}/items")]
        public ActionResult<List<CartItemDetails>> GetCartItems(int cartId)
        {
                var cartItems = _cartManager.GetCartItems(cartId);
                if (cartItems == null)
                {
                    return NotFound();
                }
                return Ok(cartItems);
            }
            
        


        [HttpGet("{userId}")]
        public ActionResult<CartDto> GetCartByUserId(int userId)
        {
            
                var cart = _cartManager.GetCartByUserId(userId);
                if (cart== null)
                {
                    return NotFound();
                }
                return Ok(cart);
           
        }


    }
}

