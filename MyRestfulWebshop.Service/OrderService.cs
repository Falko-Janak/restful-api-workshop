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
    public class OrderService
    {
        private readonly MyRestfulWebshopContext _context;

        public OrderService(MyRestfulWebshopContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(string username)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.Username == username)
                .ToListAsync();
        }
    }
}
