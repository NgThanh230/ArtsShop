namespace ArtsShop.Data
{
    using ArtsShop.Model.Product;
    using ArtsShop.Model.Profile;
    using Microsoft.EntityFrameworkCore;

    public class ArtShopDbContext : DbContext
    {
        public ArtShopDbContext(DbContextOptions<ArtShopDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }       
    }

}
