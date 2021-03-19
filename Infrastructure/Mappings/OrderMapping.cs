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
        .WithOne(p => p.Order).HasForeignKey(p => p.OrderId);
      builder.HasOne<Customer>(o => o.Customer).WithMany(c => c.Orders);
      builder.Property(p => p.TotalPrice)
        .HasColumnName(nameof(Order.TotalPrice)).IsRequired();
    }
  }
}
