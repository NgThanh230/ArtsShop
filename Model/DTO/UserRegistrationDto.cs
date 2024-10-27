using ArtsShop.Model.Profile;
using ArtsShop.Model.Product;
namespace ArtsShop.Model.DTO
{
    public class UserRegistrationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public User User { get; set; }
        public Cart Cart { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; } 

    }
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
