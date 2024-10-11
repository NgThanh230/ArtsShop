using ArtsShop.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtsShop.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
    }
}
