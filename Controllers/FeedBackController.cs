using ArtsShop.Data;
using ArtsShop.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ArtsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FeedbackController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST: api/feedback
        [HttpPost]
        public async Task<IActionResult> SubmitFeedback([FromBody] Feedback feedback)
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

            // Kiểm tra đơn hàng
            var order = await _context.Orders
                .Where(o => o.CustomerId == customerId && o.Status == "Delivered")
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return BadRequest("You can only submit feedback after receiving your order.");
            }

            // Tạo mới phản hồi
            feedback.CustomerId = customerId;
            feedback.CreatedAt = DateTime.UtcNow;

            // Lưu phản hồi vào cơ sở dữ liệu
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Feedback submitted successfully!" });
        }


        // GET: api/feedback
        [HttpGet]
        public IActionResult GetFeedbacks()
        {
            var feedbacks = _context.Feedbacks.ToList();
            return Ok(feedbacks);
        }

    }
}
