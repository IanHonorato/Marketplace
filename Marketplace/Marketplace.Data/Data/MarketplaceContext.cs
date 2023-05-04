using Microsoft.EntityFrameworkCore;
using Marketplace.Entities.Entities;

namespace Marketplace.Data.Data
{
    public class MarketplaceContext : DbContext
    {
        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public DbSet<PaymentInfo> PaymentInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(a => a.Seller)
            .WithOne(b => b.User)
            .HasForeignKey<Seller>(b => b.UserId);
        }
    }
}
