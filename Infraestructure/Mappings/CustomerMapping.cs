using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Mappings
{
  public class CustomerMapping : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
      builder.Property(p => p.Name).HasColumnName(nameof(Customer.Name)).IsRequired();
      builder.Property(p => p.Document.Value).HasColumnName(nameof(Customer.Document)).IsRequired();
    }
  }
}
