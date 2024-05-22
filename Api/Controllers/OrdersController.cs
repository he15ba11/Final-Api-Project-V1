using Final_Api_Project.BL.Dtos.Orders;
using Final_Api_Project.BL.Managers.Carts;
using Final_Api_Project.BL.Managers.Orders;
using Final_Api_Project.DAL.Data.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_Api_Project.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
     [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly ICartManager _cartManager;

        public OrderController(IOrderManager orderManager , ICartManager cartManager)
        {
            _orderManager = orderManager;
            _cartManager = cartManager;
        }

        [HttpGet("{orderId}")]
        public ActionResult<OrderDTO> GetOrderDetails(int orderId)
        {
            var orderDetails = _orderManager.GetOrderDetails(orderId);
            if (orderDetails == null)
            {
                return NotFound("Order Not Found");
            }
            return Ok(orderDetails);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<OrderDTO>> GetOrdersByUserId(int userId)
        {
            
                    var orders = _orderManager.GetOrdersByUserId(userId);

                    return Ok(orders);

        }

        [HttpGet("calculate-total/{orderId}")]
        public ActionResult<decimal> CalculateTotalPrice(int orderId)
        {
            var totalPrice = _orderManager.CalculateTotalPrice(orderId);
            if (totalPrice == 0) return Ok("The Cart is Empty...");
            return Ok(totalPrice);
        }

        [HttpPost("place-order/{userId}")]
        public ActionResult PlaceOrder(int userId)
        {
            //if(userId!=null){

            var order=_orderManager.PlaceOrder(userId);
                switch (order)
                {
                    case 0:
                    _cartManager.ClearCart(_cartManager.GetCartByUserId(userId).Id);
                        return StatusCode(201); // Created
                       
                    case 1:
                        return Content("User Not Found");
                        
                    case 2:
                        return Content("Cart is Empty...");
                }
           
            // }
            return BadRequest(404);
        }
    }
}
