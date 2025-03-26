using MyRestfulWebshop.API.Dtos;
using MyRestfulWebshop.EF.Models;

namespace MyRestfulWebshop.API.Converter
{
    public class CartItemConverter
    {
        public static CartItemDto ToDto(CartItem cartItem)
        {
            return new CartItemDto
            {
                ProductId = cartItem.ProductId,
                ProductName = cartItem.Product.Name,
                Price = cartItem.Product.Price,
                Quantity = cartItem.Quantity
            };
        }
    }
}
