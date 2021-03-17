using System;
using Domain.Enums;

namespace Domain.Entity
{
  public class Order : BaseEntity
  {
    private Guid CustomerId { get; }
    private OrderStatus Status { get; set; }
    private DateTime OrderDate { get; }
    private double _totalPrice;
    public double TotalPrice
    {
      get => _totalPrice; set
      {
        if (value > 0)
          _totalPrice = value;
      }
    }

  }
}
