using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entity
{
  public class Order : BaseEntity
  {
    public Guid CustomerId { get; }
    public virtual Customer Customer { get; }
    public OrderStatus Status { get; set; }
    public DateTime OrderDate { get; }
    private double _totalPrice;
    public virtual IList<Product> Products { get; set; }
    public double TotalPrice
    {
      get => _totalPrice;
      set
      {
        if (value > 0)
          _totalPrice = value;
      }
    }

  }
}
