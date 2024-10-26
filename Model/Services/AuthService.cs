using ArtsShop.Data;
using ArtsShop.Model.DTO;
using ArtsShop.Model.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArtsShop.Model.Services
{
    public class AuthService
    {
        private readonly ArtShopDbContext _context;

        public AuthService(ArtShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Register(UserRegistrationDto registrationDto)
        {
            // Check if user already exists
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Email == registrationDto.Email);
            if (existingUser != null) return false;

            // Hash the password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);

            // Create new user
            var newUser = new User
            {
                Email = registrationDto.Email,
                Password = hashedPassword,
                Role = "customer", // Default role
                FullName = registrationDto.FullName,
                Address = registrationDto.Address,
                Phone = registrationDto.Phone,
                RefreshToken = null
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();


            return true;
        }


        public async Task<LoginResponseDto> Login(UserLoginDto loginDto)
        {
            // Find the user by email
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null)
            {
                return new LoginResponseDto { Success = false, Message = "Tài khoản không tồn tại" };
            }

            // Verify the password
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return new LoginResponseDto { Success = false, Message = "Mật khẩu không chính xác" };
            }

            // Generate the JWT token
            var token = GenerateJwtToken(user);

            // Return successful login response
            return new LoginResponseDto
            {
                Success = true,
                User = user,
                AccessToken = token,
                RefreshToken = user.RefreshToken // You might want to handle refresh tokens as well
            };
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
        new Claim(ClaimTypes.Role, user.Role)
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mySuperSecretKeyThatIsAtLeast32CharactersLong"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "ArtShop",
                audience: "ArtShopUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<bool> Logout(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            user.RefreshToken = null; // Clear refresh token or handle as needed
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
