using System;
using System.Collections.Generic;
using Domain.ValueObjects;

namespace Domain.Entity
{
  public class Customer : BaseEntity
  {
    public String Name { get; set; }
    public Document Document { get; set; }
    public virtual IList<Order> Orders { get; }
  }
}
