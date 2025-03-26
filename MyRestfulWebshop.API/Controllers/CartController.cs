using Microsoft.AspNetCore.Mvc;
using MyRestfulWebshop.API.Converter;
using MyRestfulWebshop.API.Dtos;
using MyRestfulWebshop.EF.Models;
using MyRestfulWebshop.Service;

namespace MyRestfulWebshop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string username)
        {
            var cart = await _cartService.GetCartAsync(username);

            if (cart == null)
                return NotFound("Warenkorb nicht gefunden");

            var cartDtos = cart.Items?.Select(CartItemConverter.ToDto) ?? Enumerable.Empty<CartItemDto>();

            return Ok(cartDtos);
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> AddToCart([FromQuery] string username, int productId)
        {
            await _cartService.AddToCartAsync(username, productId);
            return Created();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveFromCart([FromQuery] string username, int productId)
        {
            await _cartService.RemoveFromCartAsync(username, productId);
            return Ok("Produkt wurde aus dem Warenkorb entfernt");
        }

        [HttpPost("pay")]
        public async Task<IActionResult> Pay([FromQuery] string username)
        {
            var order = await _cartService.PayAsync(username);
            return Ok(order);
        }
    }
}
