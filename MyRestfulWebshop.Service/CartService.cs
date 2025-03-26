using MyRestfulWebshop.EF.Models;
using MyRestfulWebshop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyRestfulWebshop.Service
{
    public class CartService
    {
        private readonly MyRestfulWebshopContext _context;

        public CartService(MyRestfulWebshopContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartAsync(string username)
        {
            return await _context.Carts
                .Include(c => c.Items)
                    .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync(c => c.Username == username);
        }

        public async Task AddToCartAsync(string username, int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new System.Exception("Produkt nicht gefunden");

            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.Username == username);

            if (cart == null)
            {
                cart = new Cart { Username = username };
                _context.Carts.Add(cart);
            }

            // Prüfe, ob bereits ein CartItem für dieses Produkt existiert
            var cartItem = cart.Items.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem != null)
            {
                // Menge erhöhen
                cartItem.Quantity++;
            }
            else
            {
                // Neues CartItem hinzufügen
                cart.Items.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = 1
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(string username, int productId)
        {
            var cart = await _context.Carts
               .Include(c => c.Items)
               .FirstOrDefaultAsync(c => c.Username == username);

            if (cart == null)
                throw new Exception("Warenkorb nicht gefunden");

            var cartItem = cart.Items.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
                throw new Exception("Produkt ist nicht im Warenkorb");

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
            else
            {
                cart.Items.Remove(cartItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Order> PayAsync(string username)
        {
            var cart = await _context.Carts
                  .Include(c => c.Items)
                  .ThenInclude(ci => ci.Product)
                  .FirstOrDefaultAsync(c => c.Username == username);

            if (cart == null || !cart.Items.Any())
                throw new Exception("Der Warenkorb ist leer");

            var order = new Order
            {
                Username = username,
                OrderDate = DateTime.Now,
                OrderItems = new System.Collections.Generic.List<OrderItem>()
            };

            decimal total = 0m;
            foreach (var cartItem in cart.Items)
            {
                var product = cartItem.Product;
                int quantity = cartItem.Quantity;
                decimal price = product.Price;
                total += price * quantity;

                order.OrderItems.Add(new OrderItem
                {
                    ProductName = product.Name,
                    Amount = quantity,
                    PriceAtOrderDate = price
                });
            }
            order.TotalSum = total;

            _context.Orders.Add(order);

            cart.Items.Clear();

            await _context.SaveChangesAsync();

            return order;
        }
    }
}
