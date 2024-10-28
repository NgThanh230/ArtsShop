using ArtsShop.Model.DTO;
using ArtsShop.Model.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderDto)
        {
            var response = await _orderService.CreateOrder(orderDto);
            return Ok(response);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] int status)
        {
            var response = await _orderService.UpdateOrderStatus(id, status);
            return Ok(response);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUser(int userId)
        {
            var response = await _orderService.GetOrdersByUser(userId);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            var response = await _orderService.GetOrderDetails(id);
            return Ok(response);
        }
    }
}
