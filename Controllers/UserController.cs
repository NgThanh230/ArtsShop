using Microsoft.AspNetCore.Mvc;
using ArtsShop.Model.DTO;
using ArtsShop.Model.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ArtsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;

        public UserController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto registrationDto)
        {
            var result = await _authService.Register(registrationDto);
            return result ? Ok(new { success = true, message = "Đăng ký thành công" })
                          : BadRequest(new { success = false, message = "Email đã được sử dụng trước đó" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var result = await _authService.Login(loginDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}