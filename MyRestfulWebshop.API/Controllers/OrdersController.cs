using Microsoft.AspNetCore.Mvc;
using MyRestfulWebshop.Service;

namespace MyRestfulWebshop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] string username)
        {
            var orders = await _orderService.GetOrdersAsync(username);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrderAsync(id);
            
            if (order == null)
                return NotFound("Bestellung nicht gefunden");
            
            return Ok(order);
        }
        
    }
}
