using System;
using System.Collections.Generic;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entity
{
  public class Customer : BaseEntity
  {
    public Customer(string name, string documentValue, DocumentType documentType)
    {
      Name = name;
      Document = new Document(value: documentValue, type: documentType);
    }
    public String Name { get; set; }
    public Document Document { get; set; }
    public virtual IList<Order> Orders { get; }

    public override bool Equals(object customer)
    {
      Customer customerParsed = (Customer)customer;
      return Name == customerParsed.Name
             && Document.ToString() == customerParsed.Document.ToString();
    }
  }
}
