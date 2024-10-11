using ArtsShop.Data;
using ArtsShop.Model;
using ArtsShop.Model.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArtsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _context; // Để truy cập vào bảng Customer
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(UserManager<IdentityUser> userManager, AppDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Tạo người dùng mới
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Tạo CustomerId ngẫu nhiên hoặc lấy từ hệ thống
                string customerId = Guid.NewGuid().ToString(); // Hoặc phương thức tạo CustomerId riêng của bạn

                // Lưu thông tin khách hàng vào cơ sở dữ liệu
                var customer = new Customer // Giả sử bạn đã có một class Customer
                {
                    CustomerId = customerId,
                    UserId = user.Id, // Liên kết đến IdentityUser
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    // Thêm các thuộc tính khác nếu cần thiết
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Registration successful!", CustomerId = customerId });
            }

            return BadRequest(result.Errors);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid credentials");
            }

            // Tạo token hoặc thông tin cần thiết cho người dùng (nếu cần)
            var customerId = user.Id; // ID của người dùng (customerId)

            return Ok(new { Message = "Login successful", CustomerId = customerId });
        }
    }
}
