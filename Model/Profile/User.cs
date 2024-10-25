using ArtsShop.Model.Product;
using System;

namespace ArtsShop.Model.Profile
{

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string? RefreshToken { get; set; }
    }

}
