using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCMS.Domain.Entities;

namespace SCMS.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o =>  o.Id);

            builder.Property(o => o.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.OrderStatus)
                .HasConversion<string>();

            builder.HasMany(o => o.Items)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
