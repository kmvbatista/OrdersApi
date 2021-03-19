using System;
using Domain.Entity;
using Domain.Enums;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Mappings
{
  public class CustomerMapping : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
      builder.HasMany<Order>(c => c.Orders)
        .WithOne(p => p.Customer).HasForeignKey(p => p.CustomerId);
      builder.Property(p => p.Name)
        .HasColumnName(nameof(Customer.Name)).IsRequired();
      builder.Property(p => p.Document)
        .HasConversion(document => document.ToString(), stringStored => SetDocumentValue(stringStored))
        .HasColumnName(nameof(Customer.Document)).IsRequired();
    }

    private Document SetDocumentValue(string value)
    {
      if (IsCpf(value))
      {
        return new Document(value: value, type: DocumentType.CPF);
      }
      return new Document(value: value, type: DocumentType.CNPJ);
    }

    private bool IsCpf(string value)
    {
      return value.Length == 11;
    }
  }
}
