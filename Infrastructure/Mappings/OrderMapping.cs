using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Mappings
{
  public class OrderMapping : IEntityTypeConfiguration<Order>
  {
    public void Configure(EntityTypeBuilder<Order> builder)
    {
      builder.HasMany<Product>(o => o.Products)
        .WithOne(o => o.Order).HasForeignKey(o => o.OrderId);
      builder.HasOne<Customer>(o => o.Customer).WithMany(c => c.Orders);
      builder.Property(o => o.TotalPrice)
        .HasColumnName(nameof(Order.TotalPrice)).IsRequired();
      builder.Property(o => o.IsActive)
        .HasColumnName(nameof(Order.IsActive)).IsRequired();

    }
  }
}
