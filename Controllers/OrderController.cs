using ArtsShop.Data;
using ArtsShop.DTO.ProductDTO;
using ArtsShop.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ArtsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/order/place-order
        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Lấy CustomerId từ Claims
            var customerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (customerIdClaim == null)
            {
                return BadRequest("Customer ID not found.");
            }
            string customerId = customerIdClaim.Value;

            // Tìm sản phẩm
            var product = await _context.Products.FindAsync(model.ProductId);
            if (product == null)
            {
                return BadRequest("Product not found.");
            }

            // Tính tổng số tiền
            decimal totalAmount = product.Price * model.Quantity;

            // Tạo đơn hàng mới
            var order = new Order
            {
                OrderId = GenerateOrderId(), // Hàm tạo ID đơn hàng
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                TotalAmount = totalAmount,
                PaymentType = model.PaymentType,
                Status = "Pending" // Trạng thái mặc định
            };

            // Lưu đơn hàng vào cơ sở dữ liệu
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Order placed successfully!", OrderId = order.OrderId });
        }

        private string GenerateOrderId()
        {
            // Tạo Order ID 16 ký tự bao gồm (1 ký tự loại thanh toán, 7 ký tự ProductId, 8 ký tự số thứ tự)
            string paymentTypeIndicator = "1"; // Giả sử 1 là loại thanh toán Credit Card, bạn có thể thay đổi
            string productId = Guid.NewGuid().ToString().Substring(0, 7); // Lấy 7 ký tự đầu tiên từ GUID
            string orderNumber = new Random().Next(10000000, 99999999).ToString(); // Tạo số thứ tự 8 ký tự

            return $"{paymentTypeIndicator}{productId}{orderNumber}";
        }
        // PUT: api/order/update-status/{orderId}
        [HttpPut("update-status/{orderId}")]
        public async Task<IActionResult> UpdateOrderStatus(string orderId, [FromBody] string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            // Cập nhật trạng thái đơn hàng
            order.Status = status;
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Order status updated successfully!" });
        }
    }
}
