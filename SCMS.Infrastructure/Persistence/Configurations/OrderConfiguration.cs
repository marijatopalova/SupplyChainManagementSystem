using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCMS.Domain.Entities;

namespace SCMS.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Primary Key
            builder.HasKey(o =>  o.Id);

            // Properties
            builder.Property(o => o.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.OrderStatus)
                .HasConversion<string>();

            // Relationships
            builder.HasMany(o => o.Items)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId) 
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.OrderHistory)
                .WithOne(h => h.Order)
                .HasForeignKey(h => h.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
