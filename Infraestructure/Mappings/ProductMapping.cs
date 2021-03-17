using System;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Mappings
{
  public class ProductMapping : IEntityTypeConfiguration<Domain.Entity.Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.Property(p => p.Name).HasColumnName(nameof(Product.Name)).IsRequired();
      builder.Property(p => p.Description).HasColumnName(nameof(Product.Description)).IsRequired();
      builder.Property(p => p.Price).HasColumnName(nameof(Product.Price)).IsRequired();
    }
  }
}
