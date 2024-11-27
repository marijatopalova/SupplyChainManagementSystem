using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCMS.Domain.Entities;

namespace SCMS.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.ProductId)
                .IsRequired();

            builder.Property(oi => oi.OrderId)
                .IsRequired();

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.Quantity)
                .IsRequired();

            // Relationships
            builder.HasOne(x => x.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
