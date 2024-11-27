using Microsoft.EntityFrameworkCore;
using SCMS.Domain.Entities;
using SCMS.Infrastructure.Persistence.Configurations;

namespace SCMS.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply entity configurations
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());

            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<OrderItem>()
                .HasQueryFilter(oi => !oi.Product.IsDeleted);
        }
    }
}
