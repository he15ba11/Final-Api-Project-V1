using Final_Api_Project.BL.Dtos.Carts;
using Final_Api_Project.BL.Managers.CartItems;
using Final_Api_Project.BL.Managers.Carts;
using Microsoft.AspNetCore.Mvc;

namespace Final_Api_Project.APIs.Controllers
{
     [Route("api/[controller]")]
[ApiController]
 [Authorize]
public class CartItemsController : ControllerBase
{
        private readonly ICartItemManager _cartItemManager;

        public CartItemsController(ICartItemManager cartItemManager)
        {
        _cartItemManager = cartItemManager;
        }
    [HttpPost]
    public ActionResult AddToCart( AddCartItemDto addToCartItemDto)
    {
        _cartItemManager.AddToCart(addToCartItemDto);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpPut("{cartItemId}")]
    public ActionResult UpdateCartItemQuantity(int cartItemId, int quantity)
    {
        _cartItemManager.UpdateCartItemQuantity(cartItemId, quantity);
        return NoContent();
    }

    [HttpDelete("{cartItemId}")]
    public ActionResult RemoveFromCart(int cartItemId)
    {
        _cartItemManager.RemoveFromCart(cartItemId);
        return NoContent();
    }
}
}
